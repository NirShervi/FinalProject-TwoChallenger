﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top_Gravity_Button : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            Player1.GetComponent<Player_Movment>().changeGravity();
            Player2.GetComponent<Player_Movment>().changeattribute();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
            buttons[0].GetComponent<Press_Button>().isactive = true;
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}