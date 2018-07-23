using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBorders : MonoBehaviour
{

	public static RenderBorders instance;

	public Material mat;

	private List<Bordered> bordereds;

	private void Awake()
	{
		instance = this;
		bordereds = new List<Bordered>();
	}

	public void AddBordered(Bordered bordered)
	{
		bordereds.Add(bordered);
	}

	private void OnPostRender()
	{
		RenderBordereds();
	}

	private void OnDrawGizmos()
	{
		RenderBordereds();
	}

	private void RenderBordereds()
	{
		if (bordereds == null) return; //in edit mode

		foreach (Bordered bordered in bordereds)
		{
			RenderBordered(bordered);
		}
	}

	private void RenderBordered(Bordered bordered)
	{
		Color color = bordered.borderColor;
		Mesh mesh = bordered.GetMesh();
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.GetTriangles(0);
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 v0 = vertices[triangles[i]];
			Vector3 v1 = vertices[triangles[i + 1]];
			Vector3 v2 = vertices[triangles[i + 2]];

			Vector3 p0 = bordered.transform.position + Vector3.Scale(v0, bordered.transform.lossyScale);
			Vector3 p1 = bordered.transform.position + Vector3.Scale(v1, bordered.transform.lossyScale);
			Vector3 p2 = bordered.transform.position + Vector3.Scale(v2, bordered.transform.lossyScale);
			
			DrawLine(p0, p1, color);
			DrawLine(p1, p2, color);
			DrawLine(p2, p0, color);
		}
	}

	/*private void DrawIfEdge(Vector3 start, Vector3 end, Color color)
	{
		
	}*/

	private void DrawLine(Vector3 start, Vector3 end, Color color)
	{
		GL.Begin(GL.LINES);
		mat.SetPass(0);
		mat.color = color;
		//GL.Color(color);
		GL.Vertex(start);
		GL.Vertex(end);
		GL.End();
	}
}
