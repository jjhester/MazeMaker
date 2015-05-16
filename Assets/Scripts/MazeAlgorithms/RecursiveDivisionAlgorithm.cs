using UnityEngine;
using System.Collections;

public enum Orientation {
   HORIZONTAL,
   VERTICAL
}

public class RecursiveDivisionAlgorithm : MazeAlgorithm {
	#region implemented abstract members of MazeAlgorithm
   public override void generate ( int width, int height ) {
		throw new System.NotImplementedException();
	}
	#endregion
	
}
