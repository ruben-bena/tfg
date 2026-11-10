using System;
using UnityEngine;

public class PuertaCuadro : MonoBehaviour
{
    [SerializeField] private float openAngle = 100f;
    [SerializeField] private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0f, 100f, 0f);
    }

    void Update()
    {
        transform.localRotation = isOpen ? openRotation : closedRotation;
    }

    public void changeState()
    {
        isOpen = !isOpen;
    }
}
