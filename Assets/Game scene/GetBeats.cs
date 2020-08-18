using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GetBeats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayDelayed(50.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
}
