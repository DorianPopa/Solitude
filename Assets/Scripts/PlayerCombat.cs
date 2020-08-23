using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform m_AttackPoint;
    public float m_AttackRange = .5f;
    public LayerMask m_EnemyLayers;
    
    public Animator animator;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            PerformMeleeAttack();
        }
    }

    void PerformMeleeAttack()
    {
        animator.SetTrigger("Attack");
        
        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(m_AttackPoint.position, m_AttackRange, m_EnemyLayers);
        foreach (Collider2D hit in objectsHit)
        {
            print("Hit " + hit.gameObject.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (m_AttackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(m_AttackPoint.position, m_AttackRange);
    }
}
