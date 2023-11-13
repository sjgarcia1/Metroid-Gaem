using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BigBooletPrefab;
    public GameObject BooletPrefab;
    public GameObject GigaBooletPrefab;
    public bool NeedMoreBoolets = true;
    public bool CanShoot = true;
    public bool BFGtiem = false;
   
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && NeedMoreBoolets == true && CanShoot == true && BFGtiem == false)
        {
            GameObject BooletInstance = Instantiate(BooletPrefab, transform.position, transform.rotation);
            StartCoroutine(BooletCoolDown());
        }

        if (Input.GetMouseButtonDown(0) && NeedMoreBoolets == false && CanShoot == true && BFGtiem == false)
        {
            GameObject BigBooletInstance = Instantiate(BigBooletPrefab, transform.position, transform.rotation);
            StartCoroutine(BooletCoolDown());
        }

        if (Input.GetMouseButtonDown(0) && CanShoot == true && BFGtiem == true)
        {
            GameObject GigaBooletInstance = Instantiate(GigaBooletPrefab, transform.position, transform.rotation);
            BFGtiem = false;
        }


        IEnumerator BooletCoolDown()
        {
            CanShoot = false;
            yield return new WaitForSeconds(1f);
            CanShoot = true;
        }

    }





}
