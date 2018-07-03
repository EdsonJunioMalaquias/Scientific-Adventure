using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemyFly : MonoBehaviour {
    public float velocidadeDeVoo;
    public bool EstaOlhandoParaADireita;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool estaMorto= false;
    private float velocidadeDeMorte= 250;
    void Start () {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	void Update () {
        if(!estaMorto)
        rb.velocity = EstaOlhandoParaADireita? new Vector2(velocidadeDeVoo*Time.deltaTime, rb.velocity.y) : new Vector2(-velocidadeDeVoo * Time.deltaTime, rb.velocity.y);
        else
        {
            rb.velocity = new Vector2(0, -velocidadeDeMorte * Time.deltaTime);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MudarDirecao"|| collision.gameObject.layer == 11)
        {
            TrocarFace();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        
        if (collision.gameObject.CompareTag("ArmaPlayer"))
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("Morreu", true);
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }
            rb.constraints = RigidbodyConstraints2D.None;
            Player.AdcForce.velocity = new Vector2(0, jumpForce);                      
            estaMorto = true;
            
            this.transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 0);
            Destroy(gameObject, 2);
        }
    }
    public void TrocarFace() {
        EstaOlhandoParaADireita = !EstaOlhandoParaADireita;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
