using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public int score;
    Text scoreText;

    float timer;
    float maxTime;

    AudioSource scoreSound;

    public Text hiScore;
   
    void Start()
    {
        hiScore.text = "H i g h   S c o  r e   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
        score = 0;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f;
        scoreSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            score++;
            scoreText.text = score.ToString("00000");
            timer = 0;

            if(score % 100 == 0)
            {
                scoreSound.Play();
                Time.timeScale += 0.15f; //Aumenta velocidade do jogo
            }
        }

        if(Time.timeScale == 0)
        {
            if(score > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", score);
                hiScore.text = "H i g h   S c o  r e   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
            }
        }
    }
}
