using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoretext;
    public GameObject playbutton;
    public GameObject gameover;
    private int _score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameover.SetActive(false);
        Pause();
    }

    public void Play()
    {
        _score = 0;
        scoretext.text = _score.ToString();
        gameover.SetActive(false);
        playbutton.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameover.SetActive(true);
        playbutton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        _score++;
        scoretext.text = _score.ToString();
    }
}
