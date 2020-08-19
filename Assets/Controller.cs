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
    GameObject testButtonObject;

    Button playButton;
    Button quitButton;
    Button testButton;

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

        testButtonObject = canvas.transform.Find("TestButton").gameObject;
        testButton = testButtonObject.GetComponent<Button>();
        testButton.onClick.AddListener(testOnClick);
    }
    void playOnClick()
    {
        SceneManager.LoadScene("racer");
    }

    void quitOnClick()
    {
        Application.Quit();
    }
    void testOnClick()
    {
        Debug.Log("Hello");
        hideMainMenu();
    }

    void showFileExplorer()
    {
        System.IO.Directory myDir = @"C:\Users\jbmcg\MusicRacer\Assets\Game scene\Songs";
        int count = myDir.GetFiles().Length;
    }

    void hideMainMenu()
    {
        playButtonObject.SetActive(false);
        quitButtonObject.SetActive(false);
        testButtonObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
