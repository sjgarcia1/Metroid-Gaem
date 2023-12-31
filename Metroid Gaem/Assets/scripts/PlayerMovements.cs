using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovements : MonoBehaviour
{
    public int totalCoins = 0;

    public float speed = 10;

    public float jumpForce = 5f;

    public float deathYlevel = -7;

    public int Lives = 3;

    public bool stunned = false;

    public int PHP = 99;

    public int maxHP = 99;

    public bool BigBoolets = false;

    public bool JumpPackk = false;

    public float totalScore = 0f;

    public float CoinValue = 5f;

    public GameObject gun;

    public int goldKeysCollected = 0;

    public int BeegerWeyponzCollected = 0;

    private Rigidbody rigidbodyRef;

    private Rigidbody rigidbpdyRef;
    private Vector3 startPos;

    public bool ifright = true;

    public float pos;

    public bool vulnerable = true;

   

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRef = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position.x;

        if (PHP >= maxHP)
        {
            PHP = maxHP;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && stunned == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && stunned == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && stunned == false)
        {
            HandleJump();
        }
        //if (Input.GetButtonDown("Fire1"))
        // {
        //Debug.Log("leftClick");

        // }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightClick");
            transform.Rotate(Vector3.up * 180);

            if (ifright == true)
            {
                ifright = false;


            }
            else
            {
                ifright = true;
            }

            if (transform.position.y <= deathYlevel)
            {
                Respawn();
                Debug.Log("respawn");
            }

        }

        if (PHP <= 0)
        {
            Lives--;
            Respawn();
            
        }

    }
    private void HandleJump()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.3f))
        {
            Debug.Log("player is touching the ground sp jump");
            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }

    private void Respawn()
    {
        Lives--;
        transform.position = startPos;
        PHP = maxHP;
        StartCoroutine(CanHurt());
        StartCoroutine(Blink());
        Debug.Log("Rip Bozo");
        if (Lives == 0)
        {
            SceneManager.LoadScene(2);
            Debug.Log("game ends");
        }
    }

    IEnumerator StunPlayer()
    {
        stunned = true;
        yield return new WaitForSeconds(2f);
        stunned = false;
    }

   

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BeegerWeyponz")
        {
            other.gameObject.GetComponent<BeegerWeyponz>().exists = false;
            other.gameObject.SetActive(false);
            gun.GetComponent<Gun>().NeedMoreBoolets = false;
            BeegerWeyponzCollected++;
            BigBoolets = true;
        }

        if (other.gameObject.tag == "BFG")
        {
            other.gameObject.GetComponent<BFG>().exists = false;
            other.gameObject.SetActive(false);
            gun.GetComponent<Gun>().BFGtiem = true;
        }

        if (other.gameObject.tag == "JumpPack")
        {
            other.GetComponent<JumpPack>().exists = false;
            jumpForce = 12;
            JumpPackk = true;
        }

        if (other.gameObject.tag == "ExtraHeath")
        {
            other.gameObject.GetComponent<ExtraHeath>().Exists = false;
            maxHP = maxHP + 100;
            PHP = maxHP;


        }

        if (other.gameObject.tag == "Heathbar" && PHP < maxHP)
        {
            other.gameObject.GetComponent<Heathbar>().exists = false;
            PHP = PHP + 25;
        }
        
           

        if (other.gameObject.tag == "coin")
        {
            totalScore += CoinValue;
            other.gameObject.SetActive(false);
        }


        if (other.gameObject.tag == "REnemy" && vulnerable == true)


        {
            PHP = PHP - 15;
            StartCoroutine(CanHurt());
            StartCoroutine(Blink());
        }

        if (other.gameObject.tag == "BEnemy" && vulnerable == true)
        {
            PHP = PHP - 35;
            StartCoroutine(CanHurt());
            StartCoroutine(Blink());
        }

        if (other.gameObject.tag == "bucketMan" && vulnerable == true)
        {
            PHP = PHP - 35;
            StartCoroutine(CanHurt());
            StartCoroutine(Blink());
        }

        if (other.gameObject.tag == "GoldKey")
        {
            Debug.Log("collected with GoldKey");
            goldKeysCollected++;
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "LavaDeathFloor")
        {
            Respawn();
        }

        if (other.gameObject.tag == "layzer")
        {
            stunned = true;
        }

        if (other.gameObject.tag == "layzer")
        {
            StartCoroutine(StunPlayer());
        }

        if (other.gameObject.tag == "portal")
        {
            transform.position = other.gameObject.GetComponent<portal>().teleportPoint.transform.position;
            startPos = transform.position;
        }

        if (other.gameObject.tag == "LastPortal")
        {
            SceneManager.LoadScene(2);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GoldenDoor")
        {
            Debug.Log("collided with GoldenDoor");
            if (goldKeysCollected >= other.gameObject.GetComponent<GoldenDoor>().GoldKeysNeeded)
            {
                other.gameObject.SetActive(false);
                goldKeysCollected -= other.gameObject.GetComponent<GoldenDoor>().GoldKeysNeeded;


            }
            else
            {
                Debug.Log("NOT ENOUGH KEYS GO FIND MORE");
            }
        }

        if (other.gameObject.tag == "endDoor")
        {
            Debug.Log("collided with endDoor");
            if (BeegerWeyponzCollected >= other.gameObject.GetComponent<EndOfLevelDoor>().BeegerWeyponzNeeded)
            {
                other.gameObject.SetActive(false);
                
            }
        }


     
    }

    

    IEnumerator CanHurt()
    {
        vulnerable = false;
        yield return new WaitForSeconds(5f);
        vulnerable = true;

    }

    IEnumerator Blink()
    {
        for (int index = 0; index < 52; index++)
        {
            if (index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }

 
}

