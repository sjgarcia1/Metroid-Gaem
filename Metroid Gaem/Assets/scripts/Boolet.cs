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

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "REnemy")
        {
            other.gameObject.GetComponent<Enemy>().REHP--;
            Destroy(this.gameObject);
        }


    }

}
