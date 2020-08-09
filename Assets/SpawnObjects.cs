using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public GameObject prefab;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected); 
        //InvokeRepeating("spawnPickup", 0.0f, 1f);

    }
    void onOnbeatDetected()
    {
        spawnPickup();
        Debug.Log("Beat!!!");
    }

    void spawnPickup()
    {
        Vector3 test1 = new Vector3(-2.5f, 0.0f, 0.0f);
        Vector3 test2 = new Vector3(0f, 0.0f, 0.0f);
        Vector3 test3 = new Vector3(2.5f, 0.0f, 0.0f);
        var rand = new System.Random();
        int temp = rand.Next(3);
        if (temp == 0)
        {
            Instantiate(prefab, test1, Quaternion.identity);
        }
        else if(temp == 1)
        {
            Instantiate(prefab, test2, Quaternion.identity);
        }
        else
        {
            Instantiate(prefab, test3, Quaternion.identity); 
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
