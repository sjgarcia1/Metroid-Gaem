using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoolet : MonoBehaviour
{
    public float speed;
    public bool goingRight;

    void Update()
    {
        if (goingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "REnemy")
        {
            other.gameObject.GetComponent<Enemy>().REHP--;
            other.gameObject.GetComponent<Enemy>().REHP--;
            other.gameObject.GetComponent<Enemy>().REHP--;

            Destroy(this.gameObject);
        }
    }
}