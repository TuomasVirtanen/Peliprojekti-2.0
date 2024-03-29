using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] public float attackCooldown; //public, sillä boxenemy haluaa sen
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
    public int maxHealth = 100; //Kyseisen vihollisen maksimi HP
    [SerializeField]
    private Vector3 HPOffset;

    [SerializeField]
    private GameObject HP_enemy;

    //Mikä on kyseisen peliobjektin healthbar
    Healthbar healthBar;
    [SerializeField, Tooltip("Kuolema_efekti")]
    private ParticleSystem death;

    [Header("Dropping items")]
    [SerializeField]
    private GameObject trash1;
    [SerializeField]
    private GameObject trash2;
    private bool isdead = false;
    
    float damageRate = 2f;
    float nextDamage = 0f;

    int currentHealth;
    RaycastHit2D hit;

    void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        anim = GetComponent<Animator>();

        /* Spawnaa HP_bar ja aseta siihen arvot. */
        GameObject hpAsChild = Instantiate(HP_enemy, transform.position + HPOffset, Quaternion.identity);
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
        if(Time.time >= nextDamage)
        {
            currentHealth -= damage;
            nextDamage = Time.time + 1f / damageRate;
        }
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

    public void Die()
    {
        //Korjaa roskan 2x spawnauksen
        if (!isdead) {
            Instantiate(death, transform.position, Quaternion.identity); //Particles
            Debug.Log("Enemy died");
            Destroy(gameObject);//Tuhoaa peliobjektin
            

           
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;


            // Droppaa roska-itemit
            //Lisäsin roskien droppaukseen pientä randomia t aaro :)
            try
            {
                Instantiate(trash1, transform.position + new Vector3(Random.Range(0.7f, 1f), Random.Range(0.2f, 0.4f)), Quaternion.identity);
                Instantiate(trash2, transform.position, Quaternion.identity);
            }
            catch (UnassignedReferenceException)
            {
                Debug.Log("Enemy didnt have 2nd trash");
            }

            PointSystem.instance.addPoints(100);

            isdead = true;

        }
        //Play dying animation

        //disable enemy
        
        

        //add points

       
    }

    public bool PlayerInSight()
    {
        hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x * rangeColliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y + 0.5f, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

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
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y+0.5f, boxCollider.bounds.size.z));
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


