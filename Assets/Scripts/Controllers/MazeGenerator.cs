﻿using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour {

   public GameObject tileObject;
   public byte width, height;
   private GameObject[,] tiles;
   public void LoadTiles () {
	 //Create the board table
	 this.tiles = new GameObject[height, width];
	 for (byte r = 0; r < height; r++) {
	    for (byte c = 0; c < width; c++) {
		  Vector3 position = new Vector3(c, 0, height - r);
		  GameObject curTile = Instantiate(tileObject, position, Quaternion.identity) as GameObject;
		  curTile.gameObject.transform.parent = this.gameObject.transform;
		  curTile.gameObject.name = string.Format("Tile({0},{1})", r, c);
		  this.tiles [r, c] = curTile;
		  Debug.Log(this.tiles [r, c]);
		  //Handle walls
		  Perimeter walls = curTile.GetComponent<Perimeter>();
		  walls [Direction.NORTH] = r == 0;
		  walls [Direction.SOUTH] = r == height - 1;
		  walls [Direction.WEST] = c == 0;
		  walls [Direction.EAST] = c == width - 1;
	    }
	 }
   }

   // Use this for initialization
   void Start () {
	 LoadTiles();
   }
	
   // Update is called once per frame
   void Update () {
	
   }
   void CreateRecursiveMaze ( int width, int height ) {

   }
}
