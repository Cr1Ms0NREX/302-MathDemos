void setup() {
  size(500, 500);
}

void draw() {
  background(0);
  
  // calc the percent:
  float p = mouseX / (float)width;
  
  // calc the diameter:
  float d = lerp(50, 500, p);
  
  // what to draw
  ellipse(width/2, height/2, d, d);
}
