using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private int score = 0;
    public static Text test;

    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;

    AudioSource audioTest;
    AudioSource audioTest2;
    AudioSettings audSet;
    bool hasMusicStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject script = GameObject.Find("Main Camera");
        audSet = script.GetComponent<AudioSettings>();
        
        Text txt = GameObject.Find("Canvas/Text").GetComponent<Text>();
        test = txt;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && transform.position.x != -2.5)
        {
            transform.Translate(-2.5f, 0, 0) ;
        }
        if (Input.GetKeyDown("d") && transform.position.x != 2.5)
        {
            transform.Translate(2.5f, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pickup"))
        {
            if(hasMusicStarted == false)
            {
                audSet.audioTest2.PlayDelayed((float)0);
                hasMusicStarted = true;
            }
            
            score++;
            test.text = "Score: " + score.ToString();
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Obstacle"))
        {

            //Debug.Log("Hit");
            Destroy(collider.gameObject);
        }
    }
}
