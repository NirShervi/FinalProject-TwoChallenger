﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossMovement : MonoBehaviour
{
    public GameObject currentTarget;
    //private GameObject changedTarget;
    public float speed, life;
    //public float forceMulti;
    //private Rigidbody rb;
    //private Quaternion quaternion;
    //private bool changed;
    private NavMeshAgent agent;
    private const float rotSpeed = 50f;
    public GameObject player1;
    public GameObject player2;
    public GameObject target1;
    public GameObject target2;
    public GameObject gameStarter;
    private bool changed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = false;
        speed = 3f;
        changed = true;
        life = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            currentTarget = other.gameObject;
            if (changed)
            {
                target1.SetActive(false);
                target2.SetActive(false);
                gameStarter.GetComponent<gameStarter>().started = true;
                changed = false;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(currentTarget.transform.position); 
            InstantlyTurn(agent.destination);
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if(life == 0)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<bossMovement>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
            
        }
    }

    private void InstantlyTurn(Vector3 destination)
    {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 0.1f) return;

        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * rotSpeed);
    }
}
