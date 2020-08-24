using UnityEngine;

public class EntityController : MonoBehaviour
{
    protected Rigidbody2D m_Rigidbody2D;
    protected bool m_FacingRight = true;  // For determining which way the player is currently facing
    protected Vector3 m_Velocity = Vector3.zero;

    protected void Flip()
    {
        // Switch the way the entity is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the entity's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}