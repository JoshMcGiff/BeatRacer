using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBeats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audio = GetComponent<AudioSource>();
        float[] spectrum = new float[256];
        audio.GetOutputData(spectrum, 0);
       
    }
}
