using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float movementSpeed;

    private Animator animator;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);

        float vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, vertical * movementSpeed);

        float currentAngle = rb.transform.localEulerAngles.z;

        if (canMove)
        {

            if (vertical > 0)
            {
                if (horizontal > 0)
                {
                    currentAngle = -45;
                }
                else if (horizontal < 0)
                {
                    currentAngle = 45;
                }
                else
                {
                    currentAngle = 0;
                }
            }
            else if (vertical < 0)
            {
                if (horizontal > 0)
                {
                    currentAngle = -135;
                }
                else if (horizontal < 0)
                {
                    currentAngle = 135;
                }
                else
                {
                    currentAngle = -180;
                }
            }
            else if (horizontal > 0)
            {
                currentAngle = -90;
            }
            else if (horizontal < 0)
            {
                currentAngle = 90;
            }

        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if((horizontal != 0 || vertical != 0) && canMove)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        rb.transform.localRotation = Quaternion.Euler(rb.transform.localRotation.x, rb.transform.localRotation.y,
            currentAngle);

    }
}
