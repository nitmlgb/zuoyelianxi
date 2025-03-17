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

    public float duration = 1f; // ������ʱ�䣨�룩

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;//Ŀ��֡����
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

        Pipes[] pipes=FindObjectsOfType<Pipes>();//���ùܵ�
        for(int i = 0; i < pipes.Length; i++)//ɾ�����йܵ�
        {
            Destroy(pipes[i].gameObject);
        }
        Jinbi[] jinbis = FindObjectsOfType<Jinbi>();//���ý��
        for (int i = 0; i < jinbis.Length; i++)//ɾ�����н��
        {
            Destroy(jinbis[i].gameObject);

        }

    }
    public void Pause()//��ͣ
    {
        Time.timeScale = 0f;
        player.enabled = false;//���ò�����
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
            scoreOver.text = "Congratulations on your success ������\nPlease proceed to the next level";
            
        }
        else if(score<10)
        {
            scoreOver.text = "Your Score is " + scoreText.text + "\n Please keep up the good work";
        }
        
    }
    
}
