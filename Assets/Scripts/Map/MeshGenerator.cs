using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float HeightMult, AnimationCurve heightCurve)
    {
        //Variables
        int width = heightMap.GetLength(0);
        int length = heightMap.GetLength(1);
        float TopLeftX = (width - 1) / -2f;
        float TopLeftZ = (width - 1) / 2f;
        int SimpInc = 1;
        int verLine = (width - 1) / SimpInc + 1;

        //Mesh that was made
        MeshData meshData = new MeshData(verLine, verLine);
        int VerIndex = 0;

        for (int y = 0; y < length; y++)
        {
            for(int x = 0; x < width; x++)
            {
                //Compares the location to the height map and then builds the mesh accordingly
                meshData.vertices[VerIndex] = new Vector3(TopLeftX + x, heightCurve.Evaluate(heightMap[x, y])* HeightMult, TopLeftZ - y);
                meshData.uvs[VerIndex] = new Vector2(x / (float)width, y / (float)length);
                if (x < width - 1 && y <length - 1)
                {
                    meshData.AddTriangle(VerIndex, VerIndex + verLine + 1, VerIndex + verLine);
                    meshData.AddTriangle(VerIndex + verLine + 1, VerIndex, VerIndex + 1);
                }
                VerIndex++;
            }
        }
        return meshData;
    }
}

public class MeshData
{
    //Mesh's data it needs
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;

    int TriIndex;
    public MeshData(int Width, int Height)
    {
        vertices = new Vector3[Width * Height];
        uvs = new Vector2[Width * Height];
        triangles = new int[(Width - 1) * (Height - 1) * 6];
    }

    public void AddTriangle(int a, int b, int c)
    {
        //Building the triangles in the mesh
        triangles[TriIndex] = a;
        triangles[TriIndex+1] = b;
        triangles[TriIndex+2] = c;
        TriIndex += 3;
    }

    public Mesh CreateMesh()
    {
        //Creates the mesh 
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }
}
