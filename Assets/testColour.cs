using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       gameObject.GetComponent<Renderer>().material.color = new Color(1.0f,0.5f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
