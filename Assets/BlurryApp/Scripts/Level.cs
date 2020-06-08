using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string objectiveText;
    public SubLevel[] subLevels;
    public SubLevel currentSubLevel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentSublevel(int index)
    {
        currentSubLevel = subLevels[index];
    }    

    public SubLevel getCurrentSubLevel()
    {
        return currentSubLevel;
    }
}
