using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float maxSpeed = 4.0f;
    bool facingRight = false;
    int State = 0;
    AudioSource audioSource;

    Animator anim;
    Rigidbody RB;
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("W_soundFX").GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey("a"))
        {
            if (!audioSource.isPlaying) {
                audioSource.Play();
           }
            State = 1;
            //anim.SetInteger("State", State);
            transform.position += transform.right * Time.deltaTime * maxSpeed;
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
            
        }
        else if (Input.GetKey("d"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            State = 1;
            //anim.SetInteger("State", State);
            transform.position -= transform.right * Time.deltaTime * maxSpeed;
            RB.velocity = new Vector3(0, RB.velocity.y, 0);
        }       
        else if (Input.GetKey("w"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            State = 2;
            anim.SetInteger("State", State);
            transform.position -= transform.forward * Time.deltaTime * maxSpeed;

            RB.velocity = new Vector2(0, RB.velocity.y);
            State = 0;

        }
        else if (Input.GetKey("s"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            State = 3;
            anim.SetInteger("State", State);
            transform.position += transform.forward * Time.deltaTime * maxSpeed;

            RB.velocity = new Vector2(0, RB.velocity.y);
            //State = 1;
        }
        if(Input.anyKey == false && anim != null)
        {
            audioSource.Stop();
            State = 0;
            anim.SetInteger("State", State);
        }
        //if(Input.anyKey == true && anim != null)

       
        //Void OnCollisionEnter(Collision collision)
        {
           // RB.velocity = new Vector3(0, RB.velocity.y, 0);
            //RB.velocity = new Vector2(0, RB.velocity.y);
        }

        if (anim != null)
        {
            anim.SetInteger("State", State);
        }
        else
        {
            //State = 0;
        }

        if (move > 0 && !facingRight ){
            Flip();
            
        }else if(move < 0 && facingRight)
        {
            Flip();
            
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
