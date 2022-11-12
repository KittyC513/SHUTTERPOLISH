using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement: MonoBehaviour
{

    public Transform Player;

    private NavMeshAgent agent;
    PlayerMovement playerMovement;

    public GameObject[] walls;
    //public AudioSource bushAudio;

    public float outOfRange;
    public float runningSpeed;
    public float walkingSpeed;




    //AudioSource bushAudio;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
        playerMovement = GetComponent<PlayerMovement>();

        //bushAudio = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.position);
        float disMtoP = Vector3.Distance(this.transform.position, Player.transform.position);

        if (disMtoP >= outOfRange)
        {
            agent.speed = runningSpeed;
        }
        else
        {
            agent.speed = walkingSpeed;
        }


    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Frame") && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(this.gameObject);
            playerMovement.audioGhost.Stop();

            //bushAudio.Stop();
            playerMovement.stop = false;

        }

       
    }


    /*IEnumerator SelfDestruct()
    {
        
        yield return new WaitForSeconds(5f);
        
        //playerMovement.StartCoroutine(playerMovement.waitSpawner());

        Destroy(gameObject);

    }
    */

}
