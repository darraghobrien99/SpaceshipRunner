using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    [SerializeField] private GameObject[] entitiesPrefabs;
    [SerializeField] private float timer;
    [SerializeField] private float timerMax = 0.5f;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float xMargin = 2;
    [SerializeField] private float entitySpeed = 2;
    [SerializeField] private bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {

        if (!canSpawn)
            return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            timer = timerMax;
            SpawnEntity();
        }
    }

    public void StartScript()
    {
        canSpawn = true;
        timer = timerMax;
    }
    private void SpawnEntity()
    {
       GameObject entityToSpawn = entitiesPrefabs[Random.Range(0, entitiesPrefabs.Length)];
        spawnPosition.x = Random.Range(-xMargin, xMargin);

        GameObject spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
        spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitySpeed);
    }
}
