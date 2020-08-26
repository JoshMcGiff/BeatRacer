using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShapes : MonoBehaviour
{
    private float speed;
    AudioSettings audioScript;
    Rigidbody rb;
    Manager manager;
    Vector3 vect;
    // Start is called before the first frame update
    void Start()
    {

        GameObject thePlayer = GameObject.Find("Main Camera");
        audioScript = thePlayer.GetComponent<AudioSettings>();
        GameObject managerObject = GameObject.Find("Manager");
        manager = managerObject.GetComponent<Manager>();
        speed = manager.speed;
        rb = GetComponent<Rigidbody>();
        vect.z = Time.deltaTime;
    }

    // Update is called once per frame

    public void moveObstaclePickup()
    {
        //Debug.Log(audioScript.speedMultipier);
        if (audioScript.speedMultipier > 3.0f)
        {
            speed = 13; //make these shared across both movement scripts
        }
        if (audioScript.speedMultipier > 1.5f)
        {
            speed = 10; //make these shared across both movement scripts
        }
        if (audioScript.speedMultipier > 0.5f)
        {
            speed = 7; //make these shared across both movement scripts
        }
        if (transform.position.z < -2.5)
        {
            Destroy(gameObject);
        }


        transform.Translate(0, 0, -10 * speed * Time.deltaTime);
    }
    void Update()
    {
        moveObstaclePickup();
    }
}
