using System;
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

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;
    public float speedMultipier = 0.0f;


    void Start()
    {
        clipSampleData = new float[sampleDataLength];

        AudioSource[] audios = GetComponents<AudioSource>();
        audioTest = audios[0];
        audioTest2 = audios[1];


        audioTest = GetComponent<AudioSource>();
        audioTest.volume = 0.1f;

        //Invoke("updateVolume", 0.011f);
        //float tmp = ( 160.0f / (10.0f * 8.0f ));
        //Debug.Log(Convert.ToInt32(tmp));
        //audioTest2.PlayDelayed(2);
        audioTest2.PlayDelayed((float) 0);
    }
    void updateVolume()
    {
        audioTest.volume = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {

        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioTest2.clip.GetData(clipSampleData, audioTest2.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
            speedMultipier = clipLoudness;
            //Debug.Log(clipLoudness); 
        }
    }
}
