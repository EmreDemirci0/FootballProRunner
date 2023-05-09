using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject thisBall;
    [SerializeField] Transform FirstLevelDesgnPrefab, FirstBGDesgnPrefab;
    [SerializeField] GameObject[] LevelDesignPrefab;
    [SerializeField] GameObject BGPrefab;
    [SerializeField] float rayLenght = 3;
    public bool onDolu, solDolu, sagDolu;
    public bool onDoluEnemy, solDoluEnemy, sagDoluEnemy;
    float timer,timer2;
    int i = 3,j=4,x=0;
    BallController ballController;
    /**/[SerializeField]List<GameObject> levels = new List<GameObject>();
    private void Start()
    {
        ballController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
        CreateLevel(1); CreateLevel(2);
    }
    void SetTimeForCreateLevelorBG()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {

            CreateLevel(i);
            i++;

            timer = 0;
        }
        timer2 += Time.deltaTime;
        if (timer2 > 5)
        {
            CreateBG(j);
            j++;
            timer2 = 0;
        }
    }
    void DestroyExLevels() {
        if (ballController.sahteScore > 14)
        {
            Destroy(levels[x]);
            x++;
            //levels.Remove(levels[0]);
            ballController.sahteScore = 0;
        }
    }
    void Update()
    {
        CheckLeftRightUp();
        SetTimeForCreateLevelorBG();
        DestroyExLevels();



    }
    void CreateLevel(int i)
    {
        //GameObject level = Instantiate(LevelDesignPrefab,new Vector3(2.2f,11.2f,0),Quaternion.identity);
        int random = Random.Range(0,LevelDesignPrefab.Length);
        GameObject level = Instantiate(LevelDesignPrefab[random], FirstLevelDesgnPrefab.transform.position + new Vector3(0, 19.36f*i, 0), Quaternion.identity);
        levels.Add(level);
        
        print("i:"+i);
        
        //Destroy(level,20);
    }
    void CreateBG(int i)
    {
        GameObject level = Instantiate(BGPrefab, FirstBGDesgnPrefab.transform.position +new Vector3(0, 44.8f * i, 0), Quaternion.identity);

    }
    void CheckLeftRightUp()
    {
        Vector2 rayDirection = Vector2.up;
        RaycastHit2D hit = Physics2D.Raycast(thisBall.transform.position, rayDirection, rayLenght, LayerMask.GetMask("Obstacles"));
        if (hit.collider != null && hit.collider.CompareTag("Obstacles"))
            onDolu = true;
        else
            onDolu = false;



        Vector2 rayDirection2 = Vector2.right;
        RaycastHit2D hit2 = Physics2D.Raycast(thisBall.transform.position, rayDirection2, rayLenght, LayerMask.GetMask("Obstacles"));
        if (hit2.collider != null && hit2.collider.CompareTag("Obstacles"))
            sagDolu = true;
        else
            sagDolu = false;



        Vector2 rayDirection3 = Vector2.left;
        RaycastHit2D hit3 = Physics2D.Raycast(thisBall.transform.position, rayDirection3, rayLenght, LayerMask.GetMask("Obstacles"));
        if (hit3.collider != null && hit3.collider.CompareTag("Obstacles"))
            solDolu = true;
        else
            solDolu = false;

    }
    
   
}

















////*********************************************************************
////alttakiler bos

//RaycastHit2D hit4 = Physics2D.Raycast(thisBall.transform.position, rayDirection, rayLenght, LayerMask.GetMask("Enemy"));
//if (hit4.collider != null && hit4.collider.CompareTag("Enemy"))
//    onDoluEnemy = true;
//else
//    onDoluEnemy = false;



//RaycastHit2D hit5 = Physics2D.Raycast(thisBall.transform.position, rayDirection2, rayLenght, LayerMask.GetMask("Enemy"));
//if (hit5.collider != null && hit5.collider.CompareTag("Enemy"))
//    sagDoluEnemy = true;
//else
//    sagDoluEnemy = false;



//RaycastHit2D hit6 = Physics2D.Raycast(thisBall.transform.position, rayDirection3, rayLenght, LayerMask.GetMask("Enemy"));
//if (hit6.collider != null && hit6.collider.CompareTag("Enemy"))
//    solDoluEnemy = true;
//else
//    solDoluEnemy = false;