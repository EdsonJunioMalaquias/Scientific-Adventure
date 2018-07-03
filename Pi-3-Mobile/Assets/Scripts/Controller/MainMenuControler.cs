using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControler : MonoBehaviour {
    public void IniciarJogo()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void CarregarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void CarregarConfiguracoes()
    {
        SceneManager.LoadScene("Configuracoes");
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}
