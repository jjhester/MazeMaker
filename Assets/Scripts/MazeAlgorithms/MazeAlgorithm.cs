using UnityEngine;
using System.Collections;

public abstract class MazeAlgorithm {
   protected Perimeter[,] mazeGrid;
   protected int width, height;

   abstract public void Generate ( GameObject[,] mazeObject );

}

