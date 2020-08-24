using UnityEngine;

public class SkeletonController : EntityController
{
    [SerializeField] private LayerMask m_AggroMask;
    [SerializeField] private float m_AggroRange;
    
    private bool m_HasAggro;
    private GameObject m_Target;
    
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        // Raycast to search for the player
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, m_AggroRange, m_AggroMask);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, m_AggroRange, m_AggroMask);

        
        // If it doesn't have a target
        if(!m_HasAggro)
        {
            // If anything was hit
            if (hitLeft.collider != null)
            {
                m_HasAggro = true;
                m_Target = hitLeft.collider.gameObject;
            }
            else if (hitRight.collider != null)
            {
                m_HasAggro = true;
                m_Target = hitRight.collider.gameObject;
            }
            
            if (m_HasAggro)
                print("Got Aggro on " + m_Target.name);
        }
        else if(m_HasAggro)
        {
            if (hitLeft.collider == null && hitRight.collider == null)
            {
                print("Lost Aggro on " + m_Target.name);
                m_HasAggro = false;
                m_Target = null;
            }
        }
    }
}
