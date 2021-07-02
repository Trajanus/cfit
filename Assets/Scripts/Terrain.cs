using System.Collections.Generic;
using UnityEngine;
using System;

public class Terrain : MonoBehaviour
{
    [SerializeField]
    protected LineRenderer lineRenderer;
    [SerializeField]
    protected bool addCollider = false;
    [SerializeField]
    protected EdgeCollider2D edgeCollider2D;
    [SerializeField]
    protected float Amplitude;
    [SerializeField]
    protected float Frequency;


    protected List<Vector2> points;

    public virtual LineRenderer LineRenderer
    {
        get
        {
            return lineRenderer;
        }
    }

    public virtual bool AddCollider
    {
        get
        {
            return addCollider;
        }
    }

    public virtual EdgeCollider2D EdgeCollider2D
    {
        get
        {
            return edgeCollider2D;
        }
    }

    public virtual List<Vector2> Points
    {
        get
        {
            return points;
        }
    }


    protected virtual void Awake()
    {
        if (lineRenderer == null)
        {
            CreateDefaultLineRenderer();
        }
        if (edgeCollider2D == null && addCollider)
        {
            CreateDefaultEdgeCollider2D();
        }
        points = new List<Vector2>();

        for (float x = 0.0f; x < 3000.0f; x += Frequency)
        {
            float yValue = (float)Math.Sin(x * 2) * Amplitude;
            points.Add(new Vector2(x, yValue));
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = points.Count;

        int index = 0;
        foreach(Vector2 point in points)
        {
            lineRenderer.SetPosition(index, new Vector3(point.x, point.y, 0));
            index++;
        }

        
        if (edgeCollider2D != null && addCollider && points.Count > 1)
        {
            edgeCollider2D.points = points.ToArray();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected virtual void CreateDefaultLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 2.0f;
        lineRenderer.endWidth = 2.0f;
        lineRenderer.useWorldSpace = true;
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
    }
}
