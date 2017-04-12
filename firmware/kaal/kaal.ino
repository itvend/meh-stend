#include <HX711.h>
#include <stdio.h>

#define DOUT  3
#define CLK  2

#define DOUT2  5
#define CLK2  4

HX711 channel1(DOUT, CLK);
HX711 channel2(DOUT2, CLK2);

struct dataBayLoad{
  long channel_a_raw;
  long channel_b_raw;
  uint16_t temp;
  uint16_t rpm;
  
} *pData;

long number1 = 0, number2 = 0;
byte buffer = 0x0;

void setup() {
  
  pinMode(7, OUTPUT);
  //pinMode(13, OUTPUT);
  digitalWrite(7, 1);
  
  Serial.begin(115200);
  Serial.setTimeout(10);
  pData = (struct dataBayLoad *)malloc(sizeof(struct dataBayLoad));

}

void loop() {
  if (Serial.available()) {
    Serial.readBytes(&buffer, 1);
      if(buffer == 0x37){
        Serial.print(analogRead(1));
      }
  
      if(buffer == 0x35){
        number1 = channel1.read();
        Serial.write( (uint8_t *) &number1, 4);
      }
  
      if(buffer == 0x36){
        number2 = channel2.read();
        Serial.write( (uint8_t *) &number2, 4);
      }

      if(buffer == 0x40){
        
          pData->channel_a_raw = channel1.read();
          pData->channel_b_raw = channel2.read();
          pData->temp = analogRead(1);
          pData->rpm = 0;
  
        Serial.write((uint8_t *)pData, sizeof(struct dataBayLoad));
      }

      Serial.flush();
      
    buffer = 0x0;
  }
    number1 = 0;
    number2 = 0;
}

