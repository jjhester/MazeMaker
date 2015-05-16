using UnityEngine;
using System.Collections;

public abstract class MazeAlgorithm {
   protected bool[][] mazeGrid;
   protected int width, height;

   abstract public void generate ( int width, int height );

   public bool[][] Maze {
	 get { return mazeGrid;}
   }
	
}

