using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves;
    public float screenHeight;
    private float screenHeightOffset;

    private void Start()
    {
        screenHeight = 8.6f;
        screenHeightOffset = 3.5f;
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
                Vector2 enemyPosition = new Vector2();
                enemyPosition.x = enemy.transform.position.x;
                enemyPosition.y = currentWave.inlineSpawn ? currentWave.spawnPositionY : (screenHeight / enemiesCount * i) - screenHeightOffset;

                Instantiate(enemy, enemyPosition, Quaternion.identity, currentWave.transform);

                if (!currentWave.spawnAtOnce) yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            while (!currentWave.CallNextWave()) yield return new WaitForSeconds(.5f);

        }


    }
}
