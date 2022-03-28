using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeCombat : MonoBehaviour
{
    
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 1;
    public int attackDamage = 20; 
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Animator animator;

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

    void OnDrawGizmosSelected()
    {

        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
