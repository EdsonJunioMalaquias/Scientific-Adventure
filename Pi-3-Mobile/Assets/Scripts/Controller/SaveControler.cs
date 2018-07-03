using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControler : MonoBehaviour
{
    public static SaveControler instance;
    private Vector3 position;
    public GameObject[] startPoint;
    private Vector3[] PosicioesIniciais;
    public static int TotalColecionavel;
    public static int maxVida;
    public static int TotalColecionavelTodasFases = 9;
    void Start()
    {
        instance = this;
        PosicioesIniciais = new Vector3[startPoint.Length];
        DontDestroyOnLoad(gameObject);
        SetarPosicoes();
    }
    public void SetarPosicoes()
    {
        for (int i = 0; i < startPoint.Length; i++)
            PosicioesIniciais[i] = startPoint[i].transform.position;
    }
    public void SetPosicaoPlayer(Vector3 savePosition)
    {
        position = savePosition;
    }
    public Vector3 GetPosicaoPlayer()
    {
        return position;
    }
    public void EscolherPosicaoInicial()
    {
        if (position == new Vector3(0, 0, 0))
        {
            for (int i = 0; i < startPoint.Length; i++)
            {
                if (AplicationControler.levelAtual == i + 1)
                {
                    SetPosicaoPlayer(PosicioesIniciais[i]);
                }
            }

        }
    }
    public static int GetStarLevel(int level)
    {
        return PlayerPrefs.GetInt("StarLevel" + level);
    }
    public static void SetStarLevel(int level, int amountStar)
    {
        PlayerPrefs.SetInt("StarLevel" + level, amountStar);
    }

    public static void SetVidaLevel(int level, int quantidadeVidas)
    {
        PlayerPrefs.SetInt("VidaLevel" + level, quantidadeVidas);
    }
    public static int GetVidaLevel(int level)
    {
        return PlayerPrefs.GetInt("VidaLevel" + level);
    }

    public static void SetColecionavelLevel(int level, int quantidadeColecionavelColetados)
    {
        PlayerPrefs.SetInt("ColecionaveisLevel" + level, quantidadeColecionavelColetados);
    }
    public static int GetColecionavelLevel(int level)
    {
        return PlayerPrefs.GetInt("ColecionaveisLevel" + level);
    }

    public static void ZerarConfigLevel(int level)
    {
        instance.SetPosicaoPlayer(new Vector3(0, 0, 0));
        PlayerPrefs.SetInt("ColecionaveisLevel" + level, 0);
        PlayerPrefs.SetInt("PortalIsReady", 0);
        SetVidaLevel(level, 0);
        for (int i = 1; i <= SaveControler.TotalColecionavelTodasFases; i++)
        {
            PlayerPrefs.SetInt("Seringa" + i, 0);
        }
    }
}

