using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;
    
     AudioSource audioTest;
     AudioSource audioTest2;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        audioTest = audios[0];
        audioTest2 = audios[1];


        audioTest = GetComponent<AudioSource>();
        audioTest.volume = 0.1f ;

        //Invoke("updateVolume", 0.011f);

        audioTest2.PlayDelayed(4);
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
