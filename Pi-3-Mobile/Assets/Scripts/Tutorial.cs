using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public Canvas canvas;
	void Start () {
        
        canvas.enabled = false;
        if (PlayerPrefs.GetInt("PrimeiraVez") != 1)
        {
            canvas.enabled = true;
            GameControler.instance.Pause();
        }
        
    }
    public void butonClick()
    {
        GameControler.instance.ResumeGame();
        canvas.enabled = false;
        PlayerPrefs.SetInt("PrimeiraVez", 1);
    }
}
