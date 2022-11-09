using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdate : MonoBehaviour
{

    public GameObject player;
    PlayerMovement playerMovement;
    public float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Monster"))
        {

            Destroy(other.gameObject);
            Debug.Log("You are attacked");
            player.GetComponent<Health>().health--;
            playerMovement.audioGhost.Stop();
            playerMovement.stop = false;
            playerMovement.startWait = 10;
            playerMovement.StartCoroutine(playerMovement.waitSpawnFunction());
            //playerMovement.StartCoroutine(playerMovement.waitSpawner());
            
        }
        
    }
}
