using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    struct SpawnTime
    {
        public float instantiateTime;
        public float interval;
        public float variation;
    }

    public GameObject cactusPrefab;
    public GameObject flyingPrefab;
    public GameObject cloudPrefab;
    public Sprite[] cactusSprites;
    public bool stopSpawn = false;

    public float flyingMax = 2.65f;
    public float flyingMin = -0.65f;

    public float cloudMax = 1.75f;
    public float cloudMin = 1.14f;

    public float speed = 2.5f;
    private float spawnX = 6.0f;

    private GameObject scoreObj;
    private Score scoreScript;


    SpawnTime obstacles;
    SpawnTime cloud;

    void Start()
    {

        obstacles.instantiateTime = 0;
        obstacles.interval = 2;   
        obstacles.variation = 0.5f;

        cloud.instantiateTime = 0;
        cloud.interval = 3;
        cloud.variation = 0.7f;

        scoreObj = GameObject.Find("Score");
        scoreScript = scoreObj.GetComponent<Score>();
    
    }

   
    void Update()
    {
        //Spawn Obstacle
        if(Time.time > obstacles.instantiateTime && !stopSpawn)
        {
            GameObject obj;
            int chance = Random.Range(0, 100);

            if(chance < 70 || scoreScript.score < 200){
                obj = Instantiate(cactusPrefab, new Vector3(spawnX, -0.9f), Quaternion.identity);
                obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            } else {
                obj = Instantiate(flyingPrefab, new Vector3(spawnX, Random.Range(flyingMax, flyingMin)), Quaternion.identity);
            }
            obstacles.instantiateTime = Time.time + Random.Range(obstacles.interval - obstacles.variation, obstacles.interval + obstacles.variation);
        }

        //Spawn Cloud
        if (Time.time > cloud.instantiateTime && !stopSpawn)
        {
            GameObject obj = Instantiate(cloudPrefab, new Vector3(spawnX, Random.Range(cloudMax, cloudMin)), Quaternion.identity);
            cloud.instantiateTime = Time.time + Random.Range(cloud.interval - cloud.variation, cloud.interval + cloud.variation);
        }
    }
}
