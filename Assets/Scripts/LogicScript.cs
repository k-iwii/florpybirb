using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public ParticleSystem clouds;
    public GameObject wing;

    [Header("----- Score Display ------")]
    public Text scoreText; // score counter in the corner
    public Text endScoreText; // text that it displays on the gameover page
    public Text hiScoreText;
    public GameObject gameOverScreen;
    int curScore;
    static int highScore = 0;

    [Header("----- Coin Display ------")]
    public TextMeshProUGUI coinText;
    int curCoins;

    [Header("----- Audio ------")]
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioClip background;
    public AudioClip point;
    public AudioClip death;
    bool deathPlayed = false;

    private void Start() {
        musicSource.mute = false;
        musicSource.clip = background;
        musicSource.Play();

        if (PlayerPrefs.HasKey("highScore"))
            highScore = PlayerPrefs.GetInt("highScore");
        
        if (!PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins", 0);
        else
            curCoins = PlayerPrefs.GetInt("coins");
    }

    [ContextMenu("Increase Score")]
    public void addScore(int toAdd) {
        curScore += toAdd;
        scoreText.text = "pts: " + curScore;

        if (curScore > highScore) {
            //Debug.Log(curScore + " " + highScore);
            highScore = curScore;
        }

        SFXSource.clip = point;
        SFXSource.Play();
    }

    public void addCoins() {
        curCoins++;
        coinText.text = "Coins: " + curCoins;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        BirdScript.setAlive(true);
        // Debug.Log(highScore);
        deathPlayed = false;
        clouds.Play();
        musicSource.Play();
    }

    public void Exit() {
        if (PlayerPrefs.HasKey("highScore")) {
            if (highScore > PlayerPrefs.GetInt("highScore"))
                PlayerPrefs.SetInt("highScore", highScore);
        } else
            PlayerPrefs.SetInt("highScore", highScore);

        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver() {
        endScoreText.text = "Score: " + curScore;
        hiScoreText.text = "High Score: " + highScore;
        scoreText.enabled = false;

        coinText.enabled = false;
        PlayerPrefs.SetInt("coins", curCoins);
        
        gameOverScreen.SetActive(true);
        clouds.Pause();
        wing.GetComponent<Animator>().enabled = false;
        musicSource.Stop();

        if (!deathPlayed) {
            SFXSource.clip = death;
            SFXSource.Play();
            deathPlayed = true;
        }
    }
}