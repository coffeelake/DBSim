#include <UTFT.h>
#include <URTouch.h>
#include <ArduinoJson.h>

//==== Creating Objects
UTFT    myGLCD(SSD1289, 38, 39, 40, 41); //Parameters should be adjusted to your Display/Schield model
URTouch  myTouch( 6, 5, 4, 3, 2);

//==== Defining Variables
extern uint8_t SmallFont[];
extern uint8_t BigFont[];
extern uint8_t SevenSegNumFont[];
extern uint8_t SixteenSegment40x60[];

const byte numChars = 32;
char receivedChars[numChars];

String currentGear="";

boolean newData = false;

void setup() {
  Serial.begin(250000);
  myGLCD.InitLCD();
  myGLCD.clrScr();
  myTouch.InitTouch();
  myTouch.setPrecision(PREC_MEDIUM);

}

void loop() {
   // myGLCD.clrScr();
    myGLCD.setBackColor(0, 0, 0); // Sets the background color of the area where the text will be printed to black

 // StaticJsonBuffer<200> jsonBuffer;
  //if (Serial.available())
  //{
   // String inputString=Serial.readString();
  
   // char json[inputString.length()+1];
   // inputString.toCharArray(json,inputString.length()+1);



    //JsonObject& root = jsonBuffer.parseObject(json);
    //if (!root.success()) {
    //  Serial.println("parseObject() failed");
    //  return;
   // }

    //const char* gear = root["gear"];
   //const char* currentlap = root["currentlap"];
//String content = "";
 // char character;
 //int index=0;
 //while(Serial.available()) {

      
   //   character = Serial.read();
    //  content.concat(character);
      
     
  //}

 recvWithStartEndMarkers();

   //  put your main code here, to run repeatedly:
  
    myGLCD.setFont(BigFont);
    myGLCD.print("Current Lap:", 5, 5); // Prints the string
    String time=((String)receivedChars).substring(2,12);
    time.replace("-","");
 myGLCD.print(time, 5, 25); // Prints the string


   String gear=((String)receivedChars).substring(0,1);
   if(currentGear!=gear)
   {
    myGLCD.setColor(0, 0, 0);
    myGLCD.print(currentGear, 140, 100);
    myGLCD.setColor(255, 255, 255);
    myGLCD.setFont(SixteenSegment40x60);
    myGLCD.print(gear, 140, 100);  
    currentGear=gear;
   }
  
  //}
delay(1);
}

void recvWithStartEndMarkers() {
    static boolean recvInProgress = false;
    static byte ndx = 0;
    char startMarker = '<';
    char endMarker = '>';
    char rc;
 
    while (Serial.available() > 0 && newData == false) {
        rc = Serial.read();
        if (recvInProgress == true) {
            if (rc != endMarker) {
                receivedChars[ndx] = rc;
                ndx++;
                if (ndx >= numChars) {
                    ndx = numChars - 1;
                }
            }
            else {
                receivedChars[ndx] = '\0'; // terminate the string
                recvInProgress = false;
                ndx = 0;
                newData = true;
            }
        }

        else if (rc == startMarker) {
            recvInProgress = true;
        }
        newData = false;
    }
}


