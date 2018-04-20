const int buttonPin = 3;
const int ledPin =  2;
const int ledPin2 = 4;
const int buttonPin2 = 5;

int buttonState = 0;
int button2State = 0;

void setup() {

  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  pinMode(buttonPin, INPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(buttonPin2, INPUT);

}

void loop() {

  buttonState = digitalRead(buttonPin);
  button2State = digitalRead(buttonPin2);
  
  if (buttonState == HIGH && button2State == HIGH) {
    digitalWrite(ledPin, HIGH);
    digitalWrite(ledPin2, HIGH);
    Serial.print("1");
  } else if(buttonState == HIGH) {
    digitalWrite(ledPin, HIGH);
    digitalWrite(ledPin2, LOW);
    Serial.print("2");
  } else if(button2State == HIGH) {
    digitalWrite(ledPin, LOW);
    digitalWrite(ledPin2, HIGH);
    Serial.print("3");
  } else {
    digitalWrite(ledPin, LOW);
    digitalWrite(ledPin2, LOW);
    Serial.print("0");
  }

  delay(100);

}
