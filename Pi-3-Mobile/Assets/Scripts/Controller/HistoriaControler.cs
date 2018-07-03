using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HistoriaControler : MonoBehaviour
{
    public Text[] historiaText;
    public float velocidadeTexto;
    public GameObject painelFundo;
    public GameObject graphics;
    private string[] stringText;
    private int indiceAtual;
    private float contadorTempo;
    private bool comecar = false;

    private int tamanhoAtual = 0;

    void Start()
    {
        stringText = new string[historiaText.Length];
        Iniciar();
        painelFundo.GetComponentInChildren<Image>().enabled = false;
    }
    private void Iniciar()
    {
        for (int i = 0; i < historiaText.Length; i++)
        {
            stringText[i] = historiaText[i].text;
            historiaText[i].enabled = false;
            historiaText[i].text = "";
        }
    }
    void Update()
    {
        if (comecar)
        {
            contadorTempo += Time.deltaTime;
            if (contadorTempo > velocidadeTexto)
            {
                if (tamanhoAtual < stringText.Length)
                {
                    historiaText[tamanhoAtual].enabled = enabled;
                    if (indiceAtual < stringText[tamanhoAtual].Length)
                    {
                        painelFundo.GetComponentInChildren<Image>().enabled = true;
                        historiaText[tamanhoAtual].text += stringText[tamanhoAtual][indiceAtual];
                        indiceAtual++;
                        if (indiceAtual < stringText[tamanhoAtual].Length)
                        {
                            contadorTempo = 0;
                        }
                        else
                        {
                            contadorTempo = -1;
                        }
                    }
                    else
                    {
                        historiaText[tamanhoAtual].enabled = false;
                        historiaText[tamanhoAtual].text = "";
                        tamanhoAtual++;
                        indiceAtual = 0;
                    }
                }
                else
                {
                    painelFundo.GetComponentInChildren<Image>().enabled = false;
                    comecar = false;
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyObject(graphics);
            tamanhoAtual = 0;
            comecar = true;
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }
        }
    }

}
