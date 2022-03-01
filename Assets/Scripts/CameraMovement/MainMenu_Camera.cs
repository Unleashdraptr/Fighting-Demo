using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Camera : MonoBehaviour
{
    //Will rotate the camera around slowly to make the scene feel more alive
    void Update()
    {
        transform.Rotate(0, 0.01f, 0);

    }
}
