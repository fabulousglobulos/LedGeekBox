#include "LedControl.h"
#include <binary.h>
#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);



//data - clk -  !cs
LedControl lc = LedControl(8, 9, 10, 3); //LedControl(12,11,10,1);

//unsigned long delaytime = 1000;


String cmd = "";


void setup() {
  // put your setup code here, to run once:
  lcd.begin(16, 2);
  lcd.print("Hello :");

  lc.shutdown(0, false);
  lc.setIntensity(0, 8);/* Set the brightness to a medium values */
  lc.clearDisplay(0);  /* and clear the display */

  lc.shutdown(1, false); // turn off power saving, enables display
  lc.setIntensity(1, 8); // sets brightness (0~15 possible values)
  lc.clearDisplay(1);//

  lc.shutdown(2, false); // turn off power saving, enables display
  lc.setIntensity(2, 8); // sets brightness (0~15 possible values)
  lc.clearDisplay(2);//

  Serial.begin(115200);
}



void loop() {

  while (true)
  {
    if (Serial.available() > 0 )
    {
      char c = Serial.read();

      if ( c == 'A') //start a new line
      {
        cmd = "";
        lcd.setCursor(0, 1);
        lcd.print("A ");
      }
      else
      {
        if ( c == 'B')
        { //end now we receive the full line
          lcd.setCursor(0, 1);
          lcd.print(" B");
           SplitItAndDisplay();
        }
        else
        {
          cmd += c;
         
        }
      }
    }
  }
}

void SplitItAndDisplay()
{
  int separator1 = cmd.indexOf('+');
  int separator2 = cmd.indexOf('+', separator1 + 1);
  int separator3 = cmd.indexOf('+', separator2 + 1);
  int separator4 = cmd.indexOf('+', separator3 + 1);
  int separator5 = cmd.indexOf('+', separator4 + 1);

  String idLine = cmd.substring(0, separator1);
  String max1 = cmd.substring(separator1 + 1, separator2);
  String max2 = cmd.substring(separator2 + 1, separator3); //
  String max3 = cmd.substring(separator3 + 1, separator4);
  String max4 = cmd.substring(separator4 + 1, separator5); //
  String max5 = cmd.substring(separator5 + 1, cmd.length()); //

  ManageMax(max1, 0 );
  ManageMax(max2, 1 );
  ManageMax(max3, 2 );

  delay(100);
}


void ManageMax(String data, int id)
{
  int separator1 = data.indexOf('-');
  int separator2 = data.indexOf('-', separator1 + 1);
  int separator3 = data.indexOf('-', separator2 + 1);
  int separator4 = data.indexOf('-', separator3 + 1);
  int separator5 = data.indexOf('-', separator4 + 1);
  int separator6 = data.indexOf('-', separator5 + 1);
  int separator7 = data.indexOf('-', separator6 + 1);
  int separator8 = data.indexOf('-', separator7 + 1);

  String idMax = data.substring(0, separator1);

  String row1 = data.substring(separator1 + 1, separator2);
  String row2 = data.substring(separator2 + 1, separator3);
  String row3 = data.substring(separator3 + 1, separator4);
  String row4 = data.substring(separator4 + 1, separator5);
  String row5 = data.substring(separator5 + 1, separator6);
  String row6 = data.substring(separator6 + 1, separator7);
  String row7 = data.substring(separator7 + 1, separator8);
  String row8 = data.substring(separator8 + 1, data.length());

  lc.setRow(id, 0, row1.toInt());
  lc.setRow(id, 1, row2.toInt());
  lc.setRow(id, 2, row3.toInt());
  lc.setRow(id, 3, row4.toInt());
  lc.setRow(id, 4, row5.toInt());
  lc.setRow(id, 5, row6.toInt());
  lc.setRow(id, 6, row7.toInt());
  lc.setRow(id, 7, row8.toInt());
}


