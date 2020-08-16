using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Movement movementScript;
    SpawnObjects spawnObjectsScript;
    GameObject canvas;
    GameObject score;
    AudioSettings audioScript;
    GameObject restartButtonObject;
    Button restartButton;
    public int localHealth;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GameObject.Find("Cube").GetComponent<Movement>();
        spawnObjectsScript = GameObject.Find("Manager").GetComponent<SpawnObjects>();
        audioScript = GameObject.Find("Main Camera").GetComponent<AudioSettings>();
        canvas = GameObject.Find("Canvas");
        score = GameObject.Find("Score");
        restartButtonObject = canvas.transform.Find("RestartButton").gameObject;
        restartButton = restartButtonObject.GetComponent<Button>();
        restartButton.onClick.AddListener(taskOnClick);
        localHealth = movementScript.health;


    }
    void taskOnClick()
    {
        SceneManager.LoadScene("racer");

    }
    // Update is called once per frame
    void Update()
    {
        if (movementScript.health < 1)
        {
            audioScript.hitAudioEffect();
            spawnObjectsScript.isDead = true;
            score.SetActive(false);
            restartButtonObject.SetActive(true);
            //go to deathscreen
        }
        
       
    }
}
