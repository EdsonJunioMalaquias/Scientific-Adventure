using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonLevelSelect : MonoBehaviour {
    public int levelACarregar;
    public GameObject cadeado;
    public GameObject[] stars;
    public GameObject text;
    private LevelSelectControler levelSelectControler;
    public Color ActiveStarColor;
    
    void Start () {
        levelSelectControler = FindObjectOfType(typeof(LevelSelectControler))as LevelSelectControler;
        if (AplicationControler.PodeAcessarNivel(levelACarregar))
        {
            cadeado.SetActive(false);
            for (int i = 0; i < SaveControler.GetStarLevel(levelACarregar); i++)
            {
                stars[i].GetComponent<Image>().color = ActiveStarColor;
            }
        }
        else
        {
            foreach (GameObject stars in stars)
            {
                stars.SetActive(false);
            }

        }
    }
	
	public void VaiParaOLevel () {
        
        levelSelectControler.VaiParaOLevel(levelACarregar);
	}
}
