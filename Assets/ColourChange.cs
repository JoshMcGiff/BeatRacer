using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Material changingMaterial;
    public float intensity = 2.2f;
    List<GameObject> accentObjects;
    Color lerpedColor = Color.white;
    float H, S, V;
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.LerpUnclamped(Color.red, Color.magenta, Mathf.PingPong(Time.time, 1));
        //Mathf.Lerp(0, 1, Mathf.PingPong(Time.time, 1));
        accentObjects = GameObject.FindGameObjectsWithTag("Accent").ToList();
        float factor = Mathf.Pow(2, intensity);
        for (int i = 0; i < accentObjects.Count; i++)
        {
            changingMaterial = accentObjects[i].GetComponent<MeshRenderer>().material;
            changingMaterial.color = lerpedColor;
            Color.RGBToHSV(lerpedColor, out H, out S, out V);
            changingMaterial.SetColor("_EmissionColor", new Color(lerpedColor.r * factor, lerpedColor.g * factor, lerpedColor.b * factor));
        }

    }
}
