using UnityEngine.Audio;
using System;
using UnityEngine;

public class lydmanager : MonoBehaviour
{
    //public betyder at alt kan access det fra alle steder.
public Lyde[] sounds; 

public static lydmanager instance;//static betyder at variablen hoere til en class og ik et objekt aka det her en static reference til vores lydmanger, som der goer saa der kun ville blive lavet en instance af vores lydmanager
// og ikke flere eksempelvis naar vi skifter scene




    void Awake(){  //awake er en metode som bliver kaldt som det foerste.
if (instance==null)//if statemnet, hvis vi ikke har en lydmanger i vores scener 
instance=this;//saa laver vi en

else{//hvis vi allerede har en

    Destroy(gameObject);//saa fjerner vi det 
    return;//goer saa ingen kode bliver kaldt foer vi har fjernet objektet

}
DontDestroyOnLoad(gameObject);//destroere ikke vores audiomanger ved at skiftning af scene


foreach(Lyde s in sounds) //for hver lyd i vores "lyde" array vil vi add en audiosource component
//saa naar spillet aabner, laver det en audio source, som saa
//har som har deet samme ting, som clippet og volumen, som vi har defineret inde i "lyde" scriptet.
{
    s.source= gameObject.AddComponent<AudioSource>(); //det her betyder at vores lyd er = audiosource componenten
    s.source.clip=s.clip; // de naaste 3 ting goer det samme, de betyder at at lydens volume, loop osv. overføre til den der audiosource component

    s.source.volume=s.volume;
    s.source.loop=s.loop;
    s.source.outputAudioMixerGroup = s.group;
}

    }

void Start() //En funktion som bliver kaldt i framet scriptet er aktiviret
{
    Play("Hovedmenumusik"); //spille lyd filen ved navn "Hovedmenumusik"
}



   public void Play (string Navn) //er public saa den kan blive kaldt ude fra klassen, som bruger et string  ved navn af vores lyd
   {//saa vi skal bruge et loop som looper igennem alle vores lyde og saa finde lyden med det rigtige navn

Lyde s= Array.Find(sounds, sound =>sound.Navn==Navn);//array.find =finde lyden, find lyden i "lyde" arrayet, hvor vi s¨ville finde lyden som har det rigtige navn
if (s==null)//hvis lyden ikke er fundet sa retunere vi da vi ikke gider proeve at spille en lyd der ikke er der.
return; 
s.source.Play(); //spiller saa lyden

   }


}
