using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordered : MonoBehaviour {

	public Color color;

	private Mesh mesh;

	private void Start()
	{
		mesh = GetComponent<MeshFilter>().mesh;
		RenderBorders.instance.AddBordered(this);
	}

	public Mesh GetMesh()
	{
		return mesh;
	}
	
}
