using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupList : MonoBehaviour
{
    int i = 0;

    public GameObject[] spheres = new GameObject [4];
    public bool allChanged = false;

    private void Update()
    {
        ReVerify();
    }

    public void ReVerify()
    {
        foreach (GameObject sphere in spheres)
        {
            if (sphere.GetComponent<Initialised>().changed == true)
            {
                i += 1;
            }
        }

        if (i == 4)
        {
            allChanged = true;
            i = 0;

        }
        else
            i = 0;
    }
}
