using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    private Rigidbody2D rb;
    public float eggSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartEgg()
    {
        rb.velocity = new Vector2(0, eggSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<FallopianTubesGame>().Win();
        } else if(collision.gameObject.tag == "Drone")
        {
            collision.gameObject.GetComponent<FallopianTubesGame>().GameOver();
        }
    }

}
