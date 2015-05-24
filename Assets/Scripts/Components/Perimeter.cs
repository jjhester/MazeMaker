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
	 set {
	    if (value != walls [(int)wallDirection]) {
		  walls [(int)wallDirection] = value;
		  if (value) {
			AddWall(wallDirection);
		  } else {
			RemoveWall(wallDirection);
		  }
	    }
	 }
   }
   public int Sides {
	 get { return walls.Length;}
   }
   private void AddWall ( Direction wallDirection ) {
	 float yRotate = ((int)wallDirection % 2 == 0)? 0: 90;
	 float z = (float)((yRotate > 0)? 0: ((int)wallDirection > 0)? -.5 : .5);
	 float x = (float)((yRotate > 0)? ((int)wallDirection > 1)? -.5 : .5 : 0);

	 Vector3 parentPosition = this.gameObject.transform.position;
	 Vector3 position = new Vector3(parentPosition.x + x, parentPosition.y, parentPosition.z + z);
	 Vector3 rotation = new Vector3(0f,yRotate,0f);
	 GameObject curWall = Instantiate(wallObject, position, Quaternion.identity) as GameObject;
	 curWall.transform.Rotate(rotation);
	 curWall.gameObject.transform.parent = this.gameObject.transform;
	 curWall.gameObject.name = string.Format("Wall{0}", wallDirection);
   }
	private void RemoveWall (Direction wallDirection) {
		Transform curWall = this.gameObject.transform.Find(string.Format("Wall{0}", wallDirection));
		if (curWall != null) GameObject.Destroy(curWall.gameObject);
	}
   void Start () {
//	 //By default has all four walls
//	this[Direction.NORTH] = true;
//     this[Direction.EAST] = true;
//     this[Direction.SOUTH] = true;
//     this[Direction.WEST] = true;
   }
}

