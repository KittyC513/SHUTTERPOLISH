using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{

    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private bool gyroActive;
    private Quaternion rotation;


    private void Start()
    {
        
    }



    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
        }
    }


    public void EnableGyro()
    {
        if (gyroActive)
            return;
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
            
        }

        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }
    
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }




}
