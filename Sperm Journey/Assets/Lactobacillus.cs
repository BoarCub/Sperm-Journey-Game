using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lactobacillus : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed;

    VaginaGame game;

    void Start()
    {

        game = FindObjectOfType<VaginaGame>();

        rb = GetComponent<Rigidbody2D>();

        float randomAngle = Random.Range(-180, 180);

        rb.transform.rotation = Quaternion.Euler(rb.transform.localRotation.x, rb.transform.localRotation.y, randomAngle);

        float velocityY = Mathf.Cos(randomAngle * Mathf.Deg2Rad) * speed;
        float velocityX = -Mathf.Sin(randomAngle * Mathf.Deg2Rad) * speed;

        rb.velocity = new Vector2(velocityX, velocityY);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, game.transform.position) < 2.96)
        {
            game.reduceHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomAngle = Random.Range(-180, 180);

        rb.transform.rotation = Quaternion.Euler(rb.transform.localRotation.x, rb.transform.localRotation.y, randomAngle);

        float velocityY = Mathf.Cos(randomAngle * Mathf.Deg2Rad) * speed;
        float velocityX = -Mathf.Sin(randomAngle * Mathf.Deg2Rad) * speed;

        rb.velocity = new Vector2(velocityX, velocityY);
    }
}
