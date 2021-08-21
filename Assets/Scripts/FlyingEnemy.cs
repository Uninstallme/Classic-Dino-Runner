using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed = 2.5f;
    private float despawnX = -6.0f;

    private GameObject cameraObj;
    private EnemySpawn enemySpawn;

    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
        enemySpawn = cameraObj.GetComponent<EnemySpawn>();
    }
    
    void Update()
    {
        speed = enemySpawn.speed;
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= despawnX)
        {
            Destroy(gameObject);
        }
    }
}
