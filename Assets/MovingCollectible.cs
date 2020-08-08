using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int speed = 2;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -2.5)
        {
            Destroy(gameObject);
        }
        transform.Translate(0, 0, -5 * speed * Time.deltaTime);

    }

    
}
