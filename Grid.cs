using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour {

	public int GRID_POINTS = 100;

	//Declare 2D array to store Y values
	private float [,] dataY;
	//Declare array of vertices on grid
	private Vector3[] vertices;

	private void Start(){
		dataY = new float[GRID_POINTS, GRID_POINTS];
		vertices = new Vector3[(GRID_POINTS) * (GRID_POINTS)];
		//Create Y value for each X, Z coordinate, and add 3D position for each vertex in vertices array
		for (int i = 0, x = 0; x < GRID_POINTS; x++) {
			for (int z = 0; z < GRID_POINTS; z++, i++) {
				dataY [x, z] = -((x - GRID_POINTS / 2) * (x - GRID_POINTS / 2) + (z - GRID_POINTS / 2) * (z - GRID_POINTS / 2)) / 500f + 10f;
				vertices [i] = new Vector3 (x, dataY [x, z], z);
			}
		}  
	}

	private void OnDrawGizmos(){

		if(vertices == null){
			return;
		}
		//Draw spheres for each vertex on grid
		Gizmos.color = Color.red;
		for(int i = 0; i < vertices.Length; i++){
			Gizmos.DrawSphere (vertices [i], 0.1f);
		}
	}

}




