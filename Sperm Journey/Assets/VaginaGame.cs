using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VaginaGame : MonoBehaviour
{

    public float health = 100;
    public float healthRate = 0.5f;

    private Rigidbody2D rb;

    public TMPro.TextMeshProUGUI text;

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
        Debug.Log("Yee");
        if(collision.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
        }
    }

    public void GameOver()
    {

    }

    public void reduceHealth()
    {
        health -= healthRate * Time.deltaTime;

        if(health < 0)
        {
            health = 0;
            GameOver();
        }

        text.text = "Health: " + (int)(health) + "/100";

    }

}
