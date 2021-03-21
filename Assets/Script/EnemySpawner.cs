using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Transform enemySpawnerPos;
    public int enemyCount = 5;
    float maxLength, maxWidth;
    public GameObject enemy;
    List<GameObject> enemyInstance;
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerPos = this.gameObject.GetComponent<Transform>();
        maxLength = enemySpawnerPos.localScale.x / 2;
        maxWidth = enemySpawnerPos.localScale.z / 2;
        enemyInstance = new List<GameObject>();
        for(int i = 0; i < enemyCount; i++)
        {
            float rand_x = enemySpawnerPos.position.x + Random.Range(-1 * maxLength, maxLength);
            float rand_z = enemySpawnerPos.position.z + Random.Range(-1 * maxWidth, maxWidth);
            enemyInstance.Add(Instantiate(enemy, new Vector3(rand_x, 1.0f, rand_z), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < enemyInstance.Count; i++)
        {
            if (enemyInstance[i] == null)
            {
                enemyInstance.RemoveAt(i);
                Score++;
            }
        }
        if (enemyInstance.Count < 2)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                float rand_x = enemySpawnerPos.position.x + Random.Range(-1 * maxLength, maxLength);
                float rand_z = enemySpawnerPos.position.z + Random.Range(-1 * maxWidth, maxWidth);
                enemyInstance.Add(Instantiate(enemy, new Vector3(rand_x, 1.0f, rand_z), Quaternion.identity));
            }
        }
    }
}
