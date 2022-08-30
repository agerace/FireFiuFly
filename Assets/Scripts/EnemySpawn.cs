using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public SoundManager soundManager;
    public GameManager gameManager;
    public Enemy enemy;
    public Enemy2 enemy2;
    void Start()
    {
        Invoke("spawnEnemy", 3);
    }

    private void spawnEnemy()
    {

        float enemyKind = Random.Range(0f, 10f); 
        if (enemyKind > 2f)
        {
            Enemy enemy = Instantiate(this.enemy, new Vector3(Random.Range(-7f, 7f), transform.position.y, 0), Quaternion.identity);
            enemy.soundManager = soundManager;
            enemy.gameManager = gameManager;

        }
        else
        {
            Enemy2 enemy = Instantiate(this.enemy2, new Vector3(Random.Range(-7f, 7f), transform.position.y, 0), Quaternion.identity);
            enemy.soundManager = soundManager;
            enemy.gameManager = gameManager;
        }
        

        float timeToNextSpawn = Random.Range(0.2f, 1.0f);

        Invoke("spawnEnemy", timeToNextSpawn);
    }
}
