using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject thisBall;
    [SerializeField] Transform ballSpawnPoint;
    
    /**/[HideInInspector]public int score=0;
    /**//*[HideInInspector]*/public int sahteScore=0;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    /**/public bool isDead = false, wasKilledBytheEnemy=false;
    [SerializeField]GameOverPauseController gameOverPauseController;
    /**/ public string a = "";
    float timer = 0;
    bool birKere;

    ObstacleController obstacleController;
    private void Start()
    {
        obstacleController = GetComponent<ObstacleController>();
        Invoke("StartDelayed", .0001f);
        score = 0;
        scoreText.text = score.ToString();
        birKere=true;


    }
    private void Update()
    {
        Movement();
        DeadControl();
        
    }
    void StartDelayed()//in the beggining,the ball must be triggered to the background first.Its getting A bug
    {
        thisBall.transform.position = ballSpawnPoint.transform.position;

    }
    void Movement()
    {
        if (!gameOverPauseController.isStopGame)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!obstacleController.solDolu)
                {
                    //a = "";
                    //thisBall.transform.DOMove(thisBall.transform.position + new Vector3(-2.68f, 0), .1f);
                    gameOverPauseController.SoundSource.clip = gameOverPauseController.PressADclip;
                    gameOverPauseController.SoundSource.pitch = 1f;
                    gameOverPauseController.SoundSource.panStereo = -1f;
                    gameOverPauseController.PlayTheSound();
                    thisBall.transform.position += new Vector3(-2.68f, 0);
                }

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (!obstacleController.sagDolu)
                {
                    //a = "";
                    //thisBall.transform.DOMove(thisBall.transform.position + new Vector3(2.68f, 0), .1f);
                    gameOverPauseController.SoundSource.clip = gameOverPauseController.PressADclip;
                    gameOverPauseController.SoundSource.pitch = 1f;
                    gameOverPauseController.SoundSource.panStereo = 1f;

                    gameOverPauseController.PlayTheSound();
                    thisBall.transform.position += new Vector3(2.68f, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (!obstacleController.onDolu)
                {
                    //a = "";
                    //thisBall.transform.DOMove(thisBall.transform.position + new Vector3(0, +1.94f), .1f);
                    gameOverPauseController.SoundSource.clip = gameOverPauseController.PressWclip;
                    gameOverPauseController.SoundSource.pitch = .6f;
                    gameOverPauseController.SoundSource.panStereo = 0f;

                    gameOverPauseController.PlayTheSound();
                    score += 1;
                    sahteScore++;
                    scoreText.text = score.ToString();
                    thisBall.transform.position += new Vector3(0, 1.9364f);
                }

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //a = "";
                //thisBall.transform.DOMove(thisBall.transform.position + new Vector3(0, -1.94f), .1f);
                thisBall.transform.position += new Vector3(0, -1.943f);
            }
        }
       

    }
    void DeadControl()
    {
        if (a.Contains("LevelObjects") && !a.Contains("Enemy"))
            isDead = false;
        else if (a == "" || a.Contains("Enemy"))
            isDead = true;

        timer += Time.deltaTime;
        if (timer > .115f)
            if (isDead && birKere)
            {
                if (a.Contains("Enemy"))
                {
                    wasKilledBytheEnemy = true;
                }
                gameOverPauseController.GameOver();
                birKere = false;
            }
    }
    


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LevelObjects")
        {
            print("aSW");
            a = "";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!a.Contains(collision.gameObject.tag))
        { 
            a += collision.gameObject.tag;
        }

    }




}










//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.gameObject.tag == "LevelDesign" || collision.gameObject.tag == "Enemy")
//    {
//        isDead = true;
//    }

//}
//private void OnTriggerExit2D(Collider2D collision)
//{


//    if (collision.gameObject.tag == "LevelDesign" || collision.gameObject.tag == "Enemy")
//    {
//        isDead = false;
//    }

//}


//timer += Time.deltaTime;
//if (timer > .115f)
//{
//    //print("aaa");
//    if (isDead)
//    {
//        print("dead");
//        //SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
//        //isDead = false;
//    }
//}