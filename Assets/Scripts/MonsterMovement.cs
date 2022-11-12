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
    public float distance;
    //public AudioSource bushAudio;




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

        float disBetweenMtoP = Vector3.Distance(this.transform.position, Player.transform.position);
        if(disBetweenMtoP >= distance)
        {

            Destroy(this.gameObject);

        }
        else
        {
            agent.speed = 1.5f;
        }


    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Frame") && Input.GetKeyDown(KeyCode.F))
        {


            
            Destroy(this.gameObject);
            //bushAudio.Stop();


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
