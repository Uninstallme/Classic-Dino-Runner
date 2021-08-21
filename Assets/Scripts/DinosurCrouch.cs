using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DinosurCrouch : MonoBehaviour
{
    public GameObject stand;
    public GameObject crouch;

    void Start()
    {

    }


    void Update()
    {
        if (CrossPlatformInputManager.GetAxis("Vertical") != -1)
        {
            stand.SetActive(true);
            crouch.SetActive(false);
        }
    }

    void OnTriggerEnter2D() 
    {
        GameObject camera = GameObject.Find("Main Camera");
        GameManager manager = camera.GetComponent<GameManager>();
        manager.collided();
    }
}
