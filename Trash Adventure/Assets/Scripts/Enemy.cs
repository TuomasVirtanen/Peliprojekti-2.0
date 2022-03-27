using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float rangeColliderDistance;
    [SerializeField] private int damage;

    [Header ("Collider")]
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;

    // Viittaukset
    // TODO: private Health playerHealth
    private EnemyPatrol enemyPatrol;

    public int maxHealth = 100;
    int currentHealth;

    void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("took damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Hyökkää, jos pelaaja on näkökentässä
        // Alkaa liikkumaan heti, kun pelaaja poistuu näkökentästä, vaikka olisi hyökkäysanimaatio kesken. Hyvä vai huono juttu??
        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                // Hyökkäys
                
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }

        if(enemyPatrol != null)
        {
            // Vihollinen pysähtyy, kun pelaaja on näkökentässä
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    void Die()
    {
        //Play dying animation

        //disable enemy

        Debug.Log("Enemy died");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x * rangeColliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            // playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * transform.localScale.x * rangeColliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            // Pelaaja ottaa vahinkoa, jos pelaaja on vielä näkökentässä
            // player.Health.TakeDamage(damge);
        }
    }

}


