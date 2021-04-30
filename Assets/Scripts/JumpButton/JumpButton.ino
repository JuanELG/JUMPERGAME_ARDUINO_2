//Declare pins that buttons are connected to.
const int buttonPin1 = 7;

void setup() 
{
  //Start the serial
  Serial.begin(9600);
  //Configure the pins as output.
  pinMode(buttonPin1, INPUT);

  digitalWrite(buttonPin1, HIGH);
}

void loop() 
{
   //Read the state of the button
   if(digitalRead(buttonPin1) == LOW)
   {
      //print this line if state is HIGH.
      Serial.write(1);
      Serial.flush();
      delay(20);
   }
   else
   {
      Serial.write(0);
      Serial.flush();
      delay(20);
   }
}
