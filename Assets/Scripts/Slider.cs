using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//goer jeg saa kan arbejde med lyde
public class Slider : MonoBehaviour
{
   public AudioMixer audioMixer; //laver en audio mixer reference, audiomixer goer saa jeg kan mix
   //diverse audio sources og putte effekter paa dem
    
    public void SetVolume (float volume) //En funktion
     //float, en value med decimaler, dette koder tager saa en value fra vores slider
    {
        audioMixer.SetFloat("lyd", Mathf.Log10(volume) * 20); //lyd er det jeg har kaldt vores audio mixer i unity, mathf giver den en value
    }
}
