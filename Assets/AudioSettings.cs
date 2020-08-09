using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioTest;

    void Start()
    {
        audioTest = GetComponent<AudioSource>();
        audioTest.volume = 0.142f ;

        Invoke("updateVolume", 0.001f);
    }
    void updateVolume()
    {
        audioTest.volume = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
