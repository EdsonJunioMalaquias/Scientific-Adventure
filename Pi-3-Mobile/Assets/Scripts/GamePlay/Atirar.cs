using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour {


    public GameObject Spawbullet;
    public Bullet bala;
    public float fireRateTime;
    private float currentFireRateTime = 0;
    public AudioSource audio;
    
    void Update () {
        if (GameControler.instance.estadoAtual == GAME_STATE.INGAME)
        {
            currentFireRateTime += Time.fixedDeltaTime;
            if (currentFireRateTime > fireRateTime)
            {
                currentFireRateTime = 0;
                fire();

            }
        }
 
	}
    public void fire()
    {
        if (GameControler.instance.estadoAtual == GAME_STATE.INGAME) 
        {
            audio.Play();
            GameObject.Instantiate(bala, Spawbullet.transform.position, Spawbullet.transform.rotation);
        }
    }
}
