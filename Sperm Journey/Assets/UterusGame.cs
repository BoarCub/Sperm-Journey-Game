using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UterusGame : MonoBehaviour
{
    public float health = 100;
    public float healthRate = 0.5f;

    private Rigidbody2D rb;

    public TMPro.TextMeshProUGUI text;

    public GameObject gameOver;

    public GameObject win;

    public AudioClip death;
    public AudioClip winClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        text.text = "Health: 100/100";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Win();
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        audioSource.clip = winClip;
        audioSource.Play();
        audioSource.loop = false;
        win.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        audioSource.clip = death;
        audioSource.Play();
        audioSource.loop = false;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void reduceHealth()
    {
        health -= healthRate * Time.deltaTime;

        if (health < 0)
        {
            health = 0;
            GameOver();
        }

        text.text = "Health: " + (int)(health) + "/100";

    }

}
