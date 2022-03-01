using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public static float[,] GenerateNoiseMap(int width, int length, int seed)
    {
        //Array that stores all the numbers of the Noise
        float[,] NoiseMap = new float[width, length];

        System.Random prng = new System.Random(seed);

        //How many times itll run the Noise function allowing finer detail
        Vector2[] OctaveOffsets = new Vector2[5];
        for (int i = 0; i < 5; i++)
        {
            float offsetX = prng.Next(-100000, 100000);
            float offsetY = prng.Next(-100000, 100000);
            OctaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        float maxheight = float.MinValue;
        float minheight = float.MaxValue;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                float amplitude = 1;
                float freuqency = 1;
                float noiseHeight = 0;
                //How many times to make to cycle thorugh NoiseMap with a new noise Map
                for (int i = 0; i < 5; i++)
                {
                    float Xcord = x / 50f * freuqency + OctaveOffsets[i].x;
                    float Ycord = y / 50f * freuqency + OctaveOffsets[i].y;

                    float PerlinValue = Mathf.PerlinNoise(Xcord, Ycord) * 2 - 1;
                    noiseHeight += PerlinValue * amplitude;

                    //Make each noise map made have less impact and be more detailed
                    amplitude *= 0.4f;
                    freuqency *= 2f;
                }
                //Bounds to between 0 and 1
                if (noiseHeight > maxheight)
                {
                    maxheight = noiseHeight;
                }
                if (noiseHeight < minheight)
                {
                    minheight = noiseHeight;
                }
                NoiseMap[x, y] = noiseHeight;
            }
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                NoiseMap[x, y] = Mathf.InverseLerp(minheight, maxheight, NoiseMap[x, y]);
            }
        }
        return NoiseMap;
    }
}