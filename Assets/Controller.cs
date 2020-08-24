using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    GameObject canvas;
    GameObject playButtonObject;
    GameObject quitButtonObject;
    GameObject testButtonObject;
    public GameObject songNamePrefab;
    GameObject[] songButtonObjects;

    Button playButton;
    Button quitButton;
    Button testButton;

    DirectoryInfo root;
    string[] namesOfSongs;

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
        showFileExplorer();
    }

    void showFileExplorer()
    {
        root = new DirectoryInfo("Assets/Game scene/Songs");
        FileInfo[] infos = root.GetFiles();
        namesOfSongs = new string[infos.Length];
        int tempInt = 1;
        int j = 0;
        int x = -250;
        for (int i = 0; i < infos.Length; i++)
        {
            if (infos[i].Name.EndsWith(".meta"))
            {

            }
            else
            {
                Debug.Log(infos[i]);
                songButtonObjects[j] = songNamePrefab;
                songButtonObjects[j].transform.SetParent(canvas.transform);
                songButtonObjects[j].SetActive(true);
                if (-50 * tempInt < -250)
                {
                    tempInt = 1;
                    x += 250;
                    songButtonObjects[j].transform.localPosition = new Vector3(x, 50 * tempInt, 0);
                }
                else
                {
                    songButtonObjects[j].transform.localPosition = new Vector3(x, 50 * tempInt, 0);
                }

                songButtonObjects[j].GetComponentInChildren<Text>().text = infos[j].Name;
                tempInt++;
                songButtonObjects[j].GetComponent<Button>().onClick.AddListener(loadButtonLevel);
                j++;
            }
        }
    }

    void loadButtonLevel()
    {
        Debug.Log(gameObject.GetComponent<Text>().text);
        Scene sceneToLoad = SceneManager.GetSceneByName("racer");
        SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(gameObject, sceneToLoad);
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
