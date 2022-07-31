using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public int speed;
    private Rigidbody2D rb;
    public GameObject cona;
    private float moveInput = 1;
    private bool facingRight;
    public PlayerMovement pm;
    private float knockbackTime;
    public float startKnockbackTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = cona.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackTime<=0)
        {
            speed = 5;
        }
        else
        {
            speed = -speed;
            knockbackTime -= Time.deltaTime;
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (health<=0)
        {
            score.scoreValue += 1;
            pm.killedNoob();
            Destroy(gameObject);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


    }
    

    public void SetDamage(int damage)
    {
        knockbackTime = startKnockbackTime;
        health -= damage;
        Debug.Log("ouch");
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
        if (collision.gameObject.tag.Equals("wall") || collision.gameObject.tag.Equals("enemy"))
        {
            moveInput = -moveInput;
            Debug.Log("wall hit");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wall") || collision.gameObject.tag.Equals("enemy"))
        {
            moveInput = -moveInput;
            Debug.Log("wall hit");

        }
    }
}
