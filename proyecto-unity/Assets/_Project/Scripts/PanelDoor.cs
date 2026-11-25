using System;
using UnityEngine;

public class PanelDoor : MonoBehaviour
{
    [SerializeField] private float openAngle = 100f;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private float speedAnimation = 5f;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    void Update()
    {
        Quaternion target = isOpen ? openRotation : closedRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, speedAnimation * Time.deltaTime);
    }

    public void ChangeState()
    {
        isOpen = !isOpen;
    }
}
