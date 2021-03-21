using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    GameObject player;
    Transform playerPos;
    Transform enemyPos;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerPos = player.GetComponent<Transform>();
        enemyPos = this.gameObject.GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos.LookAt(playerPos);
        float distance = Vector3.Distance(playerPos.position, enemyPos.position);
        if(distance>2f)
        {
            enemyPos.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
