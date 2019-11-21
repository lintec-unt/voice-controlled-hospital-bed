# Voice Controlled Hospital Bed System 1.0

This is the version 1.0 of the Voice Controlled Hospital Bed System. This proyect aims to allow bedridden patients that have a discapacity that do not allow them to use their hands to control the position of their bed, but they can talk, to control the bed with oral commands.

In this first version, the system can only work with a particular model of hospital bed (Pettinari PM Millennium), and it works with a PC with a speech recognition software (for example, Windows Speech Recognition, Dragon NaturallySpeaking, among others).

![System block diagram][blockdiagram]

As we can see in the block diagram, the system has the following parts:

* PC with Microsoft Windows OS and a speech recognition software.
* PC software to control the hospital bed.
* Arduino UNO board that translates the commands from the PC to actions in the bed.
* An Arduino shield that has all the extra hardware needed.
* A case to put the Arduino board and its shield to adapt it in the bed.

In this repository, we have uploaded the codes and files of:

* Code of the PC software to control the hospital bed.
* Code of the Arduino UNO board.
* PCB design of the Arduino shield.
* A STL file of the case.

### Arduino shield (PCB folder)

![PCB 3D view][pcb]

The arduino UNO board is connected to the hospital bed by the communication port for the wired remote control command. To emulate the buttons of the remote control, we used the GPIO port. As we intended to avoid electrical connection between the Arduino board (and the PC in upstream connection), the connections with the bed and the GPIO ports are between optocouplers. After the optocouplers, there is DIN connector (DIN 41524) that is connected in the bed. the connection between the PC and the Arduino board is by the means of the USB serial port.

The PCB design (the PCB folder) includes the optocouplers and a connector for the cable with the DIN connection.

### Arduino Board Software (ArduinoCode folder)

It was developed under Arduino IDE and with the standard libraries from Arduino.cc

This software has the typical infinite loop structure (setup() and loop()). In setup(), it starts all the GPIO pin needed as inputs and wait a command from the PC to start working. In loop(), the Arduino receive a char, and if it means a valid command, it activates the corresponding GPIO pin.

### The case (STL folder)

![Case 3D view][stl]

The arduino board and its shield was attached in the hospital bed by a 3d printed case. This case works as kind of protection for all the electronics.  

### The PC sofware (PCSoftwareCode folder)

![PC software][window]

The software that send the commands to the arduino is coded in C#, it was coded under Visual Studio IDE 15.

When the software is initializated, it search for the Arduino board in the differents avalaible serial ports (COM ports). To find it, it sends a char that the Arduino undestand as valid one and the Arduino responds with another char. The main windows has all the commands to move the bed in the form of images. If the user does a click in one of them, the software sends the correponding command to the Arduino to move the bed every 500 ms (this delta of time assures a smooth movement of the bed). To stop the movement, it is necesary to click in the same image but also, the software automatically stop the movement after 30 seconds.

The user using the speech recognition software can send a voice command to make click in one of the images. The size of the images are intended to make easier to the user to choose one of the images.

## Roadmap

For new advances in this work, we want to add the support for other models and brand of hospital beds. Also, we want adding the posibility to replace the PC with a embebbed system with a buit-in speech recognition software.

We are open to new ideas, everyone is open to participate in this development, as long as the guidelines are respected (see Contributing.md)


[blockdiagram]: https://gitlab.com/lintec-unt/voice-controlled-hospital-bed/blob/master/PCB/PCB3dVIew.jpg  "System block diagram"
[pcb]: https://gitlab.com/lintec-unt/voice-controlled-hospital-bed/blob/master/PCB/PCB3dVIew.jpg "PCB 3D view"
[stl]: https://gitlab.com/lintec-unt/voice-controlled-hospital-bed/blob/master/STLCase/snapCase.png  "Case 3D view"
[window]: https://gitlab.com/lintec-unt/voice-controlled-hospital-bed/blob/master/PCSoftwareCode/window.png  "PC software"








El PCB con los optoacopladores que funciona como Shield de Arduino y el diseño del gabinete de contención se encuentra en este repositorio.

El diagrama esquematico de conexión se presenta a continuación:

## Resumen del Software



Pettinari PM Milenium.

Sofware para la placa de desarrollo Arduino UNO, desarrollado en Arduino IDE bajo las librerias propias de Arduino.
