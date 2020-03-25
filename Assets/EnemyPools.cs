using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPools : MonoBehaviour
{

    [System.Serializable]

    public class Enemy {
        public float timeToSpawn;
        public GameObject prefab;
        public int posX;
        public int posY;
        public int min;
        public int max;
        public int clockwise;
        public float pause;
        public float projectileWait;
        public int endPosX;
        public int endPosY;
        public int start;
        public int increment;
        public int amt;

    }
    
    public List<Enemy> enemies;
    public List<GameObject> EnemyPool;

    public static Vector3 newPosition;

    void Start()
    {
        foreach(Enemy enemy in enemies) {
            GameObject obj = Instantiate(enemy.prefab);
            EnemyMovement script = obj.GetComponent<EnemyMovement>();
            obj.transform.position = new Vector3(enemy.posX, enemy.posY, 0);

            script.projectileWait = enemy.projectileWait;
            script.min = enemy.min;
            script.max = enemy.max;
            script.pause = enemy.pause;
            script.clockwise = enemy.clockwise;
            script.start = enemy.start;
            script.increment= enemy.increment;
            script.amt = enemy.amt;
            obj.SetActive(false); 
            EnemyPool.Add(obj);
        }

        StartCoroutine("SpawnEnemies");
    }




    IEnumerator SpawnEnemies() {

        float timePassed = 0f;
        for (int i=0; i < enemies.Count; i++) {
            Enemy enemy = enemies[i];
            yield return new WaitForSeconds(enemy.timeToSpawn - timePassed);
            GameObject enemyObj = EnemyPool[i];

            enemyObj.transform.position = new Vector3(enemy.posX, enemy.posY, 0);
            Vector3 newPosition = new Vector3(enemy.endPosX, enemy.endPosY, 0);

            enemyObj.SetActive(true);

            float timeSinceStarted = 0f;

            while (enemyObj.transform.position != newPosition) {
                
                timeSinceStarted += Time.deltaTime;
                enemyObj.transform.position = Vector3.Lerp(enemyObj.transform.position, newPosition, timeSinceStarted);
                yield return null;
            }

        }
    }


}
