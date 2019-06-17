using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leukocyte : MonoBehaviour
{

    GameObject player;
    private Rigidbody2D rb;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.transform.position, player.transform.position, speed * Time.deltaTime);
        rb.transform.position = newPosition;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<UterusGame>().reduceHealth();
        } else if(collision.gameObject.tag == "Drone")
        {
            collision.gameObject.GetComponent<SpermDrone>().canMove = false;
        }
    }

}
