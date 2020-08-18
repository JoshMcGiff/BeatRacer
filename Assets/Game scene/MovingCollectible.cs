using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8.0f;
    AudioSettings audioScript;
    bool startFinished = false;
    Manager manager;
    ObstacleMovement obstacleMovement;



    void Start()
    {

        GameObject thePlayer = GameObject.Find("Main Camera");
        audioScript = thePlayer.GetComponent<AudioSettings>();
        GameObject managerObject = GameObject.Find("Manager");
        manager = managerObject.GetComponent<Manager>();
        GameObject ObstacleMovement = GameObject.Find("Obstacle");
        obstacleMovement = managerObject.GetComponent<ObstacleMovement>();
        speed = manager.speed;


    }


    // Update is called once per frame

    void Update()
    {
        if (audioScript.speedMultipier > 3.0f)
        {
            speed = 26; //make these shared across both movement scripts
        }
        if (audioScript.speedMultipier > 1.5f)
        {
            speed = 20; //make these shared across both movement scripts
        }
        if (audioScript.speedMultipier > 0.5f)
        {
            speed = 14; //make these shared across both movement scripts
        }
        if (transform.position.z < -2.5)
        {
            Destroy(gameObject);
        }
        ////if(obstacle.transform.position.z < -2.5)
        //{
        //   DestroyImmediate(obstacle, true);
        //}
        //Debug.Log (-10 * speed * Time.deltaTime);
        //transform.Translate(0, 0, -10 * speed * Time.deltaTime);

        transform.Translate(0, 0, -10 * speed * Time.deltaTime);
    }

    
}
