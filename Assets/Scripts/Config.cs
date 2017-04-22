using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {
  public const float TIME_SCALE = 1;
	public const int MAX_ITEMS = 100;
  public static Color[] MainColors = new Color[] { 
    new Color(255, 236, 109), 
    new Color(0, 232, 197), 
    new Color(255, 180, 96), 
    new Color(175, 96, 232), 
    new Color(72, 139, 255)
  };
}

public enum Layer {
  World = 8,
  Item = 9
}

public enum Scene {
  Main
}

public enum Item {
	Item01,
  Item02,
  Item03,
  Item04,
  Item05
}