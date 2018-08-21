using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DynamicShapeRenderer : MonoBehaviour {

    [Range(3, 32)]
    public int points;
    public LineRenderer lineRenderer;

    public float radius = 1;

    private int vertextPoints;
    public LinkedList<DynamicVertex> vertices;


    public class DynamicVertex
    {
        public Vector3 vertex;
        public Vector3 target;
        public float speed;
    }
	void Start () {
		
	}

	void Update () {
        vertices = new Vector3[points + 2];
        for(int i = 0; i < vertices.Length; i++)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            vertices[i] = new Vector3(x, 0, y) * radius;

        }
        vertices[vertices.Length - 2] = vertices[0];
        vertices[vertices.Length - 1] = vertices[1];
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);
	}

    private void OnDrawGizmosSelected()
    {
        foreach(Vector3 verts in vertices)
        {
            Gizmos.DrawSphere(verts, 0.5f / (0.15f * vertices.Length));
        }
    }
}
