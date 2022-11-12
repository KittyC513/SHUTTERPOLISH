using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    //public AudioSource shutterClip;
    // Start is called before the first frame update
    void Start()
    {
        //shutterClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //shutterClip.Play();
            SceneManager.LoadScene(4);
        }

    }
}
