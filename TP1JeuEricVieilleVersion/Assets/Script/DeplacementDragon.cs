using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementDragon : MonoBehaviour
{
    public GameObject oeuf;
    public GameObject ennemi;
    public int gauche = -32;
    public int droite = 74;
    public float vitesse = 30f;
    public bool changeDeBord = false;
    public bool estMort = false;
    
    
    
         
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if (this.transform.position.x <= gauche)
            changeDeBord = false;
        if (this.transform.position.x >= droite)
            changeDeBord = true;
        if (!estMort)
        {
            if (!changeDeBord)
            {
                this.transform.Translate(Vector2.right * Time.deltaTime * vitesse, Space.World);
                tourne();
            }

            if (changeDeBord)
            {
                this.transform.Translate(Vector2.left * Time.deltaTime * vitesse, Space.World);
                tourne();
            }
        }

        if (estMort)
        {
            this.transform.position += new Vector3(0, 1000, 0);
        }
     
        

	}

    public void SetMortDragon(bool tuMort)
    {
        estMort = tuMort;
    }
    void tourne()
    {
        Vector3 scale = this.transform.localScale;
        if (this.transform.position.x >= droite || transform.position.x <= gauche)
            scale.x *= -1;

        this.transform.localScale = scale;           
    }

}
