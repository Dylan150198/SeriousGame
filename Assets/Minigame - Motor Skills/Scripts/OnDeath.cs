using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public GameObject effect;
    // Start is called before the first frame update

    private void OnDestroy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        
    }
 
}
