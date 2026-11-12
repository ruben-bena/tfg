using UnityEngine;

public class FaceAtPlayer : MonoBehaviour
{
    private Camera playerCamera;
    void Awake()
    {
        playerCamera = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 direction = transform.position - playerCamera.transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}