using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    
    public float speed;
    private float startingX;
    public int BEHP = 10;
    public GameObject BarrelMan;
    public float pos;
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position.x;

        if (pos <= BarrelMan.GetComponent<PlayerMovements>().pos)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (BEHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
