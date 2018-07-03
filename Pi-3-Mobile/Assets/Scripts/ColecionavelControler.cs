using UnityEngine;
public class ColecionavelControler : MonoBehaviour {
    public int indexColecionavel;
    public bool eEsfera;
    public GameObject objeto;
    private UiControler uiControler;
    public new AudioSource audio;
	void Start () {
        
        uiControler = FindObjectOfType(typeof(UiControler)) as UiControler;
        if (!eEsfera)
        {
            objeto.SetActive(PlayerPrefs.GetInt("Seringa" + indexColecionavel) == 1 ? false : true);
        }else
        {
            objeto.SetActive(PlayerPrefs.GetInt("PortalIsReady") == 1 ? false : true);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            audio.Play();
            if (!eEsfera)
            {
                PlayerPrefs.SetInt("Seringa" + indexColecionavel, 1);
                SaveControler.SetColecionavelLevel(AplicationControler.levelAtual,SaveControler.GetColecionavelLevel(AplicationControler.levelAtual) + 1);             
            }else
            {
                PlayerPrefs.SetInt("PortalIsReady", 1);
            }
            uiControler.RefreshScreen();
        }
    }
}
