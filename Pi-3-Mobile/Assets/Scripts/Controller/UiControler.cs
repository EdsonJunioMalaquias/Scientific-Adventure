using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiControler : MonoBehaviour
{

    public GameObject panelPause;
    public GameObject ButtonPause;
    public Text TextoVidaAtual;
    public Text TextoColecionavelAtual, TextoColecionavelMax;
    public Text TextoEsferaAtual;

    void Start()
    {
        TextoVidaAtual.text = "" + SaveControler.GetVidaLevel(AplicationControler.levelAtual);
        TextoColecionavelMax.text = "" + (SaveControler.TotalColecionavel);
        RefreshScreen();
        panelPause.SetActive(false);
    }

    public void MostrarPause()
    {
        panelPause.SetActive(true);
        ButtonPause.SetActive(false);
        GameControler.instance.Pause();
    }
    public void EsconderPause()
    {
        panelPause.SetActive(false);
        ButtonPause.SetActive(true);
        GameControler.instance.ResumeGame();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void IrParaMenu()
    {
        GameControler.instance.ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
    public void RefreshScreen()
    {
        TextoColecionavelAtual.text = "" + SaveControler.GetColecionavelLevel(AplicationControler.levelAtual);
        TextoEsferaAtual.text = "" + (PlayerPrefs.GetInt("PortalIsReady"));
    }
}

