using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneskift : MonoBehaviour
{

    //public gør så metoderne er synlige for andre classes lige meget hvor de er. Hvor void gør så metoden har ingen return value

public void Startspil() { //en funktion
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //Loader en scene fremad

}

public void Startspil2(){//en funktion
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);//Loader to scener fremad
}

public void Startvandtpuslespil(){//en funktion
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-4);//går 4 scener tilbage
}

public void Afslutspil () {//en funktion
    Application.Quit(); //afslutter appen
}



}
