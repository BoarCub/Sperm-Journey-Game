using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermDrone : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected Animator animator;

    public float speed = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        float randomAngle = Random.Range(-45, 45);

        rb.transform.rotation =  Quaternion.Euler(rb.transform.localRotation.x, rb.transform.localRotation.y, randomAngle);

        float velocityY = Mathf.Cos(randomAngle * Mathf.Deg2Rad) * speed;
        float velocityX = -Mathf.Sin(randomAngle * Mathf.Deg2Rad) * speed;

        rb.velocity = new Vector2(velocityX, velocityY);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
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
