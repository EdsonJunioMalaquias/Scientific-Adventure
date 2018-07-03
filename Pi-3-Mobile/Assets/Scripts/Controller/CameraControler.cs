using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform target;
    public float maxLimitx;
    public float minLimitx;
    public float maxLimity;
    public float minLimity;
    private Vector3 novaPosicao;
    private float posicaoAtualx;
    private float posicaoAtualy;
    private bool EstaComNovaPosicao = false;
    public static bool estaNaPlataforma=false;

    void Start()
    {
        transform.position = target.transform.position;
    }
   
    void LateUpdate()
    {
      
        posicaoAtualx = target.transform.localPosition.x;
        posicaoAtualy = target.transform.localPosition.y;
        Verificacao();
        if (estaNaPlataforma)
        {
            novaPosicao.x = target.transform.position.x;
            novaPosicao.y = target.transform.root.localPosition.y+2.56f;

        }
        if (!EstaComNovaPosicao)
        {
            
            transform.position = novaPosicao;
        }
        else
        {
            transform.position = novaPosicao;
        }   
    }
    public void Verificacao()
    {
        
        if ((posicaoAtualx < maxLimitx && posicaoAtualx > minLimitx)||(posicaoAtualy < maxLimity && posicaoAtualy > minLimity))
        {
            novaPosicao.x = target.position.x;
            novaPosicao.y = target.position.y;
            EstaComNovaPosicao = false;
        }
        if (posicaoAtualx > maxLimitx)
        {
            EstaComNovaPosicao = true;
            novaPosicao.x = maxLimitx;
        }

        if (posicaoAtualx < minLimitx)
        {
            novaPosicao.x = minLimitx;
            EstaComNovaPosicao = true;
        }
        
        if (posicaoAtualy > maxLimity)
        {
            EstaComNovaPosicao = true;
            novaPosicao.y = maxLimity;
        }

        if (posicaoAtualy < minLimity)
        {
            novaPosicao.y = minLimity;
            EstaComNovaPosicao = true;
        }
       
    }

}
