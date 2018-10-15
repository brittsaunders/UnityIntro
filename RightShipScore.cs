using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RightShipScore : MonoBehaviour
{

    public int score = 0;
    public Text Points;
    public GameObject Explosion;
    public Transform Spawn;
    public int end = 0;

    void Start()
    {
        SetScoreText();
    }

    public void Update()
    {
        if (score == 20 || score == 40 || score == 60)
        {
            ShipExplode();
        }
    }

    public void ShipExplode()
    {
        GameObject Explode = Instantiate(Explosion, Spawn.position, Quaternion.identity);

        Vector3 velocity = (Quaternion.Euler(0, 0, 0) * Vector3.right);

        Rigidbody2D plode = Explode.GetComponent<Rigidbody2D>();
        plode.velocity = velocity;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            score++;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        Points.text = "Score: " + score.ToString();
    }
}