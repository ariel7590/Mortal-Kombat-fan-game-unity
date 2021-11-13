using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] Animator animator;
    private Rigidbody2D playerRB;
    [SerializeField] float jumpForce=15;
    private float groundHeight = -3.27f;
    private bool isPlayerDucking = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AvoidFromFalling();
        Control();
    }

    void Control()
    {
        if(!isPlayerDucking)
        {
            // Walk/Stop
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetFloat("Speed_float", speed);
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetFloat("Speed_float", -speed);
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                animator.SetFloat("Speed_float", 0);
            }

            //Jump
            if (transform.position.y == groundHeight)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }

            if (transform.position.y > groundHeight) // Enters jump animation when character is in the air
            {
                animator.SetBool("Jump_bool", true);
            }
            else
            {
                animator.SetBool("Jump_bool", false);
            }
        }

        //Duck
        if (transform.position.y == groundHeight) // prevents ducking while jumping
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                isPlayerDucking = true;
                animator.SetBool("Duck_bool", true);
            }
            else
            {
                isPlayerDucking = false;
                animator.SetBool("Duck_bool", false);
            }
        }
    }

    void AvoidFromFalling()
    {
        if(transform.position.y<groundHeight)
        {
            transform.position = new Vector3(transform.position.x, groundHeight, transform.position.z);
            FixVelocity();
        }
    }

    void FixVelocity()
        /*
         *The velocity is messed up, so this function fixing it
         */
    {
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity = Vector2.zero;
        }
    }
}
