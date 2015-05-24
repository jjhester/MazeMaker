using UnityEngine;
using System.Collections;

public enum MazeOrientation {
   HORIZONTAL,
   VERTICAL
}

public class RecursiveDivisionAlgorithm : MazeAlgorithm {
	#region implemented abstract members of MazeAlgorithm
   public override void Generate ( GameObject[,] mazeObject ) {
		mazeGrid = new Perimeter[mazeObject.GetLength(0),mazeObject.GetLength(1)];
		for (int r = 0; r < mazeGrid.GetLength(0); r++) {//Set outer walls
			for (int c = 0; c < mazeGrid.GetLength(1); c++) {
				mazeGrid[r,c] = mazeObject[r,c].GetComponent<Perimeter>();
				for (int w = 0; w < mazeGrid[r,c].Sides; w++) {
					if (
						(r != mazeGrid.GetLength(0)-1 && 
					 	 	c != 0) //Start Point
						|| (r != 0 && 
					    		c != mazeGrid.GetLength(1)-1) //End Point
						)
					mazeGrid[r,c][(Direction)w] = true;	//Have walls everywhere else
				}
			}
		}
		Divide(mazeGrid,0,0,mazeGrid.GetLength(0),mazeGrid.GetLength(1));
	}
	#endregion
	private void Divide (Perimeter[,] grid, int minX, int minY, int maxX, int maxY) {
		Debug.Log(string.Format("RECURSE x{0}-{1} y{2}-{3}",minX,maxX,minY,maxY));
//		if (maxX < 2 || maxY < 2) return ; //Base case
//		bool isHorizontal = Random.Range(0,1) == MazeOrientation.HORIZONTAL;
//
//		//Determine where to start the wall
//		int wallX = minX + (isHorizontal) ? 0 : Random.Range(0,maxX-2);
//		int wallY = minY + (isHorizontal) ? Random.Range(0,maxY-2) : 0;
//
//		//Determine where the passage should exist
//		int passX = wallX + (isHorizontal) ? Random.Range(0,maxX) : 0;
//		int passY = wallY + (isHorizontal) ? 0 : Random.Range(0,maxY);
//
//		//Determine direction of wall
//		int dirX = (isHorizontal)? 1 : 0;
//		int dirY = (isHorizontal)? 0 : 1;
//
//		//Set length and direction of wall
//		int len = (isHorizontal)? maxX : maxY;
//		Direction dir = (isHorizontal)? Direction.SOUTH : Direction.EAST;
//
//		for (int i=0; i < len; i++) {
//			if (wallX != passX || wallY != passY)
//				grid[wallX,wallY,(int)dir] = true;
//			wallX += dirX;
//			wallY += dirY;
//		}
		int deltaX = maxX - minX;
		int deltaY = maxY - minY;
		if (deltaX < 2 || deltaY < 2) {
			//Make a hallway
			if (deltaX > 1) {
				for (int x = minX; x < maxX-1; x++) {
					grid[minY, x][Direction.EAST] = false;
					grid[minY, x+1][Direction.WEST] = false;
				}
			} else if (deltaY > 1) {
				for (int y = minY; y < maxY-1; y++) {
					grid[y, minX][Direction.SOUTH] = false;
					grid[y+1, minX][Direction.NORTH] = false;
				}
			}
			return;
		}
		MazeOrientation wall;
		if (deltaX > deltaY) wall = MazeOrientation.VERTICAL;
		else if (deltaY > deltaX) wall = MazeOrientation.HORIZONTAL;
		else wall = (MazeOrientation) Random.Range(0,1); //Random orientation


		int passageX = Random.Range(minX, maxX - ((wall == MazeOrientation.VERTICAL)? 1 : 0));
		int passageY = Random.Range(minY, maxY - ((wall == MazeOrientation.HORIZONTAL)? 1 : 0));
		Debug.Log(string.Format("Orientation:{0} X:{1} Y:{2}",wall,passageX,passageY));

		if (wall == MazeOrientation.HORIZONTAL) {
			grid[passageY, passageX][Direction.SOUTH] = false;
			grid[passageY+1, passageX][Direction.NORTH] = false;

			Divide(grid, minX, minY, maxX, passageY+1);
			Divide(grid, minX, passageY+1, maxX, maxY);
		} else {//assume orientation is VERTICAL
			grid[passageY, passageX][Direction.EAST] = false;
			grid[passageY, passageX+1][Direction.WEST] = false;
			
			Divide(grid, minX, minY, passageX+1, maxY);
			Divide(grid, passageX+1, minY, maxX, maxY );
		}
	}
}
