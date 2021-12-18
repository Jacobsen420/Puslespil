using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spilmester : MonoBehaviour{

    public static int remainingPieces = 9; //her giver vi spillet 9 "point" eller som vi kan kalde det, brikker,
    //så når man har sat alle brikker, vil remainPieces ramme "0"

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (remainingPieces == 0)//hvis reaminingPieces rammer 0 vil nedestående ske.
        {
            
            remainingPieces += 9; 
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+2); //her vil der ske Sceneskift og du vil komme til "Du vandt" scenen.
        }
    }
}

