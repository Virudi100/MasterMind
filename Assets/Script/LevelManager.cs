using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int[] solution = new int[4];  // 1= Rouge      2=Bleu      3=Jaune     4=Vert
    private bool _firstLoopDone = false;
    [SerializeField] private GameObject[] solutionLine = new GameObject[4];
    private int b = 0;

    [SerializeField] private Camera cam;
    RaycastHit hit;

    [SerializeField] private bool aSpawn = false;
    private GameObject newSphere;

    private int roundIndex = 1;

    [Header("Line Rounds")]
    
    [SerializeField] private GameObject[][] linesArrays = new GameObject[10][];




    void Start()
    {
        SetSoluce();
        AssignColor();
    }

    private void Update()
    {
        MouseMove();
        IsInput();
        RoundManager();
    }

    private void IsInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (aSpawn == false && hit.collider.gameObject.CompareTag("Player"))
            {
                newSphere = Instantiate(hit.collider.gameObject, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z), Quaternion.identity);
                aSpawn = true;
            }
            
            if(newSphere != null) 
                newSphere.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(newSphere);
            aSpawn = false;
        }
    }

    private void MouseMove()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red * 10);
        
        Physics.Raycast(ray.origin, ray.direction, out hit);

    }

    private void SetSoluce()
    {
        foreach (int soluces in solution)
        {
            if (_firstLoopDone == false)
            {
                for (int a = 0; a < 4; a++)
                {
                    solution[a] = Random.Range(1, 4);

                    if (a == 4)
                    {
                        _firstLoopDone = true;
                    }
                }
            }
            else
            {
                foreach (int soluce in solution) //Pour chaque case
                {
                    int i = solution.Length;

                    if (solution[i] == solution[i - 1])
                    {
                        solution[i] = Random.Range(1, 4);

                    }
                }
            }
        }
    }

    private void AssignColor()
    {
        
        foreach (GameObject sphere in solutionLine)
        {
            if (solution[b] == 1)
            {
                solutionLine[b].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                print("red set");
            }
            if (solution[b] == 2)
            {
                solutionLine[b].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                print("blue set");
            }
            if (solution[b] == 3)
            {
                solutionLine[b].GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                print("yellow set");
            }
            if (solution[b] == 4)
            {
                solutionLine[b].GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                print("green set");
            }
            b++;
        }
    }

    private void RoundManager()
    {
        switch (roundIndex)
        {
            case 1:

                print("Round1");
                
                



                break;
        ////////////////////////////////////
            
            case 2:
                print("Round2");
                OneMoreRound();

                break;
        ///////////////////////////////////
            case 3:
                print("Round3");
                OneMoreRound();

                break;
        ///////////////////////////////////
            case 4:
                print("Round4");
                OneMoreRound();

                break;
        ///////////////////////////////////
            case 5:
                print("Round5");
                OneMoreRound();

                break;
        ///////////////////////////////////
            case 6:
                print("Round6");
                OneMoreRound();

                break;
        ////////////////////////////////////
            case 7:
                print("Round7");
                OneMoreRound();

                break;
        ////////////////////////////////////
            case 8:
                print("Round8");
                OneMoreRound();

                break;
        ////////////////////////////////////
            case 9:
                print("Round9");
                OneMoreRound();

                break;
        ////////////////////////////////////
            case 10:
                print("Round10");
                OneMoreRound();

                break;
        ////////////////////////////////////
            case 11:
                print("Round11");
                OneMoreRound();

                break;
        ////////////////////////////////////
        }
    }

    private void OneMoreRound()
    {

    }

    private void Verify()
    {

        
        roundIndex++;
    }

    
}
