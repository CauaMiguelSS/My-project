using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 1;
    public float lifeTime = 1f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerHealth player = col.GetComponent<PlayerHealth>();

            if (player != null)
                player.TakeDamage(damage, transform);

            Destroy(gameObject);
        }
    }
}
