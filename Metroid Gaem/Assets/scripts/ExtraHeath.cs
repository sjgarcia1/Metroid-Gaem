using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHeath : MonoBehaviour
{

    public bool Exists = true;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Exists == false)
        {
            Destroy(this.gameObject);
        }
    }
}
