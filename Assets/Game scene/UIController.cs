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
    GameObject resumeButtonObject;
    Button resumeButton;
    GameObject mainMenuButtonObject;
    Button mainMenuButton;
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
        restartButton.onClick.AddListener(restartOnClick);

        resumeButtonObject = canvas.transform.Find("ResumeButton").gameObject;
        resumeButton = resumeButtonObject.GetComponent<Button>();
        resumeButton.onClick.AddListener(resumeOnClick);

        mainMenuButtonObject = canvas.transform.Find("MainMenuButton").gameObject;
        mainMenuButton = mainMenuButtonObject.GetComponent<Button>();
        mainMenuButton.onClick.AddListener(mainMenuOnClick);
        localHealth = movementScript.health;
        resumeOnClick();
    }

    void restartOnClick()
    {
        SceneManager.LoadScene("racer");
    }

    void mainMenuOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void resumeOnClick()
    {
        Time.timeScale = 1;
        audioScript.playBothAudio();
        movementScript.isPaused = false;
        unpauseScreen();
    }

    public void unpauseScreen()
    {
        score.SetActive(true);
        resumeButtonObject.SetActive(false);
        mainMenuButtonObject.SetActive(false);

    }
    public void pauseScreen()
    {
        score.SetActive(false);
        resumeButtonObject.SetActive(true);
        mainMenuButtonObject.SetActive(true);

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
