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
    List<GameObject> songButtonObjects;

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

    List<GameObject> gameobjects;
    void showFileExplorerV2()
    {
        root = new DirectoryInfo("Assets/Game scene/Songs");
        FileInfo[] infos = root.GetFiles();
        namesOfSongs = new string[infos.Length];
        for(int i = 0; i < infos.Length; i++)
        {
            Debug.Log(infos[i].ToString());
            GameObject temp = Instantiate(songNamePrefab);
            temp.transform.SetParent(canvas.transform);
            temp.SetActive(true);
            temp.GetComponentInChildren<Text>().text = infos[i].Name;
            temp.name = "songName" + i;
            gameobjects[i] = GameObject.Find("songName" + i);
        }
        for (int j = 0; j < infos.Length; j++)
        {
            Debug.Log("gameobjects[j].GetComponentInChildren<Text>().text");
        }
    }
    GameObject temp;
    void showFileExplorer()
    {
        root = new DirectoryInfo("Assets/Game scene/Songs");
        FileInfo[] infos = root.GetFiles();

        temp.name = "TEST";
        temp.transform.SetParent(canvas.transform);
        temp.SetActive(true);
        temp.transform.localPosition = new Vector3(0, 0, 0);
        temp.GetComponentInChildren<Text>().text = infos[0].Name;
        temp.GetComponent<Button>().onClick.AddListener(() => { loadButtonLevel(temp); });
        //DontDestroyOnLoad(temp);
        SongName.songName = infos[0].Name;


    }

    void loadButtonLevel(GameObject gameObject)
    {
        gameObject.name = "TEST";
        //DontDestroyOnLoad(gameObject);
        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(1);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        //SceneManager.MoveGameObjectToScene(gameObject, sceneToLoad);
    
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
    private void Awake()
    {
        temp = Instantiate(songNamePrefab);
        DontDestroyOnLoad(temp);
    }
}
