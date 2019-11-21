/* Copyright (c) 2019, CONICET, UNT, SIPROSA
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions and the following disclaimer.
 *
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 *
 *
 * 3. Neither the name of the copyright holder nor the names of its
 *    contributors may be used to endorse or promote products derived from
 *    this software without specific prior written permission.
 *
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 *
 */

/* Author: Facundo Adrián Lucianna (flucianna@herrera.unt.edu.ar) */
/* Date (DD/MM/YYYY): 11/10/2018 */

/*==================[macros y definiciones]=================================*/

#define NPIN1  2     //Pin 2 Arduino
#define NPIN2  3     //Pin 3 Arduino
#define NPIN3  4     //Pin 4 Arduino
#define NPIN4  5     //Pin 5 Arduino
#define NPIN5  6     //Pin 6 Arduino
#define NPIN6  7     //Pin 7 Arduino
#define NPIN7  11    //Pin 11 Arduino
#define NPIN8  12    //Pin 12 Arduino

#define SERIALOKPC          99      //El caracter "c" en ASCII que envia la PC para conectar con el sistema
#define SERIALACKTOPC       10      //Se envia el numero 10 a la PC para avisarle que esta vivo.

#define SERIALPENADEL       51      //ASCII para pendulo adelante
#define SERIALPENATRAS      49      //ASCII para pendulo atras

#define SERIALPIEARRIBA     56      //ASCII para pie arriba
#define SERIALPIEABAJO      50      //ASCII para pie arriba

#define SERIALCABABAJO      52      //ASCII para cabeza abajo
#define SERIALCABARRIBA     55      //ASCII para cabeza arriba

#define SERIALCAMAABAJO     53      //ASCII para cama abajo
#define SERIALCAMAARRIBA    54      //ASCII para cama arriba

#define SERIALDESBLOQUEO    57      //Serial para desbloqueo

#define TIEMPOESPERACONF    250     //1/4 de segundo de espera
#define TIEMPOESPERASERIAL  500     //Medio segundo de espera
#define BAUDS               9600    //9600 baudios de transmision serial

/*==================[tipos de datos declarados por el usuario]===============*/
/*==================[declaraciones de datos externos]========================*/

int incomingByte = 0; // Variable que almacena lo que llega de la PC

bool flagSerial = false; // Flag para indicar que llego algo del puerto serie

/*==================[definiciones de funciones externas]=====================*/

/*-----------------------------------------------------------------
 *   La función setup() configura las salidas de los pines para
 *   controlar la cama y luego se configura el puerto serie y espera
 *   a la PC o sistema embebido que lo controla se comunique con el
 *   sistema.
 *-----------------------------------------------------------------*/
void setup()
{

  pinMode(NPIN1,OUTPUT);
  pinMode(NPIN2,OUTPUT);
  pinMode(NPIN3,OUTPUT);
  pinMode(NPIN4,OUTPUT);
  pinMode(NPIN5,OUTPUT);
  pinMode(NPIN6,OUTPUT);
  pinMode(NPIN7,OUTPUT);
  pinMode(NPIN8,OUTPUT);

  digitalWrite(NPIN1, HIGH);
  digitalWrite(NPIN2, HIGH);
  digitalWrite(NPIN3, HIGH);
  digitalWrite(NPIN4, HIGH);
  digitalWrite(NPIN5, HIGH);
  digitalWrite(NPIN6, HIGH);
  digitalWrite(NPIN7, HIGH);
  digitalWrite(NPIN8, HIGH);

  delay(TIEMPOESPERACONF);

  Serial.begin(BAUDS);
  //Serial.println("Test cama");   // DEBUG: Mensaje de bienvenida

  delay(TIEMPOESPERACONF);

  while(1) {
    if (Serial.available() > 0) { // Hay algo en el puerto serie

      incomingByte = Serial.read(); // Leemos el dato

      if (incomingByte == SERIALOKPC) {  // La PC intenta conectarse al Arduino

        Serial.print(SERIALACKTOPC, DEC);   // Confirmamos intento de conexión al software
        break;

      }
    }
  }
}

/*-----------------------------------------------------------------
 *   La función loop() realiza el bucle infinito en donde se recibe
 *   los caracteres de la PC y en funcion de cual sea, da un control
 *   a la cama.
 *-----------------------------------------------------------------*/
void loop()
{

  if (Serial.available() > 0) { // Hay algo en el puerto serie

    incomingByte = Serial.read(); // Leemos el dato

    //Esto es necesario si la PC se desconecta y vuelve a conectar y no se tenga que reiniciar el microcontrolador.
    if (incomingByte == SERIALOKPC) { // El software intenta conectarse al Arduino

      Serial.print(SERIALACKTOPC,DEC);// Confirmamos intento de conexión al software
      flagSerial = false;
    } else {

      flagSerial = true;
    }
  }

  if (flagSerial) {   // Esta flag esta para que solo cambie de estado los pines cuando se recibio algo del puerto serial.

    switch (incomingByte) {  // Dependiendo del valor de la variable, hacemos algo o no.
      case SERIALPENADEL:

        digitalWrite(NPIN1, LOW);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);
        flagSerial = false;
        break;
      case SERIALPIEABAJO:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,LOW);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
     case SERIALCABABAJO:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,LOW);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
     case SERIALCAMAABAJO:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,LOW);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
     case SERIALCABARRIBA:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,LOW);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
     case SERIALCAMAARRIBA:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,LOW);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
     case SERIALPIEARRIBA:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,LOW);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
     case SERIALPENATRAS:

        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,LOW);

        flagSerial = false;
        break;
     case SERIALDESBLOQUEO:

        digitalWrite(NPIN1,HIGH);  //Se acciona sistema para desbloquear la cama.
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,LOW);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,LOW);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
    default:     // Cualquier otro valor que llega, apaga todo. Lo ideal es que se mande un cero, pero si por algun motivo hay algun error de comunicacion, lo mejor que se puede hacer es que la cama no se mueva
        digitalWrite(NPIN1,HIGH);
        digitalWrite(NPIN2,HIGH);
        digitalWrite(NPIN3,HIGH);
        digitalWrite(NPIN4,HIGH);
        digitalWrite(NPIN5,HIGH);
        digitalWrite(NPIN6,HIGH);
        digitalWrite(NPIN7,HIGH);
        digitalWrite(NPIN8,HIGH);

        flagSerial = false;
        break;
    }
  }

  delay(TIEMPOESPERASERIAL);  // Espera TIEMPOESPERASERIAL. Esto no significa que no se puede mandar un comando serial en menos de TIEMPOESPERASERIAL segundos, sino que los ejecuta cada TIEMPOESPERASERIAL segundos (El puerto serial tiene un stack que va a almacenando cada valor que llega).

}

/*==================[fin del archivo]========================================*/
