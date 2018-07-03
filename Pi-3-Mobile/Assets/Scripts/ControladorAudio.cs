using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    public AudioSource audio;
    public bool ComDelay= false;
    public float TempoDalay = 2;
    private float time = 0;
 
    void Update()
    {
        if (ComDelay)
        {
            time += Time.deltaTime;
            if (time >= TempoDalay)
            { 
                PlayAudio();
                time = 0;
            }
        }
    }
    public void PlayAudio()
    {
        audio.mute = false;
       
        audio.Play();
    }
    public void StopAudio()
    {
       audio.mute= true;
    }

}
