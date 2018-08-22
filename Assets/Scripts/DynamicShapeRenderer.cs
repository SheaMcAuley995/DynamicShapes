using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class DynamicShapeRenderer : MonoBehaviour {

    [Range(3, 32)]
    public int points;
    public LineRenderer lineRenderer;

    public float radius = 1;
    public float renderSpeed = 1;

    private int vertextPoints;
    public LinkedList<DynamicVertex> vertices;


    public class DynamicVertex
    {
        public Vector3 position;
        public Vector3 target;
        public float speed;

        public DynamicVertex(Vector3 valueVertex, Vector3 valueTarget, float valueSpeed)
        {
            this.position = valueVertex;
            this.target = valueTarget;
            this.speed = valueSpeed;
        }
    }
    void Start() {
        vertices = new LinkedList<DynamicVertex>();
        vertices.AddLast(new DynamicVertex(Vector3.zero, Vector3.zero, 1));
        vertices.AddLast(new DynamicVertex(Vector3.zero, Vector3.zero, 1));
        vertices.AddLast(new DynamicVertex(Vector3.zero, Vector3.zero, 1));
    }

    void Update() {
        UpdateVertexList();

        foreach(var vertext in vertices)
        {
            vertext.position = Vector3.Lerp(vertext.position, vertext.target, Time.deltaTime * renderSpeed);
        }

        var renderList = new Vector3[vertices.Count + 2];
        int n = 0;
        foreach (var vert in vertices)
        {
            renderList[n++] = vert.position;
        }

        renderList[renderList.Length - 2] = renderList[0];
        renderList[renderList.Length - 1] = renderList[1];
        lineRenderer.positionCount = renderList.Length;
        lineRenderer.SetPositions(renderList);
    }

    private void UpdateVertexList()
    {
        int vertextPoints = vertices.Count;
        int i = 0;

        foreach (var point in vertices)
        {

            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            //vertices
            point.target = new Vector3(x, 0, y) * radius;
            i++;
        }
        for (i = vertextPoints; i < points; ++i)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            vertices.AddLast(new DynamicVertex(vertices.First.Value.position, new Vector3(x, 0, y) * radius, vertices.First.Value.speed));

        }
        while (vertices.Count > points)
        {
            vertices.RemoveLast();
        }
    }
    private void OnDrawGizmosSelected()
    {
        foreach(var point in vertices)
        {
            Gizmos.DrawSphere(point.target, 0.5f / (0.2f * vertices.Count));
        }
    }
}
