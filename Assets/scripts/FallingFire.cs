using UnityEngine;

public class FallingFire : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerHealth player = col.GetComponent<PlayerHealth>();

            if (player != null)
                player.TakeDamage(damage, transform);
        }
    }
}
