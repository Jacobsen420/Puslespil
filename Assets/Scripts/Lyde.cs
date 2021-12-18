using UnityEngine.Audio;
using UnityEngine;


[System.Serializable] //serializable er en automatiks porccs af at transfomere data strukture
// og object stater i en format som unity kan beholde og rekonstruere senere, eksempelvis at 
//man kan altså selv lave om på ting i unity inspektoren, som at ændre noget lyd niveau
public class Lyde 
{

public AudioMixerGroup group; //reference

public string Navn; //string er noget man bruger til at skrive tekst
public AudioClip clip; //reference, audioclip indholde dataen brugt af "Audiosources"

[Range(0f,1f)]//Hvor meget jeg kan ændre volumen
public float volume;//reference

public bool loop; //reference

[HideInInspector]//gemme den i  inspektoren, men den kan stadig blive accesed alle steder
//da den er public
public AudioSource source; //laver igen en reference, Audiosource er en component som skaber lyd


}
