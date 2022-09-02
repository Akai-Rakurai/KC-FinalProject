using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenartor : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    Color[] Colors;
    public Gradient gradient;

    public int Xsize = 20;
    public int Zsize = 20;

    float minterrainheight;
    float maxterrainheight;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }
    void CreateShape()
    {
        vertices = new Vector3[(Xsize + 1) * (Zsize + 1)];

        for (int i = 0, z = 0; z <= Zsize; z++)
        {
            for (int x = 0; x <= Xsize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 5f;
                vertices[i] = new Vector3(x, y, z);

                if(y > maxterrainheight)
                    maxterrainheight = y;
                if(y < minterrainheight)
                    minterrainheight = y;

                i++;
            }
        }
        int vert = 0;
        int tris = 0;

        triangles = new int[Xsize * Zsize * 6];

        for (int z = 0; z < Xsize; z++)
        {
            for (int x = 0; x < Xsize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + Xsize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + Xsize + 1;
                triangles[tris + 5] = vert + Xsize + 2;

                vert++;
                tris += 6;

            }
            vert++;
        }
        Colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= Zsize; z++)
        {
            for (int x = 0; x <= Xsize; x++)
            {
                float height = Mathf.InverseLerp(minterrainheight, maxterrainheight, vertices[i].y);
                Colors[i] = gradient.Evaluate(height);
                i++;
            }

        }
    }
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = Colors;

        mesh.RecalculateNormals();

        mesh.RecalculateBounds();
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
}
