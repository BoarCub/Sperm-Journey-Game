using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FallopianTubesGame : MonoBehaviour
{

    public float timeStarting = 30f;
    public float timeLeft = 30f;

    public float healthRate = 0.5f;

    private Rigidbody2D rb;

    public TMPro.TextMeshProUGUI text;

    public GameObject gameOver;

    public GameObject win;

    public AudioClip death;
    public AudioClip winClip;
    public AudioClip timeClose;

    private bool timeCloseStarted = false;
    private bool eggReleased = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        text.text = "Time: " + (int)(timeStarting);
    }

    // Update is called once per frame
    void Update()
    {
        reduceTime();
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

    public void reduceTime()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            timeLeft = 0;
            GameOver();
        }

        text.text = "Time: " + (int)(timeLeft);

        if (timeLeft < 5 && !timeCloseStarted)
        {
            AudioSource audioSource = FindObjectOfType<AudioSource>();
            audioSource.clip = timeClose;
            audioSource.Play();
            audioSource.loop = false;
            timeCloseStarted = true;
        }

        if (timeLeft < 10 && !eggReleased)
        {
            FindObjectOfType<Egg>().StartEgg();
        }

        if (eggReleased)
        {
            text.text = text.text + "\nEgg Was Released";
        }

    }

}
