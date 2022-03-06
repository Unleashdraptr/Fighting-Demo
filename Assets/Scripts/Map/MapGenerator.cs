using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public int SeedNum;
    public void Start()
    {
        SeedNum = Variables.SeedNumber;
        GenerateMap(SeedNum);
    }
    //Size of map needs to calculate the mesh
    const int MapChunkSize = 255;

    //Map the map more terrain like
    float MeshMult = 8f;

    //Repeat the same noise
    public Gradient MeshGradient;
    Color[] colourMap;
    //How dramatic the terrain changes
    public AnimationCurve MeshHeight;
    
    public void GenerateMap(int SeedNum)
    {
        //Generates the Noise Map with the use of the seed and the size
        float[,] NoiseMap = PerlinNoise.GenerateNoiseMap(MapChunkSize, MapChunkSize, SeedNum);

        //Generate the colours array in the size of each unit of the map and then cycles through the array asigning a number from 0 to 1f
        colourMap = new Color[MapChunkSize * MapChunkSize];
        for( int y = 0; y < MapChunkSize; y++)
        {
            for(int x = 0; x < MapChunkSize; x++)
            {
                float currentHeight = NoiseMap[x, y];
                for(int i = 0; i < 1; i++)
                {
                    if (currentHeight <= 1)
                    {
                       colourMap[y * MapChunkSize + x] = MeshGradient.Evaluate(currentHeight);
                       break;
                    }
                }    

            }
        }
        //Draw it on the Mesh map
        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawMesh(MeshGenerator.GenerateTerrainMesh(NoiseMap, MeshMult, MeshHeight), TextureGenerator.TextureFromColourMap(colourMap, MapChunkSize, MapChunkSize));  
    }
}