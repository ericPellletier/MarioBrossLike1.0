using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimControlleur : MonoBehaviour
{
    public float vitesseMax = 10f;
    private bool versDroite = true; 
    private Animator animateur;
    private Rigidbody2D body;
    private bool secondSaut = false;
    private bool grounded = false;
    public Transform groundCheck; 
    private float rayonGround = 0.2f;
    public LayerMask whatIsGround;
    
    

    private const float JUMP_FORCE = 800f;

	// Use this for initialization
	void Start () 
    {
        body = this.GetComponent<Rigidbody2D>();
        animateur = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            secondSaut = true;
            animateur.SetBool("grounded", false);
            body.AddForce(new Vector2(0, JUMP_FORCE));
        }

        if (!grounded && secondSaut && Input.GetKeyDown(KeyCode.Space))
        {
            secondSaut = false;
            animateur.SetBool("grounded", false);
            body.AddForce(new Vector2(0, JUMP_FORCE));
        }


	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, rayonGround, whatIsGround);

        float move = Input.GetAxis("Horizontal");
        animateur.SetBool("grounded", grounded);
        animateur.SetFloat("speed", Mathf.Abs(move));
        animateur.SetFloat("vSpeed", body.velocity.y);     

        body.velocity = new Vector2(move * vitesseMax, body.velocity.y);

        if (move > 0 && !versDroite) 
            flip();
        else if (move < 0 && versDroite)
            flip();

    }

    private void flip()
    {
        versDroite = !versDroite;

        Vector3 scale = this.transform.localScale; 

        scale.x *= -1;

        this.transform.localScale = scale;
    }


}
