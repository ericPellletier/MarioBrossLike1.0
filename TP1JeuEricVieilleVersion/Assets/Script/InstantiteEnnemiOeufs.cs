using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class InstantiteEnnemiOeufs : MonoBehaviour
{

    public GameObject oeuf;
    public GameObject ennemi;
    private System.Random random;
    private IEnumerator enumEnnemis;
    private bool chierTrucs = false;
    public bool tombe = false;
    private int compteur = 0;
    private int choixDeTrucs = 0;
    private float prochainTruc = 0f;
    private float decalageTemps;
   

   

	// Use this for initialization
    void Start()
    {
        random = new System.Random();  
    }
	
	// Update is called once per frame
    void Update()
    {
        compteur = random.Next(1, 3);
        decalageTemps = random.Next(1, 6);
        choixDeTrucs = random.Next(0, 3);
        if (Time.time > prochainTruc)
        {
            prochainTruc = Time.time + decalageTemps;
            if (choixDeTrucs == 0)
            {   
                for(byte i = 0; i < compteur; i++)
                    Instantiate(ennemi, new Vector3(this.transform.position.x, this.transform.position.y - 5, 0), Quaternion.identity);                
            }
            else
            {
                for (byte i = 0; i < compteur; i++) 
                    Instantiate(oeuf, new Vector3(this.transform.position.x, this.transform.position.y - 5, 0), Quaternion.identity);
            }
        }
        
   
    }


   
}
