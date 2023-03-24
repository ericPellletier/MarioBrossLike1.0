using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collerPlatforme : MonoBehaviour
{
    
    public bool toucheMoi = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "platform")
        {
            toucheMoi = true;
            this.gameObject.transform.parent = collider.transform;
        }
            
    }

    void OnTriggerExit2D(Collider2D collider)
    {       
           this.gameObject.transform.parent = null;
    }
}
