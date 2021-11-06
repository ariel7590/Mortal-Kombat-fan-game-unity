using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
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
    }
}
