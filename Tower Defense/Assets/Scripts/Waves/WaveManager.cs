using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves;

    private void Start()
    {
        StartCoroutine(CallWaves());
    }

    private IEnumerator CallWaves()
    {
        foreach (Wave wave in waves)
        {

            Wave currentWave = Instantiate(wave);

            List<Enemy> enemies = currentWave.enemyList;
            float enemiesCount = currentWave.enemyList.Count;

            for (int i = 0; i < enemiesCount; i++)
            {
                Enemy enemy = enemies[i];

                Instantiate(enemy, currentWave.transform);

                yield return new WaitForSeconds(wave.spawnInterval);
            }

            while (!currentWave.CallNextWave()) yield return new WaitForSeconds(.5f);

        }
    }
}
