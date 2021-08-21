using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurDead : MonoBehaviour
{
    public GameObject stand;
    public GameObject dead;

    void Start()
    {

    }


    void Update()
    {
        if (Time.timeScale == 0)
        {
            stand.SetActive(false);
            dead.SetActive(true);
        }
    }
}
