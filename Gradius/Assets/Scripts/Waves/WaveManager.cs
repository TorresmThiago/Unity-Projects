using System.Collections;
using System.Collections.Generic;
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
            List<Enemy> enemies = wave.enemyList;
            float enemiesCount = wave.enemyList.Count;

            for (int i = 0; i < enemiesCount; i++)
            {
                Enemy enemy = enemies[i];
                Vector2 enemyPosition = new Vector2();
                enemyPosition.x = enemy.transform.position.x;
                enemyPosition.y = wave.inlineSpawn ? wave.spawnPositionY : (screenHeight / enemiesCount * i) - screenHeightOffset;

                Instantiate(enemy, enemyPosition, Quaternion.identity);

                if (!wave.spawnAtOnce) yield return new WaitForSeconds(wave.spawnInterval);
            }

        }


    }
}
