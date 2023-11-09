using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Boolet : MonoBehaviour
{
    public float speed;
    public bool goingRight;
    
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
        StartCoroutine(DespawnDelay());

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "REnemy")
        {
            other.gameObject.GetComponent<Enemy>().REHP--;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "BEnemy")
        {
            other.gameObject.GetComponent<BigEnemy>().BEHP--;
            Destroy(this.gameObject);
        }


    }

    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }
}
