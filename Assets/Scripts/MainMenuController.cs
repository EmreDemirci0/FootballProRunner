using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject MainScreen, SettingsScreen;
    AudioSource SoundSource,MusicSource;
    public bool isSoundOn=true, isMusicOn=true,isVibrationOn;
    [SerializeField] Sprite SoundOnSprite, SoundOffSprite, MusicOnSprite, MusicOffSprite, VibrationOnSprite, VibrationOffSprite;
    [SerializeField] Image SoundImage, MusicImage,VibrationImage;
    [SerializeField] TMPro.TextMeshProUGUI bestScoreText;
    private void Start()
    {
        
        MainScreen.SetActive(true);
        SettingsScreen.SetActive(false);
        SoundSource = GetComponent<AudioSource>();
        MusicSource=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        bestScoreText.text ="BEST SCORE:"+PlayerPrefs.GetInt("BestScore").ToString();
        if (!PlayerPrefs.HasKey("isSoundOn"))
            PlayerPrefs.SetInt("isSoundOn", 1);
        if (!PlayerPrefs.HasKey("isMusicOn"))
            PlayerPrefs.SetInt("isMusicOn", 1);
        

        if (PlayerPrefs.GetInt("isSoundOn") == 0)
        {
            isSoundOn = false;
            SoundImage.sprite = SoundOffSprite;
        }
        else if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            isSoundOn = true;
            SoundImage.sprite = SoundOnSprite;
        }

        if (PlayerPrefs.GetInt("isMusicOn") == 0)
        {
            isMusicOn = false;
            MusicImage.sprite = MusicOffSprite;
            MusicSource.Stop();
        }
        else if (PlayerPrefs.GetInt("isMusicOn") == 1)
        {
            isMusicOn = true;
            MusicImage.sprite = MusicOnSprite;
            MusicSource.Play();
        }

    }
    private void Update()
    {
        print(" 22 :"+PlayerPrefs.GetInt("isSoundOn"));
    }
    public void PlayGame()
    {
        PlayTheSound();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScreen");

    }
    public void OpenSettingsPanel()
    {
        PlayTheSound();

        MainScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        PlayTheSound();

        MainScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }
    public void Sound()
    {
        
        if (isSoundOn)
        {
            SoundImage.sprite = SoundOffSprite;
            isSoundOn = false;
            PlayerPrefs.SetInt("isSoundOn", 0);//0 means off, 1 means on
            SoundSource.Stop();
        }
        else if (!isSoundOn)
        {
            SoundImage.sprite = SoundOnSprite;
            isSoundOn = true;
            PlayerPrefs.SetInt("isSoundOn", 1);
            SoundSource.Play();


        }
       

        //Ayarlanacak
    }
    public void Music()
    {
       
        if (isMusicOn)
        {
            MusicImage.sprite = MusicOffSprite;
            isMusicOn = false;
            PlayerPrefs.SetInt("isMusicOn", 0);//0 means off, 1 means on
            MusicSource.Stop();
        }
        else if (!isMusicOn)
        {
            MusicImage.sprite = MusicOnSprite;
            isMusicOn = true;
            PlayerPrefs.SetInt("isMusicOn", 1);
            MusicSource.Play();

        }
       
    }
    public void Vibration()
    {
        if (isVibrationOn)
        {
            VibrationImage.sprite = VibrationOffSprite;
            isVibrationOn = false;
        }
        else if (!isVibrationOn)
        {
            VibrationImage.sprite = VibrationOnSprite;
            isVibrationOn = true;

        }
    }
    public void ExitGame()
    {
        PlayTheSound();
        Application.Quit();
    }
    private void PlayTheSound()
    {
        if (isSoundOn)
        {
            SoundSource.Play();
        }
    }
}
