using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

	public Material mat;
	private Vector3 startVertex;
	private Vector3 mousePos;

	private void Start()
	{
		//mat = GetComponent<MeshRenderer>().material;
	}

	private void Update()
	{
		mousePos = Input.mousePosition;
		if (Input.GetKeyDown(KeyCode.Space))
			startVertex = new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);

	}

	private void OnPostRender()
	{
		GL.PushMatrix();
		mat.SetPass(0);
		GL.LoadOrtho();
		GL.Begin(GL.LINES);
		GL.Color(Color.red);
		//GL.Vertex(startVertex);
		//GL.Vertex(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
		GL.Vertex(new Vector3(0, 0, 0));
		GL.Vertex(new Vector3(5, 5, 5));
		GL.End();
		GL.PopMatrix();
	}
}
