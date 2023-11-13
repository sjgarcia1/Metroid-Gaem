using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaBoolet : MonoBehaviour
{
    public float speed;
    public bool goingRight;

    void Start()
    {
        StartCoroutine(DespawnDelay());
    }
    void Update()
    {


        if (goingRight)
        {
            transform.position += transform.right * speed * Time.deltaTime;

        }
        else
        {

            transform.position += transform.right * speed * Time.deltaTime;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "REnemy")
        {
            
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BEnemy")
        {
            
            Destroy(other.gameObject);
        }


    }

    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }
}
