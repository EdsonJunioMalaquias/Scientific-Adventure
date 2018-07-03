using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinControler : MonoBehaviour {
  
    public GameObject[] stars;
    public Color ActiveStarColor;
    public Text textoVidaAtual, textoVidaMax;
    public Text textoColecionavelAtual, textoColecionavelMax;
    private void Start()
    {
        for (int i = 0; i < SaveControler.GetStarLevel(AplicationControler.levelAtual); i++)
        {
            stars[i].GetComponent<Image>().color = ActiveStarColor;
        }
        textoVidaAtual.text = ""+SaveControler.GetVidaLevel(AplicationControler.levelAtual);
        textoVidaMax.text = "" + SaveControler.maxVida;
        textoColecionavelAtual.text = "" + SaveControler.GetColecionavelLevel(AplicationControler.levelAtual);
        textoColecionavelMax.text = "" + SaveControler.TotalColecionavel;
        AplicationControler.AdicionaMaxLevelComplete();     
    }
    public void ProximoNivel()
    {
        SaveControler.ZerarConfigLevel(AplicationControler.levelAtual+1);
        if (AplicationControler.PodeAcessarNivel(AplicationControler.levelAtual+1))
        {
            SceneManager.LoadScene("Fase_" + (AplicationControler.levelAtual + 1));
            AplicationControler.levelAtual = AplicationControler.levelAtual + 1;
        }
    }
    public void ReiniciarJogo()
    {
        SaveControler.ZerarConfigLevel(AplicationControler.levelAtual);
        SceneManager.LoadScene("Fase_" + AplicationControler.levelAtual);
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
