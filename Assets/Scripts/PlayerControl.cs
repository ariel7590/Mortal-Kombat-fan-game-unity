using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] Animator animator;
    private Rigidbody2D playerRB;
    public float jumpForce;

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
        // Walk/Stop
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed_float", speed);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed_float", speed);
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            animator.SetFloat("Speed_float", 0);
        }

        //Jump
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerRB.AddForce(Vector2.up*jumpForce, ForceMode2D.Force);
        }
    }

    void AvoidFromFalling()
    {
        if(transform.position.y<-3.27f)
        {
            transform.position = new Vector3(transform.position.x, -3.27f, transform.position.z);
        }
    }
}
