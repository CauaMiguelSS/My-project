using UnityEngine;

public class CloneBoss : MonoBehaviour
{
    public int maxHealth = 10;

    [Header("Laser")]
    public GameObject laserPrefab;
    public Transform laserPoint;
    public float laserDelay = 2f;

    private int currentHealth;
    private bool attacking;
    private float timer;
    private bool laserShot;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!attacking) return;

        timer += Time.deltaTime;

        if (timer >= laserDelay && !laserShot)
        {
            ShootLaser();
            laserShot = true;
        }
    }

    public void SetAttacking(bool value)
    {
        attacking = value;
        timer = 0;
        laserShot = false;
    }

    void ShootLaser()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        Vector2 direction = (player.transform.position - laserPoint.position).normalized;

        GameObject laser = Instantiate(laserPrefab, laserPoint.position, Quaternion.identity);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        laser.transform.rotation = Quaternion.Euler(0, 0, angle);

        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * 12f;
    }

    public void TakeDamage(int damage)
    {
        if (!attacking) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
