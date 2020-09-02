using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    
    public GameObject prefab;
    public GameObject obstacle;
    public float speed = 2.0f;
    int beats = 0;
    bool left = false;
    bool middle = false;
    bool right = false;
    bool timerEnded = true;
    AudioSettings audioScript;
    bool hasFirstPickUpSpawned = false;
    bool timeToSpawnObstacle = false;
    float obstacleFrequency = 25.0f;
    public bool isDead = false;

    Vector3 test1 = new Vector3(-2.5f, 0.0f, 80.0f);
    Vector3 test2 = new Vector3(0f, 0.0f, 80.0f);
    Vector3 test3 = new Vector3(2.5f, 0.0f, 80.0f);

    Vector3 leftOb = new Vector3(-2.5f, 0.5f, 80.0f);
    Vector3 middleOb = new Vector3(0.0f, 0.5f, 80.0f);
    Vector3 rightOb = new Vector3(2.5f, 0.5f, 80.0f);

    public GameObject triangle;
    public GameObject cube;
    public GameObject sphere;
    public GameObject diamond;
    bool shapeTimerEnded = true;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("Timer");
        InvokeRepeating("spawnShapes", 0.0f, 2.0f);
        GameObject thePlayer = GameObject.Find("Main Camera");
        audioScript = thePlayer.GetComponent<AudioSettings>();
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        InvokeRepeating("test", 10.0f, obstacleFrequency);

    }
    
   void spawnShapes()
    {
        var rand = new System.Random();
        int temp = rand.Next(4);
        Debug.Log("rand : " + temp);

        Vector3 leftSide = new Vector3(-10f, 0f, 72.1f);
        Vector3 rightSide = new Vector3(10f, 0f, 72.1f);
        if( temp == 0)
        {
            Instantiate(cube, leftSide, Quaternion.identity);
            Instantiate(cube, rightSide, Quaternion.identity);

        }
        else if (temp == 1)
        {
            Instantiate(triangle, leftSide, Quaternion.identity);
            Instantiate(triangle, rightSide, Quaternion.identity);

        }
        else if (temp == 2)
        {
            Instantiate(diamond, leftSide, Quaternion.identity);
            Instantiate(diamond, rightSide, Quaternion.identity);

        }
        else
        {
            Instantiate(sphere, leftSide, Quaternion.identity);
            Instantiate(sphere, rightSide, Quaternion.identity);

        }
        

    }
    public IEnumerator shapeTimer()
    {
        spawnShapes();
        yield return new WaitForSeconds(10.0f);
        spawnShapes();
        //StartCoroutine("shapeTimer"); // DO INVOKEREPEATING INSTEAD

    }
    public IEnumerator Timer()
    {
        timerEnded = false;
        yield return new WaitForSeconds(0.25f);
        timerEnded = true;
    }
    public bool isTimeUp()
    {
        if (timerEnded == true)
        {
            return true;
        }
        return false;
    }
    void onOnbeatDetected()
    {
        if (isTimeUp() == false)
        {
            return;
        }
            
        
            beats++;
        //PlayerPrefs.SetInt("Beats", beats);
        spawnPickup();
        //InvokeRepeating("spawnPickup", 0.0f, 1f);
        //   Debug.Log("Beat!!!");
        StartCoroutine("Timer");
    }
    void spawnObstacle()
    {
        var rand = new System.Random();
        int temp = rand.Next(3);
        if(temp == 0)
        {   
            Instantiate(obstacle, leftOb, Quaternion.identity);
        }
        else if(temp == 1)
        {
            Instantiate(obstacle, middleOb, Quaternion.identity);
        }
        else
        {
            Instantiate(obstacle, rightOb, Quaternion.identity);
        }
    }
    void spawnLeft()
    {
        Instantiate(prefab, test1, Quaternion.identity);    
    }
    void spawnMiddle()
    {
        Instantiate(prefab, test2, Quaternion.identity);
    }
    void spawnRight()
    {
        Instantiate(prefab, test3, Quaternion.identity);
    }
    void spawnPickup()
    {
        if(isDead == true)
        {
            return;
        }
        if(hasFirstPickUpSpawned == false)
        {
            GameObject tempGO = Instantiate(prefab, test1, Quaternion.identity);
            tempGO.GetComponent<MeshRenderer>().enabled = false;
            tempGO.transform.localScale = new Vector3(25, 1, 1.0f);
            tempGO.transform.localPosition = new Vector3(0, 0, 30);
            hasFirstPickUpSpawned = true;
        }
        var rand = new System.Random();
        int temp = rand.Next(3);
        int obstacleTemp = rand.Next(5);
        if (temp == 0)
        {
            if (timeToSpawnObstacle == true)
            {
                timeToSpawnObstacle = false;
            }
            spawnRight();
            
            
        }
        else if(temp == 1)
        {
            if (timeToSpawnObstacle == true)
            {
                timeToSpawnObstacle = false;
            }
            spawnLeft();
            if (obstacleTemp == 1)
            {
                Invoke("spawnObstacle", 0.125f);
            }

        }
        else
        {
            if (timeToSpawnObstacle == true)
            {
                Instantiate(obstacle, leftOb, Quaternion.identity);

                //Instantiate(obstacle, middleOb, Quaternion.identity);
                timeToSpawnObstacle = false;
            }
            spawnMiddle();
            if (obstacleTemp == 1)
            {
                Invoke("spawnObstacle", 0.125f);
            }

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
