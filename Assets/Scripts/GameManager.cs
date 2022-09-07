using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; 
    public Text timeText;
    public Text recordText; 

    private bool isGameOver; 
    private float surviveTime; 
    void Start()
    {
        isGameOver = false;
        surviveTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               
            }
        }
    }

    public void OnPlayerDead() 
    {
        isGameOver = true; 
        gameOverText.SetActive(true);

        //최고기록을 읽기/저장
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}


