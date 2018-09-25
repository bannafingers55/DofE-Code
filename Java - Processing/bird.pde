 long timeFalling;
float grav = 1;

boolean notPassed = true;

class Tube {
  float height;
  float width;
  float movementSpeed = 10;
  float xpos = 800;
  int ypos;

}

class Bird {
  int speed = 10;
  int ypos;
  int yspeed = 10;
  int mass = 5;
  int flyingForce = 100;
  
  int timer;
  void fly() {
    if (keyPressed) {
      ypos += yspeed;
      
    }
  }
}
Bird player = new Bird();
Tube tube = new Tube();
Tube tubeB = new Tube();

void setup() { 
  size(800,600);
  player.ypos = 300;
}
void draw(){
  background(0);
  
  
  if(keyPressed) {
    float upForce = player.flyingForce / 5;
    player.ypos -= upForce;
  } else {
    player.ypos += 4;
  }
  
  
  if (player.ypos == 600 || player.ypos == 0) {
    exit();
  }
  
  if (notPassed) {
    tube.height = random(100, 300);
    tubeB.height = random(100, 300);
    notPassed = false;
  }
  
  tube.xpos = tube.xpos - tube.movementSpeed;
  tubeB.xpos = tubeB.xpos - tubeB.movementSpeed;
  
  if (tube.xpos == 0) {
    notPassed = true;
    tube.xpos = 800;
    tubeB.xpos = 800;
  }
  
  if (tube.xpos == 300 && player.ypos == 0 + tube.height) {
    exit();
  }
  
  
  rect(tube.xpos, 600, 100, -tubeB.height);
  
  rect(tube.xpos, 0, 100, tube.height);
  
  ellipse(300, player.ypos, 50, 50);
}
