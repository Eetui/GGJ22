using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviourSingleton<CameraController>
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    
    public void SetFollowTarget(Transform target)
    {
        vCam.Follow = target;
    }
}
