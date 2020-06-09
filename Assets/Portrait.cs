using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
