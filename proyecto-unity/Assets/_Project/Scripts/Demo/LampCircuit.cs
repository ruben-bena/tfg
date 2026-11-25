using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LampCircuit : MonoBehaviour
{
    [SerializeField] private Light lightLamp;
    [SerializeField] private XRSocketInteractor railSocket;
    [SerializeField] private bool isLightSwitchActive;
    public void Update()
    {
        bool shouldActivateLight = IsMagnetothermicSwitchedOn(railSocket) && isLightSwitchActive;
        lightLamp.enabled = shouldActivateLight;
    }

    private bool IsMagnetothermicSwitchedOn(XRSocketInteractor railSocket)
    {
        return railSocket.hasSelection;
    }

    public void ChangeState()
    {
        isLightSwitchActive = !isLightSwitchActive;
    }
}
