using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayeCombat : MonoBehaviour
{
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource deathSound;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    private Rigidbody2D rb;


    [Header("Attack stats")]
    public float attackRange = 1;
    public int attackDamage = 20; 
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    public Animator animator;

    [Header("Health + UI implementation")]

    [SerializeField]
    private int maxHealth = 100; //Pelaajalla on 100HP defaulttina
    int currentHealth;
    [SerializeField]
    private GameObject player_HP;
    Healthbar healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //TODO::
        //Samalla tavalla instantiate toi HP_bar kun enemy.cs scriptiss�kin, toivoen ett� se korjaisi kaikki ongelmat koska en en�� tii� miten muutenkaan saisin sit� kuntoon.
        GameObject hpAsChild = Instantiate(player_HP);
        healthBar = hpAsChild.GetComponentInChildren<Healthbar>();
        healthBar.enemy = gameObject;

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);//UI
        healthBar = healthBar.GetComponent<Healthbar>();
        if (healthBar == null)
        {
            Debug.Log("Enemy " + this.gameObject + " doesn't have the healthbar component added to it");
        }
    }

    public void TryAttack()
    {   
        if(Time.time >= nextAttackTime)
        {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        attackSound.Play();
        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            //Korjaa boxenemyt tuo if
            if(enemy.GetType() == typeof(BoxCollider2D)) { enemy.GetComponent<Enemy>().TakeDamage(attackDamage);}
            
        }
    }

    void EndAttackAnim()
    {
        animator.SetBool("isAttacking", false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player health: " + currentHealth);


        animator.SetTrigger("hurt");
        healthBar.setHealth(currentHealth);//UI

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void OnDrawGizmosSelected()
    {

        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    private void Death()
    {
        PreventInputScene();
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
        animator.SetTrigger("death");
        Debug.Log("PLAYER HAS DIED.");
        Invoke("GameOverScene", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Death();
        }
    }

    private void GameOverScene()
    {
        // Game over scene
        SceneManager.LoadSceneAsync("GameOverMenu", LoadSceneMode.Additive);
    }

    private void PreventInputScene()
    {
        //makes user unable to press anything else before gameovermenu spawns
        SceneManager.LoadSceneAsync("PreventInputCanvas", LoadSceneMode.Additive);
    }
}
