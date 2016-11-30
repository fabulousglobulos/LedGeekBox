# LedGeekBox
WPF UI for  piloting 10 max7219 led matrix
the WPF application is the processor for the rendering part.
Main features:
- quick access from button, for common scenario
- scenario mode with scripts
- edit mode manually, can be save later in a xml file and be reused by MOVIE scenario
- Simulation mode : won't send data to arduino with XML middleware

## Arduino part
the c++ code is also available. Please use arduino IDE for compiling and transferring. This application starts listening the serial port and receive tram. Each tram start with an A char and stop with an B char.
Inside it contains  8 ints (each row) per matrice display. Since we have 10 matrices previous step is repeated 10 times.

Note: applications works with official arduino (tested on arduino uno) and also arduino like (cheap arduino fake , like ATmega328).

In terme of hardaware, since max7219 support up to 8 matrice per row. The source code have two instance of ledcontrol class (each 5 matrices)
