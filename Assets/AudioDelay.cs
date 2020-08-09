using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour
{
    AudioSource audioTest;

    // Start is called before the first frame update
    void Start()
    {
        audioTest = GetComponent<AudioSource>();
        audioTest.PlayDelayed(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
