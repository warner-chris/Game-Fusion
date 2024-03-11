using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float spawnRate;
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] private bool canSpawn = true;


    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, foodPrefabs.Length);
            GameObject foodToSpawn = foodPrefabs[rand];
            Instantiate(foodToSpawn, transform.position, Quaternion.identity);
        }
    }
}
