using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;

    public float spawnRate = 1f;

    public float areaWidth = 10f;
    public float areaHeight = 6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnFire();
            timer = 0;
        }
    }

    void SpawnFire()
    {
        float x = Random.Range(-areaWidth, areaWidth);
        float y = Random.Range(-areaHeight, areaHeight);

        Vector2 spawnPos = new Vector2(x, y);

        Instantiate(firePrefab, spawnPos, Quaternion.identity);
    }
}

