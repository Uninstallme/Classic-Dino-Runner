using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Vector2 yVelocity;

    float maxHeight = 1f;
    float jumpSpeed;
    float timeToPeak = 0.3f;
    float gravity;
    float groundPosition = 0;

    bool isGrounded = false;

    AudioSource jumpSound;

    public GameObject stand;
    public GameObject crouch;
    public GameObject dead;

    void Start()
    {
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;
        groundPosition = transform.position.y;
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if(transform.position.y <= groundPosition)
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
            isGrounded = true;
            //Debug.Log("Caí");
        }

        if(CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            yVelocity = jumpSpeed * Vector2.up;
            isGrounded = false;
            jumpSound.Play();
        }

        

        if(CrossPlatformInputManager.GetAxis("Vertical") == -1 && isGrounded == true)
        {
            crouch.SetActive(true);
            stand.SetActive(false);
        }

        if(Time.timeScale == 0)
        {
            dead.SetActive(true);
            stand.SetActive(false);
        }
        
      
        transform.position += (Vector3)yVelocity * Time.deltaTime;
    }

    void OnTriggerEnter2D() 
    {
        GameObject camera = GameObject.Find("Main Camera");
        GameManager manager = camera.GetComponent<GameManager>();
        manager.collided();
    }


}
