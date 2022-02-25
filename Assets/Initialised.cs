using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialised : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    
}
