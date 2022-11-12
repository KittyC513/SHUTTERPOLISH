using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        mouseX = -6;
        mouseY = -90;
    }

    // Update is called once per frame
    void Update()
    {
        
        //mouse input
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        Debug.Log(mouseX);
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;
        Debug.Log(mouseY);

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }
}
