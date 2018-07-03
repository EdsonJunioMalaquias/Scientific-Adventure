using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Porta : MonoBehaviour
{
    public GameObject nextPosition;
    private bool porta = false;
    public Animator Anim;
    private Collider2D colisao;
    public static bool estaAtivada= false;
    public Text textoFechada;
    public Text textoAberta;
    public AudioSource portafechada;
    public AudioSource portaAbrindo;
    public AudioSource portaFechando;
    private void Start()
    {
        textoFechada.enabled = false;
        textoAberta.enabled = false;
    }
    void Update()
    {
        if (porta && CrossPlatformInputManager.GetButtonDown("Action")) 
        {
            MoverPersonagem();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!estaAtivada)
            {
                portafechada.PlayDelayed(0.15f);
                textoFechada.enabled = true;
            }
            else
            {
                portaAbrindo.PlayDelayed(0.15f);
                textoAberta.enabled = true;
                this.GetComponent<Animator>().SetBool("EnterCollider", true);
                porta = true;
                colisao = collision;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            if (!estaAtivada)
            {
                textoFechada.enabled = false;
            }
            else
            {
                portaFechando.PlayDelayed(0.15f);
                textoAberta.enabled = false;
            }

                porta = false;
            this.GetComponent<Animator>().SetBool("EnterCollider", false);
        }
    }
    public void MoverPersonagem()
    {
        colisao.transform.position = new Vector3(nextPosition.transform.position.x, nextPosition.transform.position.y, 0);
    }
}

            

