using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]Transform thisBall;
    
    public float xMin = -1.45f;
    public float xMax = 1.45f;
    public float yMin = -6.38f;
    public float yMax = 1000f;
    public float lerpSpeed= 1000f;

    private void Awake()
    {
        thisBall = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    private void Start()
    {
    
    }
   
    void Update()
    {
        // Kameran�n konumunu belirlemek i�in Lerp kullan�n
        Vector3 newPosition = new Vector3(transform.position.x, thisBall.position.y,-10f);

        // Kamera pozisyonunu s�n�rlamak i�in Mathf.Clamp fonksiyonunu kullan�n
        float clampedX = Mathf.Clamp(newPosition.x, xMin, xMax);

        float clampedY =  Mathf.Clamp(newPosition.y, yMin, yMax);


        // Kamera pozisyonunu yeniden belirlemek i�in Lerp fonksiyonunu kullan�n
        transform.position = Vector3.Slerp(transform.position, new Vector3(clampedX, clampedY, -10), Time.deltaTime * lerpSpeed * 0.1f);

    }

}


