using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    Color[] colors = {
        new Color(0.29f, 0.0f, 0.51f, 1.0f),//indigo
        new Color(0.56f, 0.0f, 1.0f, 1.0f),//violet
        new Color(1.0f, 0.0f, 0.0f, 1.0f),//red
        new Color(1.0f, 0.5f, 0.0f, 1.0f),//orange
        new Color(1.0f, 1.0f, 0.0f, 1.0f),//yellow
        new Color(0.0f, 1.0f, 0.0f, 1.0f),//green
        new Color(0.0f, 0.0f, 1.0f, 1.0f)//blue
        };
    public Material changingMaterial;
    public int currentIndex = 0;
    private int nextIndex;

    private float changeColourTime = 3.0f;

    private float lastChange = 0.0f;
    private float timer = 0.0f;

    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.5f, 1.0f);
        if (colors == null || colors.Length < 2)
            Debug.Log("Need to setup colors array in inspector");

        nextIndex = (currentIndex + 1) % colors.Length;
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > changeColourTime)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            nextIndex = (currentIndex + 1) % colors.Length;
            timer = 0.0f;

        }
        Renderer temp = gameObject.GetComponent<Renderer>();
        temp.material.color = Color.Lerp(colors[currentIndex], colors[nextIndex], timer / changeColourTime);
        temp.material.EnableKeyword("_EMISSION");
        temp.material.SetColor("_EmissionColor", temp.material.color * 1.5f);
    }
}

