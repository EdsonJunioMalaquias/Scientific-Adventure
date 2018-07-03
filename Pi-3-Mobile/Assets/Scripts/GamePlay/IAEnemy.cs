using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemy : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private bool noChao = false;
    private Transform GroundCheck;
    private string chaoDoInimigo = "chao";
    private AudioSource audios;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GroundCheck = transform.Find("EnemyGroundCheck");
        audios = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        noChao = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer(chaoDoInimigo));
        if (!noChao)
            speed *= -1;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed > 0 && !facingRight)
        {
            Flip();
        }
        else if (speed < 0 && facingRight)
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ArmaPlayer"))
        {
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            transform.localScale *= -1f;
            Player.AdcForce.velocity = new Vector2(0, jumpForce);
            audios.mute = true;
            speed = 0;
            Destroy(gameObject, 2);
        }
    }
}

