using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float travelDistanceRight = 0f;
    public float travelDistanceLeft = 0f;
    public float speed;
    private float startingX;
    public int REHP = 1;
    private bool movingRight = true;
    public float EnemyValue = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;


            }
            else
            {
                movingRight = false;
            }


        }
        else
        {
            
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                

            }
            else
            {
                movingRight = true;
            }
        }

        if (REHP <= 0)
        {
            Destroy(this.gameObject);
           
        }
    }
}
