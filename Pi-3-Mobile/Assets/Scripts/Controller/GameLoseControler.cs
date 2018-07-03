using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameLoseControler : MonoBehaviour {

    public Text textoVidaAtual, textoVidaMax;
    public Text textoColecionavelAtual, textoColecionavelMax;

    void Start()
    {
        int VidaAtual = SaveControler.GetVidaLevel(AplicationControler.levelAtual);
        textoVidaAtual.text = "" + (SaveControler.GetVidaLevel(AplicationControler.levelAtual)-1);
        textoVidaMax.text = "" + SaveControler.maxVida;
        textoColecionavelAtual.text = "" + SaveControler.GetColecionavelLevel(AplicationControler.levelAtual);
        textoColecionavelMax.text = "" + SaveControler.TotalColecionavel;
        SaveControler.SetVidaLevel(AplicationControler.levelAtual, VidaAtual-1);
        VidaAtual = SaveControler.GetVidaLevel(AplicationControler.levelAtual);
        if (SaveControler.GetVidaLevel(AplicationControler.levelAtual) == 0)
        {
            SaveControler.ZerarConfigLevel(AplicationControler.levelAtual);
        }
    }
    public void ReiniciarJogo()
    { 
        SceneManager.LoadScene("Fase_"+ AplicationControler.levelAtual);
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
