using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform startPoint;
    public float waveRate = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, startPoint.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
         StartCoroutine(SpawnEnemy());
    }
}
