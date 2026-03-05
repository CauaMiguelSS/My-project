using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.6f;
    public int damage = 1;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(
                attackPoint.position,
                attackRange,
                enemyLayer
                );

            foreach (Collider2D enemy in hits) 
            {
                enemy.GetComponent<EnemyHealth>()?.TakeDamage(damage, transform);
            }
        }
    }
}
