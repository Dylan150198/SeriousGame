using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCamera : MonoBehaviour
{

    void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
