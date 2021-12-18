using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brikrykker : MonoBehaviour
{


    public string pieceStatus=""; 
    //dette er en public string hvilket betyder at alle pieces kan få deres egen status, 
    //altså variable, igennem den her. det vil også sige at koden ikke kan være static
    
    public Transform edgeParticles;
    //den her public Transform er her, så vi kan implementere effecter til selve
    // pusslespilsbrikkerne. så de bliver placeret. derfor står transform der.

    public string checkPlacement=""; 
    //check placement er en puplic String som giver endten variablen "n"
    // eller "y" alt efter om objektet er taget op, bliver placeret forkert, 
    //eller placeret rigtigt.

 

    /*
    så alle overstående er enlig variable som bliver brugt 
    længere nede til at få de forskellige ting til at fungere.
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Void Update er scriptet som køres igennem hvert frame.
    void Update()
    {
        // pieceStatus er her for at tjekke om brikstykket er taget op.
        if (pieceStatus == "pickedup")
        {
        /*Vector 2 er ligesom et koordinatsystem, altså at man arbejder med x og y koordinator kun. 
        her er "mouseposition" en variable med et x og y koordinat
        her ændre vi så variablen til en ny vector 2 
        hvor vi fotæller at den skal have input fra x og y koordinaterne.
        */
        Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y); 
        /*
        Unity har noget der hedder unity units, som er det "Camera.main.SreenToWorldPoint" betyder. 
        den tager så "mousePosition" og ændre den ind til de her units
        i en ny variable kaldt "objPosition".
        */
        Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        //til sidst siger vi at "objPosition" skal bruges af hvad end scriptet er sat på i unity.
        transform.position = objPosition;
        }
        
        /*
        for at se om du har placeret brikken rigtigt, køre "if-statementet nedeunder for at tjekke om brikken skal sidde der"
        koden her gør at hvis du trykker på højre klik vil den vil den syg "y" eller ja til at den er trykket.
        */

        if (Input.GetMouseButtonDown(1))
        {
        checkPlacement="y";
        }
    }

//OnTriggerStay er en forbygget metode, som aktivere når "on trigger" 
//er aktiveret på det objekt der nu har scriptet. stay gør at den konstant tjekker, om objekterne "collider"
    void OnTriggerStay2D(Collider2D other) //collider2D er der fordi Colliders bliver brugt på objekterne.
    {

        //dette er en forsimplet "if" statement som fortæller at hvis et objekts navn er =
        // et andet objekts navn, vil de gøre hvad der står inde for if statementet.
        //Check placement ligger i if statemente for at holde øje med om brikken faktisk er blevet taget.
        if ((other.gameObject.name == gameObject.name) && (checkPlacement=="y")) 
        //vi fortæller også at den skal tjekke efter om at der blevet trykket på museknappen.
        {
            other.GetComponent<BoxCollider2D> ().enabled = false;
            GetComponent<BoxCollider2D> ().enabled = false;
            // disse 2 koder, gør så når et objekt er "collided" 
            //med det rigtige objekt, vil begges deres colliders slå fra, så
            // andre objekter ikke kan collide med dem.
            


            transform.position = other.gameObject.transform.position; //denne gør, at hvis navnet passer til hinanden, vil den transform objektets position til det andets objekts position.
            pieceStatus = "locked";//her bruger vi public string oppe fra start af klassen, som vi så fortæller at alle pusslespilsbrikkers status skal være "locked"
            Instantiate(edgeParticles,other.gameObject.transform.position, edgeParticles.rotation);// dette instansiere disse effecter på objektet, som også følger med, når koordinaterne ændre sig.
            checkPlacement="n"; //vi sætter den til "n" for at "y" ikke bliver spammet. den ville spamme "y" fordi vi har sat metoden til "stay" og ved void.
            GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1); //den finder objektet, og går derefter ind på spritets farver, og ændre så dens synlighed, den bliver dog synlig med denne kode her
            Spilmester.remainingPieces -= 1; // denne kode giver os mindre "point" for at gøre så man kan skifte til næste scene, refferingen er fra en anden cs fil (Spilmester.cs)

        }
        //istedet for "if" her, kunne man have brugt "else", men vi bruger "if" her.
        if ((other.gameObject.name != gameObject.name) && (checkPlacement=="y")) //her sker det omvendte af det "if" statement oppe over, det hvis de ikke passer sammen, men man dog stadig trykker på musen
        {
            GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, .5f);// på denne kode, vil den gøre brikken, halv gennemsigtig for at fortælle du har sat den fokert.
            checkPlacement = "n";
            
        }
        
    }

    void OnMouseDown()// dette er også en forebygget metode, som fortæller at hvis venstre er trykket, vil det under ske.
    {
        pieceStatus = "pickedup";//dette ændre brikstatus til at den er samlet op hvilket vi bruger så man kan vælge hvilket brik man vil bruge.
        checkPlacement = "n";
    }


}
