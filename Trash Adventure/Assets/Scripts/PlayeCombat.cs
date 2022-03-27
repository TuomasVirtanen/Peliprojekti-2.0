using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeCombat : MonoBehaviour
{
    
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 1;
    public int attackDamage = 20; 

    public Animator animator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Attack();
            
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
