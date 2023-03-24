using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaucheDroitePlateau : MonoBehaviour
{
    public int facteurGauche = 0;
    public int facteurDroit = 0;
    public bool droitePlat = false;
    public float vitesse = 5f;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (this.transform.position.x <= facteurGauche)
            droitePlat = false;
        if (this.transform.position.x >= facteurDroit)
            droitePlat = true;

        if (!droitePlat)
            this.transform.Translate(Vector2.right * Time.deltaTime * vitesse, Space.World);

        if (droitePlat)
            this.transform.Translate(Vector2.left * Time.deltaTime * vitesse, Space.World);
                  
        
	}
}
