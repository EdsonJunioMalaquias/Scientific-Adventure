using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GAME_STATE
{
    START,
    INGAME,
    ENDGAMEWIN,
    ENDGAMEWINFINALLEVEL,
    ENDGAMELOSE,
    PAUSE
}

public class GameControler : MonoBehaviour {
    
    private int star;
    public GAME_STATE estadoAtual;
    private GAME_STATE ProximoEstado;
    public static GameControler instance;
    public int VidasLevel;
    public int Colecionaveis;
    private void Awake()
    {
        int level = AplicationControler.levelAtual;
        SaveControler.maxVida = VidasLevel;
        if (SaveControler.GetVidaLevel(level) == 0){
            SaveControler.SetVidaLevel(level, VidasLevel); ;
        }
        SaveControler.TotalColecionavel = Colecionaveis;     
    }
    private void Start()
    {
        instance = this;
    }
    void Update() {
        estadoAtual = ProximoEstado;
        switch (estadoAtual)
        {
            case GAME_STATE.START:
                {
                    MudarEstado(GAME_STATE.INGAME);
                    break;
                }
            case GAME_STATE.INGAME:
                {
                    Time.timeScale = 1f;
                    break;
                }
            case GAME_STATE.PAUSE:
                {
                    Time.timeScale = 0;
                    break;
                }
            case GAME_STATE.ENDGAMEWINFINALLEVEL:
                {
                    SalvarEstrelas();
                    SceneManager.LoadScene("GameWinFinalLevel");
                    break;
                }
            case GAME_STATE.ENDGAMEWIN:
                {
                    SalvarEstrelas();
                    SceneManager.LoadScene("GameWin");
                    break;
                }
            case GAME_STATE.ENDGAMELOSE:
                {
                    SceneManager.LoadScene("GameLose");
                    break;
                }
        }
    }
    public void SalvarEstrelas()
    {
        star = 1;
        int level = AplicationControler.levelAtual;
        int estrelassalvas = SaveControler.GetStarLevel(level);
        if (SaveControler.GetVidaLevel(level) == VidasLevel)
        {
            star += 1;
        }
        if (SaveControler.GetColecionavelLevel(AplicationControler.levelAtual) == SaveControler.TotalColecionavel)
        {
            star += 1;
        }
        star = estrelassalvas > star ? estrelassalvas : star;
        SaveControler.SetStarLevel(level, star);
    }
    public void Pause()
    {
        MudarEstado(GAME_STATE.PAUSE);
    }
    public void ResumeGame()
    {
        MudarEstado(GAME_STATE.INGAME);
    }
    public void MudarEstado(GAME_STATE NovoEstado){
        ProximoEstado = NovoEstado;
    }
}
