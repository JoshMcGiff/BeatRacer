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
    public AudioSource audioTest2;

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;
    public float speedMultipier = 0.0f;

    public AudioLowPassFilter lowPassFilter;
    public AudioReverbFilter reverbFilter;

    void Start()
    {
        clipSampleData = new float[sampleDataLength];

        AudioSource[] audios = GetComponents<AudioSource>();
        audioTest = audios[0];
        audioTest2 = audios[1];


        audioTest = GetComponent<AudioSource>();
        audioTest.volume = 0.1f;

        lowPassFilter = GetComponent<AudioLowPassFilter>();
        reverbFilter = GetComponent<AudioReverbFilter>();

    }

    public void hitAudioEffect()
    {
        //reverbFilter.enabled = true;
        lowPassFilter.enabled = true;
        lowPassFilter.cutoffFrequency = 2000.0f;
        lowPassFilter.lowpassResonanceQ = 1.25f;
    }
    public void pauseBothAudio()
    {
        audioTest.Pause();
        audioTest2.Pause();
    }
    public void playBothAudio()
    {
        audioTest.UnPause();
        audioTest2.UnPause();
    }
    public void restoreAudioEffects()
    {
        //reverbFilter.enabled = false;
        lowPassFilter.enabled = false;
        lowPassFilter.cutoffFrequency = 5007.7f;
        lowPassFilter.lowpassResonanceQ = 1.0f;
    }

    int transitionDuration = 4;
   
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
