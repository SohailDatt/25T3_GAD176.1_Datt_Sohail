using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 10)
        {
            xPos = Random.Range(-15, 15);
            zPos = Random.Range(-15, 15);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3);
            EnemyCount += 1;
        }
    }
}
