using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private int roundIndex = 0;
    private int lAIndex = 1;

    [Header("Line Rounds")]

    [SerializeField] private GameObject[] linesArrays = new GameObject[11];

    [SerializeField] private Initialised[] childrens;
    [SerializeField] private GameObject victoryCanvas;
    [SerializeField] private GameObject defeatCanvas;
    [SerializeField] private Text gudAnswerText;

    void Start()
    {
        SetSoluce();
        AssignColor();
        victoryCanvas.SetActive(false);
        defeatCanvas.SetActive(false);
        Play();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (linesArrays[roundIndex].GetComponent<RecupList>().allChanged == true)
            {
                Verify();
            }
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
                solutionLine[b].GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                print("magenta set");
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
            case 0:
                OneMoreRound();
                break;
            ////////////////////////////////////
            case 1:
                break;
            ///////////////////////////////////
            case 2:
                break;
            ///////////////////////////////////
            case 3:
                break;
            ///////////////////////////////////
            case 4:
                break;
            ///////////////////////////////////
            case 5:
                break;
            ////////////////////////////////////
            case 6:
                break;
            ////////////////////////////////////
            case 7:
                break;
            ////////////////////////////////////
            case 8:
                break;
            ////////////////////////////////////
            case 9:
                break;
            ////////////////////////////////////
            case 10:
                break;
            ////////////////////////////////////
            case 11:
                break;
            ////////////////////////////////////
            case 12:
                GameOver();
                break;
            ////////////////////////////////////
        }
    }

    private void OneMoreRound()
    {
        childrens = linesArrays[roundIndex].GetComponentsInChildren<Initialised>();

        foreach(Initialised init in childrens)
        {
            init.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void GameOver()
    {
        Pause();
        defeatCanvas.SetActive(true);
    }

    private void Verify()
    {
        int a = 0;
        int gudAnswer = 0;
        
        foreach (Initialised init in childrens)
        {
            print("in foreach init");
            init.gameObject.GetComponent<SphereCollider>().enabled = false;

            if (init.indexColor == solution[a])
            {
                gudAnswer++;
                gudAnswerText.text = ("Bonnes couleurs au bon emplacement: " + gudAnswer);

                if (gudAnswer == 4)
                {
                    Victory();
                }
            }
            else
            {
                print("incorrect");

            }
            a++;
        }
                
        roundIndex++;
        print("Next Round");
        print("Current Round " + roundIndex);

        OneMoreRound();
    }

    private void Victory()
    {
        print("Victory");
        Pause();

        victoryCanvas.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("StartLevel");
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Play()
    {
        Time.timeScale = 1;
    }
}
