using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPauseController : MonoBehaviour
{
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] TMPro.TextMeshProUGUI ScoreText, BestScoreText;
    [SerializeField] BallController ballController;
    [HideInInspector]public bool isStopGame = false;
   [HideInInspector]public AudioSource SoundSource,MusicSource;
    [SerializeField]AudioClip buttonClickClip, gameOverClip, gameOverEnemyClip;
    public AudioClip PressWclip, PressADclip;


    private void Start()
    {
        GameOverCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        SoundSource = GetComponent<AudioSource>();
        MusicSource =GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("isSoundOn")==0)
        {
            SoundSource.Stop();
        }
        if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            //SoundSource.Play();
        }
        if (PlayerPrefs.GetInt("isMusicOn") == 0)
        {
            MusicSource.Stop();
        }
        if (PlayerPrefs.GetInt("isMusicOn") == 1)
        {
            MusicSource.Play();
        }

    }
    private void Update()
    {   

        Debug.Log("Kurbaða vurunca ses çýksýn"+ PlayerPrefs.GetInt("isSoundOn"));
        if (PauseCanvas.activeSelf || GameOverCanvas.activeSelf)
            isStopGame = true;
        else
            isStopGame = false;
    }



    internal void GameOver()
    {
        GameOverCanvas.SetActive(true);
        ScoreText.text = "SCORE:"+ ballController.score.ToString();
        if (PlayerPrefs.GetInt("BestScore")<ballController.score)
        {
            PlayerPrefs.SetInt("BestScore",ballController.score);

        }
        BestScoreText.text = "BEST SCORE:" + PlayerPrefs.GetInt("BestScore").ToString();
        if (ballController.wasKilledBytheEnemy)
        {
            SoundSource.clip = gameOverEnemyClip;

        }
        else
        {
            SoundSource.clip = gameOverClip;

        }
        SoundSource.pitch = 1;
        SoundSource.panStereo = 0;

        PlayTheSound();



    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScreen");
        SoundSource.clip = buttonClickClip;
        SoundSource.pitch = 1;
        SoundSource.panStereo = 0;

        PlayTheSound();
    }
    
    
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
        SoundSource.clip = buttonClickClip;
        SoundSource.pitch = 1;
        SoundSource.panStereo = 0;

        PlayTheSound();

    }
    public void ContinueGame()
    {
        
        PauseCanvas.SetActive(false);
        SoundSource.clip = buttonClickClip;
        SoundSource.pitch = 1;
        SoundSource.panStereo = 0;

        PlayTheSound();


    }
    public void PauseGame()
    {
      

        PauseCanvas.SetActive(true);
        SoundSource.clip = buttonClickClip;
        SoundSource.panStereo = 0;
        SoundSource.pitch = 1;

        PlayTheSound();





    }
    public void PlayTheSound()
    {
        if (PlayerPrefs.GetInt("isSoundOn")==1)
        {
            SoundSource.Play();
        }
    }
}
