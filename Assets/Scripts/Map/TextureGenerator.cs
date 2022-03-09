using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator 
{
    //Generates the texture used on the mesh with the gradient used in the colourmap
    public static Texture2D TextureFromColourMap(Color[] colourmap, int width, int length)
    {
        Texture2D texture = new Texture2D(width, length);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourmap);
        texture.Apply();
        return texture;
    }
}
