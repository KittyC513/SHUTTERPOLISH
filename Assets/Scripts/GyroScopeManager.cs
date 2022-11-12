using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScopeManager : MonoBehaviour
{
    #region Instance
    private static GyroScopeManager instance;
    public static GyroScopeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroScopeManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroScopeManager)).GetComponent<GyroScopeManager>();
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
    private Quaternion rotation;
    private bool gyroActive;

    public void EnableGyro()
    {
        if (gyroActive)
            return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        gyroActive = gyro.enabled;
    }
    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
            Debug.Log(rotation);
        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
