using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HautBasPlateau : MonoBehaviour
{
    public int facteurBas = 0;
    public int facteurHaut = 0;
    public bool hautPlat = false;
    public float vitesse = 5f;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (this.transform.position.y <= facteurBas)
            hautPlat = false;
        if (this.transform.position.y >= facteurHaut)
            hautPlat = true;

        if (!hautPlat)
            this.transform.Translate(Vector2.up * Time.deltaTime * vitesse, Space.World);

        if (hautPlat)
            this.transform.Translate(Vector2.down * Time.deltaTime * vitesse, Space.World);
	}
}
