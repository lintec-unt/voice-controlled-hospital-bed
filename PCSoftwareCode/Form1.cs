using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace ProgramaSiprosaNeurociencia
{
    public partial class Form1 : Form
    {
        int btn0;
        int click = 0;                           //Variable que indica si el boton està activo o no
        int ejeX;
        int ejeY;

        private string[] availablePorts;         //Vector que almacena los puertos disponibles de la PC
        public static string portConnect;        //Variable que confirma conexión a puerto del Hardware
        public static string connectionPort;     //Variable que almacena el puerto de conexion
        public int cbz;                          // Variable correspondiente al boton del movimiento de Cabeza
        public int pie;                          // Variable correspondiente al boton del movimiento de Pie
        public int cm;                           // Variable correspondiente al boton del movimiento de Cama
        public int pen;                          // Variable correspondiente al boton del movimiento de Pendulo (Trendelemburg)
        public int rep;                          // Variable correspondiente al boton del movimiento de Reposo
        int icbz;                                // Variable que contabiliza tiempo de movimiento de Cabeza
        int ipie;                                // Variable que contabiliza tiempo de movimiento de Pie
        int icm;                                 // Variable que contabiliza tiempo de movimiento de Cama
        int ipen;                                // Variable que contabiliza tiempo de movimiento de Pendulo 
        public int firstOpen = 0;                //Variable que determina si el software se abre por 1era vez

        public Form1()
        {
            //Se abre pantalla inicial de carga
            Thread startscr = new Thread(new ThreadStart(StartScreen));
            startscr.Start();
            Thread.Sleep(6000);

            InitializeComponent();

            startscr.Abort();
            startscr.Join();

            //Se busca conexión de Hardware en los puertos
            SearchAvailablePorts();
        }

        public void StartScreen() // Método correspondiente a pantalla inicial de carga
        {
            try
            {
                Application.Run(new StartScreen());
            }
            finally
            {
                //Demoramos 1seg el cierre del thread
                Thread.Sleep(1000);
            }
        }

        private void InitialPosition()
        {
            //Obtenemos las dimensiones de la pantalla principal (area de trabajo)
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            //Establecemos el tamaño de la ventana principal (ancho y alto)
            this.Size = new System.Drawing.Size(624, 347);


            //Establecemos la ubicacion inicial de la ventana principal
            this.StartPosition = FormStartPosition.Manual;

            this.Location = new Point(ejeX, ejeY); //La posicion respecto al eje Y es 0, ya que comienza en la parte superior de la ventana de trabajo
        }

        //Método que se encarga de buscar los puertos disponibles en la PC
        private void SearchAvailablePorts()
        {
            //Al abrir el software, se inicia una busqueda automatica de los puertos activos y se conecta al detectar uno

            availablePorts = System.IO.Ports.SerialPort.GetPortNames(); //Se crea un vector con los puertos 
                                                                        //disponibles detectados

            //Se verifica que uno de los puertos pertenecientes al vector esté conectado al hardware Arduino

            int totalAvailablePorts = availablePorts.Length; // Se contabiliza el total de puertos en el vector

            if (totalAvailablePorts == 0) // Se especifica que no hay conexiones a puertos detectables en la PC
            {
                Array.Clear(availablePorts, 0, availablePorts.Length);
            }
            else
            {
                // Por cada puerto almacenado en el vector se realiza una verificación para detectar que el 
                //hardware adecuado este conectado
                foreach (string port in availablePorts)
                {
                    try
                    {   
                        //Verificamos en todos los puertos activos de la PC si se encuentra conectado
                        // el hardware correspondiente
                        ArduinoPort.ReadTimeout = 2000;
                        ArduinoPort.PortName = port;
                        ArduinoPort.Open();
                        ArduinoPort.Write("c");
                        Application.DoEvents();
                        Thread.Sleep(500);

                        //Se espera una respuesta confirmando conexión al hardware
                        ArduinoPort.DataReceived += ArduinoPort_DataReceived;

                        if (ArduinoPort.IsOpen & portConnect == "Y")
                        {
                            //Al conectarse a través de un puerto, se muestra mediante un mensaje
                            label1.Text = "Conectado";
                            break;
                        }
                        else
                        {
                            //Al desconectarse el equipo, se muestra mediante un mensaje 
                            label1.Text = "Desconectado";
                            ArduinoPort.Close();
                        }
                    }
                    catch
                    {
                        label1.Text = "Desconectado";
                        ArduinoPort.Close();
                    }
                }
            }
            //Si no se conecta el puerto correspondiente, se borra el arreglo de puertos disponibles 
            // y se inicia la busque nuevamente
            Array.Clear(availablePorts, 0, availablePorts.Length);
            ((System.Collections.IList)availablePorts).Clear();
        }

        //Método que se encarga de detectar la confirmación de conexión del hardware
        private void ArduinoPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = ArduinoPort.ReadExisting();
                if (data == "10") // Este valor indica que el software se ha conectado al hardware efectivamente
                {
                    portConnect = "Y";
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        //Para seleccionar una posición nueva de la ventana de trabajo, se abre una nueva ventana (form2)
        // para seleccionar la posición deseada
        private void seleccionarPuertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrimos la ventana de selección de posición
            Form2 frm2 = new Form2();
            frm2.ShowDialog();

            //Si no se seleccionan coordenadas posicionales, la ventana principal no se desplaza
            if (frm2.Xpos == null & frm2.Ypos == null)
            {
                frm2.Close();
            }
            //Si se seleccionan coordenadas posicionales nuevas, la ventana principal se desplaza
            //a la seleccionada
            else
            {
                ejeX = int.Parse(frm2.Xpos);
                ejeY = int.Parse(frm2.Ypos);

                InitialPosition();
            }
        }

        //Al abrir el software por primera vez (luego de la instalación) se debe seleccionar la posición
        //inicial de la ventana principal
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
                // Primera vez que se abre la aplicación
                Form2 frm2 = new Form2();
                frm2.ShowDialog();

                ejeX = int.Parse(frm2.Xpos);
                ejeY = int.Parse(frm2.Ypos);

                InitialPosition();
            }
            else
            {
                //El estado ( maximizado, minimizado o variable) de la ventana principal se almacena 
                //luego de cada modificación de la misma
                this.WindowState = Properties.Settings.Default.F1State;

                //Nunca se abre el software con la ventana minimizada
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                //La posición de la ventana principal se almacena luego de cada modificación de la misma
                this.Location = Properties.Settings.Default.F1Location;
                //El tamaño de la ventana principal se almacena luego de cada modificación de la misma
                this.Size = Properties.Settings.Default.F1Size;

            }
            this.toolTip1.SetToolTip(button1, "Salir de la aplicación");
            this.toolTip1.SetToolTip(button3, "Seleccionar Posicion de la Aplicación");

            refreshForm();
        }

        //Método para mostrar en la ventana principal si el software se encuentra conectado o no
        // al hardware.
        private void refreshForm()
        {   
            //Si se encuentra conectado
            if (portConnect == "Y")
            {
                pbcbzArr.Image = Properties.Resources.az_cbz_arr;
                pbpieArr.Image = Properties.Resources.az_pie_arr;
                pbcmArr.Image = Properties.Resources.az_cm_arr;
                pbcbzAba.Image = Properties.Resources.az_cbz_aba;
                pbpieAba.Image = Properties.Resources.az_pie_aba;
                pbcmAba.Image = Properties.Resources.az_cm_aba;
                pbpenAd.Image = Properties.Resources.az_pen_ad;
                pbpenAt.Image = Properties.Resources.az_pen_at;
                pbreposo.Image = Properties.Resources.az_desbloq;
            }
            //Si no se encuentra conectado
            else
            {
                pbcbzArr.Image = Properties.Resources.bn_cbz_arr;
                pbpieArr.Image = Properties.Resources.bn_pie_arr;
                pbcmArr.Image = Properties.Resources.bn_cm_arr;
                pbcbzAba.Image = Properties.Resources.bn_cbz_aba;
                pbpieAba.Image = Properties.Resources.bn_pie_aba;
                pbcmAba.Image = Properties.Resources.bn_cm_aba;
                pbpenAd.Image = Properties.Resources.bn_pen_ad;
                pbpenAt.Image = Properties.Resources.bn_pen_at;
                pbreposo.Image = Properties.Resources.bn_desbloq;

                //Cerramos lel puerto de conexión
                ArduinoPort.Close();
                ArduinoPort.Dispose();

            }
        }

        //Método para el manejo de las posiciones de la cama, según la imagen seleccionada
        // cuando el software se encuentra conectado al hardware
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                //Contabilizamos la cantidad de click realizados para activar o desactivar el movimiento
                if (click == 0)
                {
                    btn0 = 1; // el valor "1" indica que es el Boton CabezaArriba
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 1;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 2; // el valor "2" indica que es el Boton PiesArriba
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 2;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 3; // el valor "3" indica que es el Boton CamaArriba
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 3;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 4; // el valor "4" indica que es el Boton CabezaAbajo
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 4;
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 5; // el valor "5" indica que es el Boton PiesAbajo
                    click = 1;
                    MoveBed();//Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 5;
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 6; // el valor "6" indica que es el Boton CamaAbajo
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 6;
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 7; // el valor "7" indica que es el Boton PenduloAdelante
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 7;
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 8; // el valor "8" indica que es el Boton PenduloAtras
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 8;
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (portConnect == "Y")
            {
                if (click == 0)
                {
                    btn0 = 9; // el valor "9" indica que es el Boton Desbloquear
                    click = 1;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                }
                else
                {
                    click = 0;
                    MoveBed(); //Se accede al método que envia la señal correspondiente al hardware
                    btn0 = 9;
                }
            }
        }

        //Método que envía la señal al hardware indicando que botón se presionó, correspondiente al
        //movimiento de la cama seleccionado
        public void MoveBed()
        {
            if (click == 1)
            {
                if (btn0 == 1)
                {
                    try
                    {
                        pbcbzArr.Image = Properties.Resources.ve_cbz_arr;
                        icbz = cbz;
                        ArduinoPort.Write(((char)53).ToString());
                        MoveTimer.Start(); //Método que denota el tiempo máximo que puede moverse la cama
                                           //dependiendo del botón seleccionado. Inicia el contador.

                        if (cbz >= 22)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            pbcbzArr.Image = Properties.Resources.az_cbz_arr;
                            cbz = 0;
                            icbz = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 2)
                {
                    try
                    {
                        pbpieArr.Image = Properties.Resources.ve_pie_arr;
                        ipie = pie;
                        ArduinoPort.Write(((char)55).ToString());
                        MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                          //dependiendo del botón seleccionado. Inicia el contador.

                        if (pie >= 16)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            pbpieArr.Image = Properties.Resources.az_pie_arr;
                            pie = 0;
                            ipie = 0;
                        }
                    }
                    catch
                    {
                    }

                }
                if (btn0 == 3)
                {
                    try
                    {
                        pbcmArr.Image = Properties.Resources.ve_cm_arr;
                        icm = cm;
                        ArduinoPort.Write(((char)54).ToString());
                        MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                          //dependiendo del botón seleccionado. Inicia el contador.

                        if (cm >= 36)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            pbcmArr.Image = Properties.Resources.az_cm_arr;
                            cm = 0;
                            icm = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 4)
                {
                    try
                    {
                        pbcbzAba.Image = Properties.Resources.ve_cbz_aba;
                        icbz = cbz;
                        ArduinoPort.Write(((char)51).ToString());
                        MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                          //dependiendo del botón seleccionado. Inicia el contador.

                        if (cbz >= 22)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            click = 0;
                            pbcbzAba.Image = Properties.Resources.az_cbz_aba;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 5)
                {
                    try
                    {
                        pbpieAba.Image = Properties.Resources.ve_pie_aba;
                        ipie = pie;
                        ArduinoPort.Write(((char)50).ToString());
                        MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                          //dependiendo del botón seleccionado. Inicia el contador.

                        if (pie >= 16)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            click = 0;
                            pbpieAba.Image = Properties.Resources.az_pie_aba;
                            pie = 0;
                            ipie = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 6)
                {
                    try
                    {
                        pbcmAba.Image = Properties.Resources.ve_cm_aba;
                        icm = cm;
                        ArduinoPort.Write(((char)52).ToString());
                        MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                          //dependiendo del botón seleccionado. Inicia el contador.

                        if (cm >= 36)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            click = 0;
                            pbcmAba.Image = Properties.Resources.az_cm_aba;
                            cm = 0;
                            icm = 0;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 7)
                {
                    try
                    {
                        if (pen >= 0)
                        {
                            pbpenAd.Image = Properties.Resources.ve_pen_ad;
                            ipen = pen;
                            ArduinoPort.Write(((char)49).ToString());
                            MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                              //dependiendo del botón seleccionado. Inicia el contador.
                        }
                        if (pen >= 42)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            pbpenAd.Image = Properties.Resources.az_pen_ad;
                        }

                        // Esta parte del codigo controla que la cama se mueva a la posicion contraria
                        if (pen < 0)
                        {
                            ipen = pen;
                            pbpenAd.Image = Properties.Resources.ve_pen_ad;
                            timerPen.Start();
                            pen = ipen;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 8)
                {
                    try
                    {
                        if (pen <= 0)
                        {
                            pbpenAt.Image = Properties.Resources.ve_pen_at;
                            ipen = pen;
                            ArduinoPort.Write(((char)56).ToString());
                            MoveTimer.Start();//Método que denota el tiempo máximo que puede moverse la cama
                                              //dependiendo del botón seleccionado. Inicia el contador.
                        }
                        if (pen < -42)
                        {
                            MoveTimer.Stop();//Método que denota el tiempo máximo que puede moverse la cama
                                             //dependiendo del botón seleccionado. Detiene el contador.
                            ArduinoPort.Write(((char)00).ToString());
                            pbpenAt.Image = Properties.Resources.ve_pen_at;
                        }

                        // Esta parte controla que la cama se mueva a la posicion contraria

                        if (pen > 0)
                        {
                            ipen = pen;
                            pbpenAt.Image = Properties.Resources.ve_pen_at;
                            timerPen.Start();
                            pen = ipen;
                        }
                    }
                    catch
                    {
                    }
                }
                if (btn0 == 9) //Función de desbloqueo de cama
                {
                    try
                    {
                        if (portConnect == "Y")
                        {
                            //Crear thread
                            Thread unlock = new Thread(unlockBed);

                            //Iniciar thread
                            unlock.Start();
                            ArduinoPort.Write(((char)57).ToString());  // CAMBIAR EL VALOR
                                                                       //NECESARIO PARA EL RESETEO
                            Thread.Sleep(10000);
                            ArduinoPort.Write(((char)00).ToString());

                            //Terminar thread
                            unlock.Abort();
                            unlock.Join();
                        }
                        else
                        {
                            MessageBox.Show("Conecte el hardware adecuadamente", "Funcion Desbloqueo inaccesible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {

                    }

                }
            }
            else
            {
                //Si ya se habia presionado una vez el botón, entonces se indica al hardware
                // que la cama debe detener su movimiento
                if (btn0 == 1)
                {
                    try
                    {
                        pbcbzArr.Image = Properties.Resources.az_cbz_arr;
                        ArduinoPort.Write(((char)00).ToString());
                        MoveTimer.Stop();
                        cbz = 0;
                        icbz = 0;
                    }
                    catch
                    {
                    }

                }
                if (btn0 == 2)
                {
                    try
                    {
                        pbpieArr.Image = Properties.Resources.az_pie_arr;
                        ArduinoPort.Write(((char)00).ToString());
                        MoveTimer.Stop();
                        pie = 0;
                        ipie = 0;
                    }
                    catch
                    {

                    }

                }
                if (btn0 == 3)
                {
                    try
                    {
                        pbcmArr.Image = Properties.Resources.az_cm_arr;
                        ArduinoPort.Write(((char)00).ToString());
                        MoveTimer.Stop();
                        cm = 0;
                        icm = 0;
                    }
                    catch
                    {

                    }

                }
                if (btn0 == 4)
                {
                    try
                    {
                        pbcbzAba.Image = Properties.Resources.az_cbz_aba;
                        ArduinoPort.Write(((char)00).ToString());
                        MoveTimer.Stop();
                        cbz = 0;
                        icbz = 0;
                    }
                    catch
                    {

                    }
                }
                if (btn0 == 5)
                {
                    try
                    {
                        pbpieAba.Image = Properties.Resources.az_pie_aba;
                        MoveTimer.Stop();
                        ArduinoPort.Write(((char)00).ToString());
                        pie = 0;
                        ipie = 0;
                    }
                    catch
                    {

                    }
                }
                if (btn0 == 6)
                {
                    try
                    {
                        pbcmAba.Image = Properties.Resources.az_cm_aba;
                        MoveTimer.Stop();
                        ArduinoPort.Write(((char)00).ToString());
                        cm = 0;
                        icm = 0;
                    }
                    catch
                    {

                    }

                }
                if (btn0 == 7)
                {
                    try
                    {
                        pbpenAd.Image = Properties.Resources.az_pen_ad;
                        ArduinoPort.Write(((char)00).ToString());
                        MoveTimer.Stop();
                        timerPen.Stop();
                        pen = 0;
                        ipen = 0;
                    }
                    catch
                    {
                    }

                }
                if (btn0 == 8)
                {
                    try
                    {
                        pbpenAt.Image = Properties.Resources.az_pen_at;
                        ArduinoPort.Write(((char)00).ToString());
                        MoveTimer.Stop();
                        timerPen.Stop();
                        pen = 0;
                        ipen = 0;
                    }
                    catch
                    {

                    }

                }
                if (btn0 == 9)
                {
                    // El boton de REPOSO es un boton de "REINICIO", es decir, vuelve a su posicion
                    //inicial, por lo que no se detiene hasta lograr esto.

                }
            }
        }

        //Método que controla el tiempo de movimiento de la cama para deneter si sobrepasa cierto limite
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (btn0 == 1)
            {
                icbz++;

                if (icbz == 22)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write(((char)00).ToString());
                    pbcbzArr.Image = Properties.Resources.az_cbz_arr;
                    click = 0;
                    cbz = 0;
                    icbz = 0;
                }
            }
            if (btn0 == 2)
            {
                ipie++;

                if (ipie == 16)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write("b");
                    pbpieArr.Image = Properties.Resources.az_pie_arr;
                    click = 0;
                    pie = 0;
                    ipie = 0;
                }
            }
            if (btn0 == 3)
            {
                icm++;

                if (icm == 36)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write("b");
                    pbcmArr.Image = Properties.Resources.az_cm_arr;
                    click = 0;
                    cm = 0;
                    icm = 0;
                }
            }
            if (btn0 == 4)
            {
                icbz++;

                if (icbz == 22)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write("b");
                    pbcbzAba.Image = Properties.Resources.az_cbz_aba;
                    click = 0;
                    cbz = 0;
                    icbz = 0;
                }
            }
            if (btn0 == 5)
            {
                ipie++;

                if (ipie == 16)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write("b");
                    pbpieAba.Image = Properties.Resources.az_pie_aba;
                    click = 0;
                    pie = 0;
                    ipie = 0;
                }

            }
            if (btn0 == 6)
            {
                icm++;

                if (icm == 36)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write("b");
                    pbcmAba.Image = Properties.Resources.az_cm_aba;
                    click = 0;
                    cm = 0;
                    icm = 0;
                }

            }
            if (btn0 == 7)
            {
                ipen++;

                if (ipen == 42)
                {
                    MoveTimer.Stop();
                    pbpenAd.Image = Properties.Resources.az_pen_ad;
                    click = 0;
                    pen = 0;
                    ipen = 0;
                }
            }
            if (btn0 == 8)
            {
                ipen--;

                if (ipen == -42)
                {
                    MoveTimer.Stop();
                    pbpenAt.Image = Properties.Resources.az_pen_at;
                    click = 0;
                    pen = 0;
                    ipen = 0;
                }
            }
        }

        //Método que controla el tiempo del movimiento pendular (Trendelemburg)
        private void timerPen_Tick(object sender, EventArgs e)
        {
            if (btn0 == 7)
            {
                ipen++;
                ArduinoPort.Write(((char)55).ToString());

                if (pen < 0 & ipen == 0)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write(((char)00).ToString());
                    pen = 0;
                    ipen = 0;
                }
            }

            if (btn0 == 8)
            {
                ipen--;
                ArduinoPort.Write(((char)56).ToString());

                if (pen > 0 & ipen == 0)
                {
                    MoveTimer.Stop();
                    ArduinoPort.Write(((char)00).ToString());
                    pen = 0;
                    ipen = 0;
                }
            }
        }

        //Método que controla si el puerto del hardware (arduino) se encuentra disponible
        private void portTimer_Tick(object sender, EventArgs e)
        {
            if (ArduinoPort.IsOpen)
            {
                portConnect = "Y";
            }
            else
            {
                portConnect = "N";
                SearchAvailablePorts();

                Application.DoEvents();
                Thread.Sleep(500);
                refreshForm();
            }
        }

        //Función salir del programa, del menú desplegable
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArduinoPort.Close();
            ArduinoPort.Dispose();

            Application.DoEvents();
            Thread.Sleep(1000);

            this.Close();
        }

        //Método que se encarga de almacenar las varibles tamaño, posicion y estado de la ventana principal 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)     // Si la ventana no esta minimizada
            {
                // guardamos posicion y tamaño antes de cerrar la ventana
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // Volvemos a la ultima posicion y tamaño antes de minimizar o maximizar la ventana
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location; //Restorebounds = obtiene la posicion y el tamaño
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;        // de la ventana antes de minimizarla
            }

            ArduinoPort.Close();
            ArduinoPort.Dispose();

            Application.DoEvents();
            Thread.Sleep(1000);

            // Almacenamos la configuracion final
            Properties.Settings.Default.Save();
        }

        //Botón utilizado para salir de la aplicación
        private void button1_Click(object sender, EventArgs e)
        {
            ArduinoPort.Close();
            ArduinoPort.Dispose();

            Application.DoEvents();
            Thread.Sleep(1000);

            this.Close();
        }

        // Botón para desbloquear la cama, correspondiente al menú desplegable
        private void desbloquearCamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (portConnect == "Y")
                {
                    //Crear thread
                    Thread unlock = new Thread(unlockBed);

                    //Iniciar thread
                    unlock.Start();
                    ArduinoPort.Write(((char)57).ToString());  // CAMBIAR EL VALOR PARA EL 
                                                               //NECESARIO PARA EL RESETEO
                    Thread.Sleep(10000);
                    ArduinoPort.Write(((char)00).ToString());

                    //Terminar thread
                    unlock.Abort();
                    unlock.Join();
                }
                else
                {
                    MessageBox.Show("Conecte el hardware adecuadamente", "Funcion Desbloqueo inaccesible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        //Método que desbloquea la cama
        public void unlockBed()
        {
            try
            {
                VentanaReset reset = new VentanaReset();
                reset.ShowDialog();
            }
            finally
            {
                //Demoramos 1seg el cierre del thread
                Thread.Sleep(1000);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (portConnect == "Y")
                {
                    //Crear thread
                    Thread unlock = new Thread(unlockBed);

                    //Iniciar thread
                    unlock.Start();
                    ArduinoPort.Write(((char)55).ToString()); 
                    Thread.Sleep(10000);
                    ArduinoPort.Write(((char)00).ToString());

                    //Terminar thread
                    unlock.Abort();
                    unlock.Join();
                }
                else
                {
                    MessageBox.Show("Conecte el hardware adecuadamente", "Funcion Desbloqueo inaccesible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();

            if (frm2.Xpos == null & frm2.Ypos == null)
            {
                frm2.Close();
            }
            else
            {
                ejeX = int.Parse(frm2.Xpos);
                ejeY = int.Parse(frm2.Ypos);

                InitialPosition();
            }
   
        }
    }
}
