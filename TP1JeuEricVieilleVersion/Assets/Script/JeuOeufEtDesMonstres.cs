using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JeuOeufEtDesMonstres : MonoBehaviour
{
    private const int POINTAGE_GAGNANT = 20;
    private int vie = 3;
    private int points = 0;
    public bool avoirClef = false;
    public bool dragonMort = false;
    private DeplacementDragon deplacementDragon;
    public GameObject clef;
    public GameObject head;
    public GameObject dragon;
    public Text pointage;
    public Text vitality;
    public Text gameOver;
    public Text felicitation;
    public Text tuerDragon;
    public Button nouvellePartie;
    public Button quitter;
    public Button messageDebut;
   
   
	// Use this for initialization
	void Start ()
    {
        pointage.text = "Nombre d'oeufs: " + points;
        vitality.text = "Vitalité: " + vie;
        messageDebut.onClick.AddListener(MessageDepart);
        nouvellePartie.onClick.AddListener(RecommencerPartie);
        quitter.onClick.AddListener(QuitterPartie);
    
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (dragonMort)
            Destroy(dragon.gameObject);
	    */
        }
     
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == head.gameObject.tag && points >= POINTAGE_GAGNANT)
        {
            dragonMort = true;
            Instantiate(clef, new Vector2(this.transform.position.x, this.transform.position.y - 8), Quaternion.identity);

            BougerDragon();


        } 

        if(collider.gameObject.tag == "oeuf")
        {
            points++;
            if(vie < 3)
                vie++;
            pointage.text = "Nombre d'oeufs: " + points;
            vitality.text = "Vitalité: " + vie;
            Destroy(collider.gameObject);           
        }

        if (collider.gameObject.tag == "ennemi")
        {
            vie--;
            if (points > 0)
                points--;
            
            vitality.text = "Vitalité: " + vie;
            pointage.text = "Nombre d'oeufs: " + points;
        }

        if(collider.gameObject.tag == "clef")
        {
            avoirClef = true;
            Destroy(collider.gameObject);
            tuerDragon.text = "Youppy je peux repartir en fusée!!!";
        }

        if(collider.gameObject.tag == "rocket")
        {
            if(avoirClef && points >= POINTAGE_GAGNANT)
            {
                pointage.text = "Nombre d'oeufs: " + points;
                vitality.text = " ";
                Time.timeScale = 0;
                felicitation.transform.position = new Vector2(255, 335);
                nouvellePartie.transform.position = new Vector2(426, 140);
                quitter.transform.position = new Vector2(343, 50);
            }
        }

        if(collider.gameObject.tag =="mort")
        {
            vie = 0;
        }

        if (vie <= 0)
        {
            pointage.text = " ";
            vitality.text = " ";
            Time.timeScale = 0;
            gameOver.transform.position = new Vector2(450, 435);
            nouvellePartie.transform.position = new Vector2(426, 140);
            quitter.transform.position = new Vector2(343, 50);

        }


        if (points >= POINTAGE_GAGNANT && !avoirClef)
        {
            pointage.text = "Nombre d'oeufs: " + points;
            vitality.text = "Vitalité: " + vie; 
            tuerDragon.text = " Va tuer le Dragon (il tout en haut)Je veux sa peau !!! ";
        }
        
    }

    void BougerDragon()
    {
        dragon.transform.position = new Vector2(500, 500);
    }
 
    void MessageDepart()
    {
        Destroy(messageDebut.gameObject);
    }
    void QuitterPartie()
    {
        Application.Quit();
    }
    void RecommencerPartie()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }

 }
