using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int curScore;
    public static int highScore = 0;
    public ParticleSystem clouds;
    public GameObject wing;

    [Header("----- Score Display ------")]
    public Text scoreText; // score counter in the corner
    public Text endScoreText; // text that it displays on the gameover page
    public Text hiScoreText;
    public GameObject gameOverScreen;

    [Header("----- Audio ------")]
    public static AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioClip background;
    public AudioClip point;
    public AudioClip death;
    bool deathPlayed = false;

    private void Start() {
        if (Settings.isMuted)
            musicSource.mute = true;
        else
            musicSource.mute = false;
        
        musicSource.clip = background;
        musicSource.Play();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int toAdd) {
        curScore += toAdd;
        scoreText.text = curScore + "";

        if (curScore > highScore) {
            //Debug.Log(curScore + " " + highScore);
            highScore = curScore;
        }

        SFXSource.clip = point;
        SFXSource.Play();
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
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver() {
        endScoreText.text = "Score: " + curScore;
        hiScoreText.text = "High Score: " + highScore;
        scoreText.enabled = false;
        
        gameOverScreen.SetActive(true);
        clouds.Pause();
        wing.GetComponent<Animator>().enabled = false;
        if (!Settings.isMuted) musicSource.Stop();

        if (!deathPlayed) {
            SFXSource.clip = death;
            SFXSource.Play();
            deathPlayed = true;
        }
    }
}