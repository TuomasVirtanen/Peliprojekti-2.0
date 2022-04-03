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


    [Header("Healthbar")]
    [SerializeField]
    private int maxHealth = 100; //Kyseisen vihollisen maksimi HP

    [SerializeField]
    private GameObject HP_enemy;

    //Mikä on kyseisen peliobjektin healthbar
    Healthbar healthBar;
    [SerializeField, Tooltip("Kuolema_efekti")]
    private ParticleSystem death;

    int currentHealth;
    RaycastHit2D hit;

    void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        anim = GetComponent<Animator>();

        GameObject hpAsChild = Instantiate(HP_enemy);
        healthBar =hpAsChild.GetComponentInChildren<Healthbar>();
       
        healthBar.enemy = gameObject;

       

        healthBar.setMaxHealth(maxHealth);//UI 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
   

        healthBar.setMaxHealth(maxHealth);//UI
        healthBar.setHealth(currentHealth);
        healthBar = healthBar.GetComponent<Healthbar>();
        if (healthBar == null)
        {
            Debug.Log("Enemy "+this.gameObject +" doesn't have the healthbar component added to it");
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("took damage" + currentHealth);
        anim.SetTrigger("hurt");

        healthBar.setHealth(currentHealth);//UI
        if (currentHealth <= 0)
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
              
                DamagePlayer();
                
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
        
        Instantiate(death,transform.position, Quaternion.identity);
        Debug.Log("Enemy died");
        Destroy(gameObject);//Tuhoaa peliobjektin

        /*
         GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        */

        //add points

        PointSystem.instance.addPoints(100);
    }

    public bool PlayerInSight()
    {
        hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x * rangeColliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if(hit.collider == null) { return false; } //Jos collider ei ole pelaaja, palauta false.
        
       
        /*
          if(hit.collider != null)
        {
            
        }
        */

        
        return hit.collider != null; //Muulloin colliderin on pakko olla pelaaja, joten palauta jees
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * transform.localScale.x * rangeColliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        //Odotetaan hetki ja sen jälkeen kun animaatio on "osumakohdalla", niin katsotaan onko pelaaja
        //vieläkin näkökentässä ja tehdään siihen vahinkoa?
        if(PlayerInSight())
        {

            hit.transform.GetComponent<PlayeCombat>().TakeDamage(damage);

        }
        
    }

}


