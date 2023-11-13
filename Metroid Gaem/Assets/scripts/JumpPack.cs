using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPack : MonoBehaviour
{
    public bool exists = true;

    private void Update()
    {
        
        
    }

    public void OnTriggerEnter(Collider other)
    {

        
        exists = false;
        if (exists == false)
        {


            Destroy(this.gameObject);
        }
    }

}
