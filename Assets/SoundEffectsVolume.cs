using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundEffectsVolume : MonoBehaviour
{
    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Sounds",1);
    }
    //public Slider slider;
    // Start is called before the first frame update
    public void newSoundsVol(float vol)
    {
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("Sounds", vol);
    }
}
