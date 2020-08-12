using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8.0f;
    AudioSettings audioScript;
    bool startFinished = false;


     void Start()
    {

        GameObject thePlayer = GameObject.Find("Main Camera");
        audioScript = thePlayer.GetComponent<AudioSettings>();
        

    }


    // Update is called once per frame

    void Update()
    {
        if (audioScript.speedMultipier > 0.2f)
        {
           speed = audioScript.speedMultipier * 20;
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
        Debug.Log (Time.deltaTime);
        transform.Translate(0, 0, -100 * Time.deltaTime);
    }

    
}
