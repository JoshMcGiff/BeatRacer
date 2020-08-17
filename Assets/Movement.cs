using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private int score = 0;
    public int health = 100;
    public static Text test;
    AudioSettings audioTest2;
    bool isFirstBeat = true;
    string restoreAudioEffects;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        Text txt = GameObject.Find("Canvas/Score").GetComponent<Text>();
        test = txt;
        GameObject audSettings = GameObject.Find("Main Camera");
        audioTest2 = audSettings.GetComponent<AudioSettings>();
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
            if(isFirstBeat == true)
            {
                audioTest2.audioTest2.PlayDelayed((float)0);
                isFirstBeat = false;
            }
            score++;
            test.text = "Score: " + score.ToString();
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            health--;
            audioTest2.hitAudioEffect();
            time = Time.time;
            StartCoroutine("restoreAudio");

            Debug.Log("Hit");
            Destroy(collider.gameObject);
        }
    }
    public IEnumerator restoreAudio()
    {
        yield return new WaitForSeconds(1.0f);
       
        audioTest2.restoreAudioEffects();
    }
}
