using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator 
{
    public static Texture2D TextureFromColourMap(Color[] colourmap, int width, int length)
    {
        Texture2D texture = new Texture2D(width, length);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourmap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int length = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, length);

        Color[] colourmap = new Color[width * length];
        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourmap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        return TextureFromColourMap(colourmap, width, length);
    }
}
