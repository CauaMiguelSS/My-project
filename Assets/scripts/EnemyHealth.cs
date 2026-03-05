using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int life = 3;
    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Transform attacker) 
    {
        life -= damage;
        Vector2 direction = (transform.position -attacker.position).normalized;
        rb.AddForce (direction * knockbackForce, ForceMode2D.Impulse);

        if (life <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
