#include "LedControl.h"
#include <binary.h>
#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);



//data - clk -  !cs
LedControl lc1 = LedControl(8, 9, 10, 5); //LedControl(12,11,10,1);


LedControl lc2 = LedControl(6, 7, 13, 5); //LedControl(12,11,10,1);

//unsigned long delaytime = 1000;


String cmd = "";


void setup() {
  // init LCD
  lcd.begin(16, 2);
  lcd.print("Hello :");

  ///// init first row
  lc1.shutdown(0, false);
  lc1.setIntensity(0, 8);/* Set the brightness to a medium values */
  lc1.clearDisplay(0);  /* and clear the display */

  lc1.shutdown(1, false); // turn off power saving, enables display
  lc1.setIntensity(1, 8); // sets brightness (0~15 possible values)
  lc1.clearDisplay(1);//

  lc1.shutdown(2, false); // turn off power saving, enables display
  lc1.setIntensity(2, 8); // sets brightness (0~15 possible values)
  lc1.clearDisplay(2);//

  lc1.shutdown(3, false); // turn off power saving, enables display
  lc1.setIntensity(3, 8); // sets brightness (0~15 possible values)
  lc1.clearDisplay(3);//

  lc1.shutdown(4, false); // turn off power saving, enables display
  lc1.setIntensity(4, 8); // sets brightness (0~15 possible values)
  lc1.clearDisplay(4);//

  ///// init second row
  lc2.shutdown(0, false);
  lc2.setIntensity(0, 8);/* Set the brightness to a medium values */
  lc2.clearDisplay(0);  /* and clear the display */

  lc2.shutdown(1, false); // turn off power saving, enables display
  lc2.setIntensity(1, 8); // sets brightness (0~15 possible values)
  lc2.clearDisplay(1);//

  lc2.shutdown(2, false); // turn off power saving, enables display
  lc2.setIntensity(2, 8); // sets brightness (0~15 possible values)
  lc2.clearDisplay(2);//

  lc2.shutdown(3, false); // turn off power saving, enables display
  lc2.setIntensity(3, 8); // sets brightness (0~15 possible values)
  lc2.clearDisplay(3);//

  lc2.shutdown(4, false); // turn off power saving, enables display
  lc2.setIntensity(4, 8); // sets brightness (0~15 possible values)
  lc2.clearDisplay(4);//


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
  int separator1 = cmd.indexOf('+'); //id1
  
  int separator2 = cmd.indexOf('+', separator1 + 1); // line 1 - max 1
  int separator3 = cmd.indexOf('+', separator2 + 1); // line 1 - max 2
  int separator4 = cmd.indexOf('+', separator3 + 1); // line 1 - max 3
  int separator5 = cmd.indexOf('+', separator4 + 1); // line 1 - max 4
  int separator6 = cmd.indexOf('+', separator5 + 1); // line 1 - max 5
  
  int separator7 = cmd.indexOf('+', separator6 + 1); //id2
  int separator8 = cmd.indexOf('+', separator7 + 1); // line 2 - max 1
  int separator9 = cmd.indexOf('+', separator8 + 1); // line 2 - max 2
  int separator10 = cmd.indexOf('+', separator9 + 1); // line 2 - max 3
  int separator11 = cmd.indexOf('+', separator10 + 1); // line 2 - max 4
  
  //int separator12 = cmd.indexOf('+', separator10 + 1); // line 1 - max 5


  String idLine1 = cmd.substring(0, separator1);
  
  String max1 = cmd.substring(separator1 + 1, separator2);
  String max2 = cmd.substring(separator2 + 1, separator3); 
  String max3 = cmd.substring(separator3 + 1, separator4);
  String max4 = cmd.substring(separator4 + 1, separator5); 
  String max5 = cmd.substring(separator5 + 1, separator6); // cmd.length()); //

  String  idLine2 = cmd.substring(separator6+1, separator7);

  String max6 = cmd.substring(separator7 + 1, separator8);
  String max7 = cmd.substring(separator8 + 1, separator9); 
  String max8 = cmd.substring(separator9 + 1, separator10);
  String max9 = cmd.substring(separator10 + 1, separator11); 
  String max10 = cmd.substring(separator11 + 1, cmd.length()); //
  

  ManageMax(lc1 , max1, 0 );
  ManageMax(lc1 , max2, 1 );
  ManageMax(lc1 , max3, 2 );
  ManageMax(lc1 , max4, 3 );
  ManageMax(lc1 , max5, 4 );

  ManageMax(lc2 , max6, 0 );
  ManageMax(lc2 , max7, 1 );
  ManageMax(lc2 , max8, 2 );
  ManageMax(lc2 , max9, 3 );
  ManageMax(lc2 , max10, 4 );


  delay(100);
}


void ManageMax(LedControl lc , String data, int id)
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


