using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public GameObject player;
    public AudioSource pickupClip;
    // Start is called before the first frame update
    void Start()
    {
        pickupClip = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        //Input.GetKeyDown(KeyCode.F)
        if (other.gameObject.tag.Equals("Items") && Input.GetKey(KeyCode.F))
        {
            player.GetComponent<Collection>().collection--;
            pickupClip.Play();
            Destroy(other.gameObject);  
            Debug.Log("Collection");

        }

    }
}
