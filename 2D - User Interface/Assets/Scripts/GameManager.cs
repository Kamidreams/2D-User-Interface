using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool IsGameActive = false; //public bool IsGameActive;
    public int Score = 0;
    public float SpawnRate = 1f;
    public TextMeshProUGUI ScoreText;
    //public TextMeshProUGUI GameTitleText;
    public TextMeshProUGUI GameOverText;
    //public Button StartButton;
    public GameObject StartScene;
    public Button RestartButton;
    public List<GameObject> Target;
    
    // Start is called before the first frame update
    void Start()
    {
        //IsGameActive = false;
    }

    public void StartGame(int Difficulty)
    {
        //GameTitleText.gameObject.SetActive(false);
        //StartButton.gameObject.SetActive(false);
        StartScene.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        IsGameActive = true;
        ScoreText.text = "Score: " + Score;
        SpawnRate /= Difficulty;
        StartCoroutine(SpawnTarget());
    }
     public void UpdateScore(int addToScore)
     {
        Score += addToScore;
        Debug.Log("Score:" + Score.ToString());
        ScoreText.text = "Score: " + Score.ToString();
     }

     public void GameOver()
     {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
     }

     public void RestartGame()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }

    IEnumerator SpawnTarget()
    {
        while(IsGameActive)
        {
            //var = x.y
            yield return new WaitForSeconds(SpawnRate);
            //float xPos = Random.Range(-4, 4);
            //float yPos = -9;
            //Vector2 spawnPos = new Vector2(xPos, yPos);
            int index = Random.Range(0, Target.Count);
            Instantiate(Target[index]);  //Instantiate(Target[index], spawnPos, Target [index].transform.rotaion);
        }
    }
}
