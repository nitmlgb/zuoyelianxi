using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Text scoreOver;
    public Text scoreOver1;

    public float duration = 1f; // 持续的时间（秒）

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;//目标帧速率
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text=score.ToString();
        
        playButton.SetActive(false);
        gameOver.SetActive(false);
        scoreOver.gameObject.SetActive(false);
        scoreOver1.gameObject.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes=FindObjectsOfType<Pipes>();//引用管道
        for(int i = 0; i < pipes.Length; i++)//删除所有管道
        {
            Destroy(pipes[i].gameObject);
        }
        Jinbi[] jinbis = FindObjectsOfType<Jinbi>();//引用金币
        for (int i = 0; i < jinbis.Length; i++)//删除所有金币
        {
            Destroy(jinbis[i].gameObject);

        }

    }
    public void Pause()//暂停
    {
        Time.timeScale = 0f;
        player.enabled = false;//禁用播放器
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        if (score >= 10)
        {
            scoreOver.gameObject.SetActive(true);
            //scoreOver1.gameObject.SetActive(true);
            Pipes.initialSpeed += 6f;
            Jinbi.initialSpeed += 6f;
            
        }
        else if(score<10)
        {
            scoreOver.gameObject.SetActive(true);
        }
        
        player.transform.localScale = new Vector2(0.5f, 0.5f);

        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >= 10)
        {
            scoreOver.text = "Congratulations on your success ！！！\nPlease proceed to the next level";
            
        }
        else if(score<10)
        {
            scoreOver.text = "Your Score is " + scoreText.text + "\n Please keep up the good work";
        }
        
    }
    
}
