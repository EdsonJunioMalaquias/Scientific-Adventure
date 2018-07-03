using UnityEngine;
using UnityEngine.SceneManagement;
public class AplicationControler : MonoBehaviour
{

    public static AplicationControler instance;
    public static int levelAtual;
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");
        if (PlayerPrefs.GetInt("itWasSetup") != 1)
        {
            PlayerPrefs.SetInt("MaxLevelCompleted", 0);
            PlayerPrefs.SetInt("itWasSetup", 1);
        }
    }
    public static bool PodeAcessarNivel(int levelID)
    {
        return PlayerPrefs.GetInt("MaxLevelCompleted") >= levelID - 1;
    }
    public static void AdicionaMaxLevelComplete()
    {
        if (AplicationControler.levelAtual > PlayerPrefs.GetInt("MaxLevelCompleted"))
        {
            PlayerPrefs.SetInt("MaxLevelCompleted", AplicationControler.levelAtual);
        }
    }
}
