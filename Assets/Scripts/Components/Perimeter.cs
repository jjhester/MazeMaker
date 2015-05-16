using UnityEngine;
using System.Collections;

public enum Direction {
   NORTH = 0,
   EAST = 1,
   SOUTH = 2,
   WEST = 3
}

public class Perimeter : MonoBehaviour {
   public GameObject wallObject;
   private bool[] walls = new bool[4];
   public bool this [Direction wallDirection] {
	 get { return walls [(int)wallDirection];}
	 set { walls [(int)wallDirection] = value;}
   }
}

