using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalEnemy : MonoBehaviour
{
    private GameObject player;

    private Collider2D playerCollider; //tarkistetaan, onko colliderin sisällä pelaaja. Jos on.. ->
    private Enemy enemyscript;

    [SerializeField]
    private ParticleSystem explosion;
    [SerializeField]
    private Vector2 blast;

    private void Start()
    {
        enemyscript = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == null) { player = GameObject.FindWithTag("Player"); playerCollider = player.GetComponent<Collider2D>(); }
        Rigidbody2D collisionRigidbody = player.GetComponent<Rigidbody2D>();
        if (collision == playerCollider) //Jos laatikkoon
        {
            Debug.Log("MetalEnemy collision w player");
            collisionRigidbody.AddForce(blast, ForceMode2D.Impulse);
            Instantiate(explosion, transform.position, Quaternion.identity);
            enemyscript.TakeDamage(enemyscript.maxHealth); //Tee kaikki HP damagea
            enemyscript.Die();//Kuole

        }
    }
}
