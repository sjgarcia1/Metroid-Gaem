using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BigBooletPrefab;
    public GameObject BooletPrefab;
    public bool NeedMoreBoolets = true;
    public bool CanShoot = true;
   
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && NeedMoreBoolets == true && CanShoot == true)
        {
            GameObject BooletInstance = Instantiate(BooletPrefab, transform.position, transform.rotation);
            StartCoroutine(BooletCoolDown());
        }

        if (Input.GetMouseButtonDown(0) && NeedMoreBoolets == false && CanShoot == true)
        {
            GameObject BigBooletInstance = Instantiate(BigBooletPrefab, transform.position, transform.rotation);
            StartCoroutine(BooletCoolDown());
        }


        IEnumerator BooletCoolDown()
        {
            CanShoot = false;
            yield return new WaitForSeconds(1f);
            CanShoot = true;
        }

    }





}
