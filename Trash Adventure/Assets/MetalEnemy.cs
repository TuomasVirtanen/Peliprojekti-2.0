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

    private void Start()
    {
        enemyscript = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == null) { player = GameObject.FindWithTag("Player"); playerCollider = player.GetComponent<Collider2D>(); }

        if (collision == playerCollider) //Jos laatikkoon
        {
            Debug.Log("MetalEnemy collision w player");
            Instantiate(explosion, transform.position, Quaternion.identity);
            enemyscript.TakeDamage(enemyscript.maxHealth); //Tee kaikki HP damagea
            enemyscript.Die();//Kuole

        }
    }
}
