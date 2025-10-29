using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    private AudioSource audioSource;
    public AudioClip[] clip;

    public float addScore;
    public float currentScore;
    public float highScore;
    private bool doOnce = false;

    public Text currentText;
    public Text highScoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        doOnce = false;
        audioSource = GetComponent<AudioSource>();
        currentText.text = currentScore.ToString();
        highScoreText.text = PlayerPrefs.GetFloat("highScore").ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetFloat("highScore", 0);
        }
    }

    public void HighScore()
    {
        audioSource.PlayOneShot(clip[0]);
        if (currentScore >= PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", currentScore);
            highScoreText.text = currentScore.ToString();
            if (!doOnce)
            {
                audioSource.PlayOneShot(clip[1]);
                doOnce = true;
            }
        }
    }

    public void AddScore()
    {
        currentScore += addScore;
        currentText.text = currentScore.ToString();
        HighScore();
    }
}
