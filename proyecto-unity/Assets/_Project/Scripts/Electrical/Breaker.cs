using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class Breaker : MonoBehaviour
{
    [SerializeField] private BreakerData data;
    [SerializeField] private TMP_Text labelText;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private InteractionLayerMask lockedLayers;
    private XRGrabInteractable grab;
    private InteractionLayerMask freeLayers;  

    public BreakerData Data => data;
    public bool IsLocked => grab.interactionLayers == lockedLayers;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        freeLayers = grab.interactionLayers;
        if (!ValidateReferences()) return;
        labelText.text = data.ShortName;
        infoText.text = $"<b>{data.FullName}</b>\n{data.RatedCurrent} A\n\n{data.Description}";
    }

    private bool ValidateReferences()
    {
        bool isValid = true;

        if (!data)
        {
            Debug.LogError($"{name}: BreakerData is not assigned", this);
            isValid = false;
        }
        if (!labelText)
        {
            Debug.LogError($"{name}: Label Text is not assigned", this);
            isValid = false;
        }
        if (!infoText)
        {
            Debug.LogError($"{name}: Info Text is not assigned", this);
            isValid = false;
        }

        return isValid;
    }

    [ContextMenu("Lock")]
    public void Lock() { grab.interactionLayers = lockedLayers; }

    [ContextMenu("Unlock")]
    public void Unlock() { grab.interactionLayers = freeLayers; }
}