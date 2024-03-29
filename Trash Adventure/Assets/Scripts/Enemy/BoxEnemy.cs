using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : MonoBehaviour
{
    private GameObject player;

    private Collider2D playerCollider; //tarkistetaan, onko colliderin sis�ll� pelaaja. Jos on.. ->

    [Header ("Hy�kk�ykseen liittyv� liikkuminen")]
    [SerializeField]
    [Tooltip ("Kuinka monen newtonin(?) voimalla vihollinen heitt�� itsens� pelaajaa p�in?")]
    private float thrust = 1.0f;
    
    [SerializeField]
    [Tooltip("Miss� kulmassa oikeallemenev� hy�kk�ys tulee?")]
    private Vector2 AttackPosition = Vector2.zero; //Init nollassa.

    private new Rigidbody2D rigidbody;


    [Header ("Vihollisen asetukset")]
    private Animator animator; //Initalized in Awake

    //Timer attributes
    private float attackCooldown; //init in awake
    private float timeElapsed = 0;
    private bool canattack = false;

     void Start()
    {

        animator = GetComponent<Animator>();
        if(animator == null) { Debug.Log("BoxEnemyll� ei ole animaattoria"); }
    
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null) { Debug.Log("Boxenemyll� ei ole RB2D-komponenttia (K�ytet��n hy�kk�ykseen)"); }

        attackCooldown = GetComponent<Enemy>().attackCooldown;
    }
    private void FixedUpdate()
    {
        //Timer
        if(timeElapsed < attackCooldown+1f) { timeElapsed += Time.deltaTime; } //Jos monta vihollista niin ei tarvitse kokoajan kirjoittaa muistiin kaikkea paskaa
        else{canattack = true;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == null) { player = GameObject.FindWithTag("Player");playerCollider = player.GetComponent<Collider2D>();  }

        if (collision == playerCollider) //Jos ympyr��n astuu sis�lle pelaaja, ->
        {
            Vector3 currentScale = transform.localScale;
            //Tarkistetaan, onko pelaaja oikealla vai vasemmalla
            Vector2 playerposition= new Vector2( collision.GetComponent<Transform>().position.x, collision.GetComponent<Transform>().position.y);
            
            if(playerposition.x > this.transform.position.x) //Jos pelaaja on vihollisen oikealla puolella, niin...
            {
                //oikealla puolella
                if(currentScale.x > 0)
                {
                    transform.localScale = new Vector3(currentScale.x*-1, currentScale.y);
                }
               
                if (canattack) { rigidbody.AddForce(AttackPosition * thrust, ForceMode2D.Impulse);
                    timeElapsed = 0f; //reset timer
                    canattack = false;
                }
            }
            else //Jos ei ole oikealla, niin on pakko olla vasemmalla
            {
                //Vasemmalla puolella
                if (currentScale.x < 0)
                {
                    transform.localScale = new Vector3(currentScale.x * -1, currentScale.y);
                }

                
                //Yl�smenev� energia on aina sama, mutta x:n suuntainen voima muuttuu.
                if (canattack) {rigidbody.AddForce(new Vector2((AttackPosition.x) * -1 * thrust, AttackPosition.y * thrust), ForceMode2D.Impulse);
                    timeElapsed = 0f; //reset timer
                    canattack = false;
                }
                
            }
           
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        //animator.SetBool("moving", false);
    }
}
