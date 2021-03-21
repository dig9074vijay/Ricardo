using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    GameObject[] enemySpawner;
    public Text scoretext;
    public Text highScore;

    int spawnerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerCount = enemySpawner.Length;
        highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int scoreCount = 0;
        for(int i = 0; i < spawnerCount; i++)
        {
            scoreCount = scoreCount + enemySpawner[i].GetComponent<EnemySpawner>().Score;
        }
        scoretext.text = scoreCount.ToString();
        if(scoreCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreCount);
            highScore.text = "High Score : " + scoreCount.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "High Score 0";
    }
}
