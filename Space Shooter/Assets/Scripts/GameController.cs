using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float spawnStart;
    public int waveWait;
    public int score;
    private bool gameOver;
    private bool restart;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI quitText;

    public void Update()
    {
        if(restart == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if(Input.GetKeyDown(KeyCode.Q)) {
                Application.Quit();
            }
        }
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(spawnStart);
        while (true)
        {
            
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3.6f, 2.5f), 0.4f, 30.5f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver == true)
            {
                restartText.text = "Press R for restart";
                quitText.text = "Press Q for quit";
                restart = true;
                break;
            }
        }
    }
    void Start()
    {
        gameOverText.text = " ";
        restartText.text = " ";
        quitText.text = " ";
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());
        
    }
    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    
}
