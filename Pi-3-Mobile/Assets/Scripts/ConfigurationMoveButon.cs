using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigurationMoveButon : MonoBehaviour
{
    public GameObject Joystickbuton;
    public GameObject Setas;
    public GameObject Touch;
    // Use this for initialization
    void Awake()
    {
        Joystickbuton.SetActive(false);
        Setas.SetActive(false);
        Touch.SetActive(false);
        if (PlayerPrefs.HasKey("CONFIGURACAO"))
        {
            if (PlayerPrefs.GetInt("CONFIGURACAO") == 1)
            {
                joystickswitch();
            }
            if (PlayerPrefs.GetInt("CONFIGURACAO") == 2)
            {
                Touchswitch();
            }
            if (PlayerPrefs.GetInt("CONFIGURACAO") == 3)
            {
                Setasswitch();
            }
        }
        else
        {
            PlayerPrefs.SetInt("CONFIGURACAO", 3);
            Setasswitch();
        }
    }

    public void joystickswitch()
    {
        Joystickbuton.SetActive(true);
        Setas.SetActive(false);
        Touch.SetActive(false);
    }
    public void Setasswitch()
    {
        Joystickbuton.SetActive(false);
        Setas.SetActive(true);
        Touch.SetActive(false);
    }
    public void Touchswitch()
    {
        Joystickbuton.SetActive(false);
        Setas.SetActive(false);
        Touch.SetActive(true);
    }
}
