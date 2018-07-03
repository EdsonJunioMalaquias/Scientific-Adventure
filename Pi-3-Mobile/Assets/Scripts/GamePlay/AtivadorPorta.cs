using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorPorta : MonoBehaviour {
    
    public GameObject porta;
    public AudioSource ativador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ativador.Play();
            this.gameObject.GetComponent<Animator>().SetTrigger("AtivadorDaPorta");
            porta.GetComponent<Animator>().SetBool("AtivarPorta", true);
            Porta.estaAtivada = true;
        }
    }


}
