using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordered : MonoBehaviour {

	public Color borderColor;
	public Color innerColor;

	private Mesh mesh;
	private Material mat;

	private void Start()
	{
		mesh = GetComponent<MeshFilter>().mesh;
		RenderBorders.instance.AddBordered(this);
		mat = GetComponent<Renderer>().material;
		mat.color = innerColor;
	}

	public Mesh GetMesh()
	{
		return mesh;
	}
	
}
