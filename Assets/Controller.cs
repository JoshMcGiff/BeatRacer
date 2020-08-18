using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    GameObject canvas;
    GameObject playButtonObject;
    GameObject quitButtonObject;

    Button playButton;
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        playButtonObject = canvas.transform.Find("PlayButton").gameObject;
        playButton = playButtonObject.GetComponent<Button>();
        playButton.onClick.AddListener(playOnClick);

        quitButtonObject = canvas.transform.Find("QuitButton").gameObject;
        quitButton = quitButtonObject.GetComponent<Button>();
        quitButton.onClick.AddListener(quitOnClick);
    }
    void playOnClick()
    {
        SceneManager.LoadScene("racer");
    }

    void quitOnClick()
    {
        Debug.Log("Hello");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
