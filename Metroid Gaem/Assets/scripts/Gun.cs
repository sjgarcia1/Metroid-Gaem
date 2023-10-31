using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BigBooletPrefab;
    public GameObject BooletPrefab;
    public bool NeedMoreBoolets = true;
   
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && NeedMoreBoolets == true)
        {
            GameObject BooletInstance = Instantiate(BooletPrefab, transform.position, transform.rotation);
        }

        if (Input.GetMouseButtonDown(0) && NeedMoreBoolets == false)
        {
            GameObject BigBooletInstance = Instantiate(BigBooletPrefab, transform.position, transform.rotation);
        }

        


    }





}
