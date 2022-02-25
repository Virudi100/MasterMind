using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            other.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
            Destroy(gameObject);
        }
    }
}
