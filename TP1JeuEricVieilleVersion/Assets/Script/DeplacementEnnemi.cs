using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnnemi : MonoBehaviour 
{
    public float vitesse = 5f;
    public bool deplacementDroit = true;
    public bool toucheMur = false;

   
	// Use this for initialization
	void Start () 
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if(deplacementDroit)
            this.transform.Translate(Vector3.right * vitesse * Time.deltaTime, Space.World);
            
        if(!deplacementDroit)
            this.transform.Translate(Vector3.left * vitesse * Time.deltaTime, Space.World);
	}

    void OnTriggerEnter2D(Collider2D lobjet)
    {
        toucheMur = false;

        if (lobjet.gameObject.tag == "mur" || lobjet.gameObject.tag == "joueur"|| lobjet.gameObject.tag =="ennemi")
        {
            toucheMur = true;

            if (deplacementDroit)
            {
                
                deplacementDroit = false;
                tourne();
            }
            else
            {
                
                deplacementDroit = true;
                tourne();
            }               
            
        }

        if(lobjet.gameObject.tag =="oeuf")
        {
            Destroy(lobjet.gameObject);
        }

        if (lobjet.gameObject.tag == "mort")
            Destroy(this.gameObject);

    }

    void tourne()
    {
        Vector3 scale = this.transform.localScale;
        if (toucheMur)
        {
            scale.x *= -1;
            toucheMur = false;
        }           

        this.transform.localScale = scale;
    }


}
