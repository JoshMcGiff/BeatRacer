using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 8.0f;
    AudioSettings audioScript;
    Rigidbody rb;
    Vector3 vect;
    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Main Camera");
        audioScript = thePlayer.GetComponent<AudioSettings>();
        rb = GetComponent<Rigidbody>();
        vect.z =  Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (audioScript.speedMultipier > 0.2f)
        {
            speed = audioScript.speedMultipier * 28;
        }
        if(transform.position.z < -2.5)
        {
            Destroy(gameObject);
        }
        

        transform.Translate(0, 0, -100 * Time.deltaTime);
        
        //rb.MovePosition(vect);

    }
}
