using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeCombat : MonoBehaviour
{
    
    public Transform attackPoint;
    public LayerMask enemyLayers;


    [Header("Attack stats")]
    public float attackRange = 1;
    public int attackDamage = 20; 
    public float attackRate = 2f;
    float nextAttackTime = 0f;

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

    void Update()
    {   
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
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
            Debug.Log("PLAYER HAS DIED.");
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
}
