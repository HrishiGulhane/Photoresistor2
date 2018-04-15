const int sensorPin = 0;
const int red = 9;
const int yellow = 10;
const int green = 11;
char myCol[20];
int tinyDelay;
int smallDelay;
int bigDelay;
int flag;



// We'll also set up some global variables for the light level a calibration value and     
//and a raw light value
int lightCal;
int lightVal = 0;


void setup()
{
  Serial.begin(9600);
  Serial.setTimeout(13);
  // We'll set up the LED pin to be an output.
  pinMode(red, OUTPUT);
  pinMode(yellow, OUTPUT);
  pinMode(green, OUTPUT);

  lightCal = analogRead(sensorPin);
  //we will take a single reading from the light sensor and store it in the lightCal        
  //variable. This will give us a prelinary value to compare against in the loop
  tinyDelay = 60;
  smallDelay = 150;
  bigDelay = 300;
  flag = 1;
}


void loop()
{
  
  if (flag == 1)
  {
    photoresistor();
  }
  else
  {
    int lf = 10;
    Serial.readBytesUntil(lf, myCol, 1);
  
    if (strcmp(myCol, "r") == 0)
    {
      digitalWrite(red, HIGH);

    }
    else if (strcmp(myCol, "y") == 0 && flag==2)
    {
      //digitalWrite(yellow, HIGH);
      BlinkYellow();
      
      
    }
    else if (strcmp(myCol, "g") == 0)
    {
      digitalWrite(green, HIGH);
    }
  }




}

void photoresistor()
{
  if ((lightCal - analogRead(sensorPin) > 100) || (lightCal - analogRead(sensorPin) < -100))
  {
    //Take a reading using analogRead() on sensor pin and store it in lightVal
    lightVal = analogRead(sensorPin);

    Serial.println(lightVal);
    //Serial.write(analogRead(sensorPin));
    Serial.flush();
    BlinkRed();
    flag = 2;
    //delay(100);
    //print out the value of the analogRead for the sensor

    //digitalWrite(red, HIGH);
    //digitalWrite(yellow, HIGH);
    //digitalWrite(green, HIGH);
  }
}

void BlinkRed()
{
  for (int i = 0;i < 4; i++)
  {
    digitalWrite(red, HIGH);
    delay(bigDelay);
    for (int j = 0; j < 4; j++)
    {
      digitalWrite(red, LOW);
      delay(smallDelay);
    }
  }

}

void BlinkYellow()
{
  for (int i = 0;i < 6; i++)
  {Serial.println("here");
    digitalWrite(yellow, HIGH);
    delay(smallDelay);
    for (int j = 0; j <6; j++)
    {
      digitalWrite(yellow, LOW);
      delay(tinyDelay);
    }
    flag=3;
  }
}



