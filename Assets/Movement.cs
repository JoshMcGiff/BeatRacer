using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private int score = 0;
    public static Text test;

    // Start is called before the first frame update
    void Start()
    {
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
