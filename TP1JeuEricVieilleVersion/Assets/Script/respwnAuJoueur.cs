using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respwnAuJoueur : MonoBehaviour {

    public GameObject joueur;
    public GameObject clef;
	void Start () 
    {
        joueur = GameObject.Find("TimLeHero");
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
   
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "mort")
        {
            if(this.gameObject.tag == "clef")
                Instantiate(clef, new Vector2(joueur.transform.position.x, joueur.transform.position.y - 5), Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

   
}
