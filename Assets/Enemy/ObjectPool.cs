using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)]int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach(GameObject enemy in pool)
        {
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
