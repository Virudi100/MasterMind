using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialised : MonoBehaviour
{
    public int indexColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            print("set red color");
            indexColor = 1;
        }

        if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            print("set blue color");
            indexColor = 2;
        }

        if (gameObject.GetComponent<Renderer>().material.color == Color.magenta)
        {
            print("set Magenta color");
            indexColor = 3;
        }

        if (gameObject.GetComponent<Renderer>().material.color == Color.green)
        {
            print("set green color");
            indexColor = 4;
        }
    }


}
