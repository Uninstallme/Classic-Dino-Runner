using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Player player;
    EnemySpawn enemySpawn;
    GroundMovement groundMovement;
    AudioSource gameOverSound;
    

    bool gameOver = false;
    float timeToIncreaseDifficulty = 0;
    float interval = 5f;

    public GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1;
        player = FindObjectOfType<Player>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        groundMovement = FindObjectOfType<GroundMovement>();
        gameOverSound = GetComponent<AudioSource>();
        
    }

    public void collided()
    {
        if(!gameOver)
        {
            gameOver = true;
            enemySpawn.stopSpawn = true;
            groundMovement.speed = 0;
            gameOverSound.Play();

            Cactus[] allCactus = FindObjectsOfType<Cactus>();
            foreach (Cactus obj in allCactus)
                obj.speed = 0;
        }
    }

    
    void Update()
    {
        
        if(!gameOver)
        {  

            if(Time.time >= timeToIncreaseDifficulty)
            {
                groundMovement.speed += 0.2f;
                enemySpawn.speed += 0.2f;
                timeToIncreaseDifficulty = Time.time + interval;
      
            }
           
        }
        else
        {
            GameOver();
            
        }
      
       
    }

    public void GameOver()
    {
        
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
