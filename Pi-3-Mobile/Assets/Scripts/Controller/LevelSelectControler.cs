using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectControler : MonoBehaviour {
    public void VaiParaOLevel(int levelID)
    { 
        if (AplicationControler.PodeAcessarNivel(levelID)){
            SaveControler.ZerarConfigLevel(levelID);
            AplicationControler.levelAtual = levelID;
            SceneManager.LoadScene("Fase_" + levelID); 
        }
    }
    public void VoltaParaOMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
