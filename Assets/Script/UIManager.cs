using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int Score;
    public AudioSource hitSound;
    public GameObject Panel;
    void Start()
    {
        ResetScore();
        UpdateScore();

    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
    }
    public void UpdateScore()
    {
        hitSound.Play();
        Score = PlayerPrefs.GetInt("score", 0);
        ScoreText.text = Score.ToString();
        if (Score == 6)
        {
            Panel.gameObject.SetActive(true);

        }
    }

    public void RePlay()
    {
        SceneManager.LoadScene(0);
    }


}
