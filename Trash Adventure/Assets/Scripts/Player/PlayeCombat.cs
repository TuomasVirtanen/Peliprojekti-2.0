using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayeCombat : MonoBehaviour
{
    
    public Transform attackPoint;
    public LayerMask enemyLayers;


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

    public Button attackButton;
    public bool doAttack = false;

    private void Start()
    {

        Button btn = attackButton.GetComponent<Button>();
        btn.onClick.AddListener(buttonAttack);

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
            if(doAttack)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        doAttack = false;
        animator.SetBool("isAttacking", true);
        SoundManagerScript.PlaySound("hit");
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
            // Game over scene
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("GameOverMenu", LoadSceneMode.Additive);
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

    public void buttonAttack()
    {
        doAttack = true;
    }
}
