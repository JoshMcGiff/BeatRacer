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
        float tmp = 80 / (-10 * 4.0f * Time.deltaTime);
        Debug.Log(tmp);
        audioTest.PlayDelayed(tmp); //4
    }

    // Update is called once per frame
    void Update()
    {
    }
}
