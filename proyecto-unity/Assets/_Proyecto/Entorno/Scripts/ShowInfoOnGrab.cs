using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Magnetotermico : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private XRGrabInteractable grab;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnDrop);
    }

    void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
        grab.selectExited.RemoveListener(OnDrop);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        bool shouldBeActive = IsHand(args.interactorObject);
        panel.SetActive(shouldBeActive);
    }

    private void OnDrop(SelectExitEventArgs args)
    {
        panel.SetActive(false);
    }

    private bool IsHand(IXRSelectInteractor interactor)
    {
        return interactor.handedness != InteractorHandedness.None;
    }
}
