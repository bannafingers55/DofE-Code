int score;
int snakeLen;

int widthMid = 400;
int heightMid = 300;
int xPos;
int yPos;

float lastSpeedY;
float lastSpeedX;

float ySpeed = 10;
float xSpeed = 10;

float treatX;
float treatY;


boolean isCollected = true;

class Snake {
  int lengthS = 1;
  int currentBackPos;
  
  
}
class Treat {
  float xPos;
  float yPos;
  
  int width = 5;
  int height = 5;
  boolean draw = true;
  
  void drawTreat(float xPosi, float yPosi) {
    rect(xPosi, yPosi, width, height);
  }
  
  void isCollected() {
    isCollected = true;
    draw = false;
    
  }
}

void setup() {
  size(800, 600);
  xPos = widthMid;
  yPos = heightMid;
  
}

void draw() {
  background(0);
  if (keyPressed) {
    if (key == 'w') {
      lastSpeedY = ySpeed * -1;
      lastSpeedX = 0;
    }
    if (key == 's') {
      lastSpeedY = ySpeed;
      lastSpeedX = 0;
    }
    if (key == 'a') {
      lastSpeedX = xSpeed * -1;
      lastSpeedY = 0;
    }
    if (key == 'd') {
      lastSpeedX = xSpeed;
      lastSpeedY = 0;
    }
  }
  xPos += lastSpeedX;
  yPos += lastSpeedY;
  
  if (xPos > width) {
    xPos = 0;
  }
  if (xPos < 0) {
    xPos = width;
  }
   if (yPos > height) {
     yPos = 0;
  }
  if (yPos < 0) {
    yPos = height;
  }
  Treat treat = new Treat();
  if (isCollected) {
    treatX = random(800);
    treatY = random(600);
    isCollected = false;
  }
  rect(xPos, yPos, 10, 10);
  treat.drawTreat(treatX, treatY);
  
}
