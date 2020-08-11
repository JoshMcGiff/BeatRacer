using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    Text txt;

    Vector3 test1 = new Vector3(-2.5f, 0.0f, 80.0f);
    Vector3 test2 = new Vector3(0f, 0.0f, 80.0f);
    Vector3 test3 = new Vector3(2.5f, 0.0f, 80.0f);

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("Canvas/Beats").GetComponent<Text>();
        

        //301
        //int amountOfBeats = PlayerPrefs.GetInt("Beats");
        //Debug.Log(amountOfBeats);
        //beats = amountOfBeats;
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        InvokeRepeating("spawnObstacle", 0.0f, 10f);

    }
    void increment()
    {
        i++;
    }
    void onOnbeatDetected()
    {
        
            beats++;
        //PlayerPrefs.SetInt("Beats", beats);
        spawnPickup();
        //InvokeRepeating("spawnPickup", 0.0f, 1f);
        txt.text = beats.ToString();
            Debug.Log("Beat!!!");
        
    }
    void spawnObstacle()
    {
        Instantiate(obstacle, test1, Quaternion.identity);
    }
    void spawnLeft()
    {
        Instantiate(prefab, test1, Quaternion.identity);
        left = true;
        right = false;
    }
    void spawnMiddle()
    {
        Instantiate(prefab, test2, Quaternion.identity);
        right = false;
        left = false;
    }
    void spawnRight()
    {
        Instantiate(prefab, test3, Quaternion.identity);
        right = true;
        left = false;
    }
    void spawnPickup()
    {
        var rand = new System.Random();
        int temp = rand.Next(3);
        if (temp == 0 && !right)
        {
            spawnRight();
        }
        else if(temp == 1 && !left)
        {
            spawnLeft();
           
        }
        else
        {
            spawnMiddle();
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
