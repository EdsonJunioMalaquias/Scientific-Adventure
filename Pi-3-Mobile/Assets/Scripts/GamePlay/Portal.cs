using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Portal : MonoBehaviour {
    private bool portal;
    public bool AFaseFinal = false;
    public GameObject portalPronto;
    public GameObject portalNPronto;
    private void Start()
    {
        
        portalPronto.SetActive(false);
        portalNPronto.SetActive(false);
        
    }
    void Update () {

        if (portal && CrossPlatformInputManager.GetButtonDown("Action")&&!AFaseFinal)
        { 
            GameControler.instance.MudarEstado(GAME_STATE.ENDGAMEWIN);
        }
        if(portal && CrossPlatformInputManager.GetButtonDown("Action") && AFaseFinal)
        {
            GameControler.instance.MudarEstado(GAME_STATE.ENDGAMEWINFINALLEVEL);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPrefs.GetInt("PortalIsReady") == 1)
            {
                portal = true;
                portalPronto.SetActive(true);
            }
            else
            {
                portalNPronto.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            portal = false;
            portalPronto.SetActive(false);
            portalNPronto.SetActive(false);
        }
    }
}

