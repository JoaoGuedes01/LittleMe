using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public bool canAttack;
    private bool isGrounded;
    private Animator anim;
    public int health;
    public Animator heart1,heart2,heart3;
    public int numberNoobs;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        if (moveInput !=0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (isGrounded == true)
        {
            anim.SetBool("isGrounded",true);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }

        if (Input.GetKeyDown(KeyCode.Q)&& canAttack==true)
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            canAttack = false;
        }

        if (health<=0)
        {
            score.scoreValue = 0;
            SceneManager.LoadScene("FristScene");
        }
    }
    
    

    private void FixedUpdate()
    {
        // Right = 1
        // Left = -1
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput >0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput<0)
        {
            Flip();
        }


    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
            
        }

        if (collision.gameObject.tag.Equals("enemy"))
        {
            takeDamage(1);
        }
    }


    public void SetCanAttack(bool newCanAttack) 
    {
        canAttack = newCanAttack;
    }

    public void takeDamage(int damage) 
    {
        health -= damage;
    }

    public void killedNoob()
    {
        numberNoobs += 1;
    }
}
