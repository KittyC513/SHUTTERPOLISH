using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushSound : MonoBehaviour
{

    public AudioSource bushClip;
    // Start is called before the first frame update
    void Start()
    {
        bushClip = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Monster"))
        {
            bushClip.Play();
        }
    }
}
