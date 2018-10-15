using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetController : MonoBehaviour {

    public int score = 0;
    public Text Points;

    // Use this for initialization
    void Start()
    {
        SetScoreText();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "cannonball")
        {
            score++;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        Points.text = "YA POINTS: " + score.ToString();
    }
}
