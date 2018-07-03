using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfiguracoesControler : MonoBehaviour {
    List<string> names = new List<string>() { "Selecione o tipo", "JoyStick", "TouchScreen", "Setas" };
    public Dropdown dropDown;
    public Toggle volume;
    

    void Awake()
    {
        
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            volume.isOn = (PlayerPrefs.GetInt("VOLUME") == 1) ? true : false;
        }
        else
        {
            PlayerPrefs.SetInt("VOLUME", 1);
            volume.isOn = true;
        }
        if (PlayerPrefs.HasKey("CONFIGURACAO"))
        {
            dropDown.value=(PlayerPrefs.GetInt("CONFIGURACAO"));
        }
        else
        {
            PlayerPrefs.SetInt("CONFIGURACAO", 1);
            dropDown.value = 1;
            

        }
    }
    void Start () {
        
        ListaDropdown();
    }
    
	public void ListaDropdown()
    {
        dropDown.AddOptions(names);
    }
    public void CarregarMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetarConfiguracao()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void SalvarConfiguracoes()
    {
        PlayerPrefs.SetInt("VOLUME", volume.isOn ? 1 : 0);
       
        if(dropDown.value >=1){
            PlayerPrefs.SetInt("CONFIGURACAO", dropDown.value);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
