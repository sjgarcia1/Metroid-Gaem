using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{

    public float speed = 10;

    public float jumpForce = 5;

    public int Lives = 3;

    public bool stunned = false;

    public int PHP = 99;

    

    private Rigidbody rigidbodyRef;

    private Rigidbody rigidbpdyRef;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRef = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("leftClick");

        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightClick");
            transform.Rotate(Vector3.up * 180);
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
        if (Lives == 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("game ends");
        }
    }
}
