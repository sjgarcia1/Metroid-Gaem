using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 50f;
    public Vector3 spinDerection = Vector3.zero;



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinDerection * spinSpeed * Time.deltaTime);
    }

}
