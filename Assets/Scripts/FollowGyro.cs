using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    private void Start()
    {
        GyroScopeManager.Instance.EnableGyro();
    }

    private void Update()
    {
        transform.localRotation = GyroScopeManager.Instance.GetGyroRotation() * baseRotation;
    }
}
