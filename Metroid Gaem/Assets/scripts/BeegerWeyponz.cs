using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeegerWeyponz : MonoBehaviour
{
    public bool exists = true;

    private void Update()
    {
        if (exists == false)
        {

            
            Destroy(this.gameObject);
        }
    }
}
