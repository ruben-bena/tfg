using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DinRail : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor[] slots;   // left to right: Slot0 … Slot5

    public int SlotCount => slots.Length;

    private void OnEnable()
    {
        foreach (XRSocketInteractor slot in slots)
        {
            slot.selectEntered.AddListener(OnSlotEntered);
            slot.selectExited.AddListener(OnSlotExited);
        }
    }

    private void OnDisable()
    {
        foreach (XRSocketInteractor slot in slots)
        {
            slot.selectEntered.RemoveListener(OnSlotEntered);
            slot.selectExited.RemoveListener(OnSlotExited);
        }
    }

    private void OnSlotEntered(SelectEnterEventArgs args) => LogOccupancy();
    private void OnSlotExited(SelectExitEventArgs args) => LogOccupancy();

    public Breaker GetBreakerAt(int index)
    {
        XRSocketInteractor slot = slots[index];
        if (!slot.hasSelection) return null;
        return slot.firstInteractableSelected.transform.GetComponent<Breaker>();
    }

    private void LogOccupancy()
    {
        string[] parts = new string[slots.Length];
        for (int i=0; i<slots.Length; i++)
        {
            Breaker breaker = GetBreakerAt(i);
            string breakerName = breaker ?
                breaker.Data.ShortName :
                "-";
            parts[i] = $"[{i}] {breakerName}";
        }
        string slotsState = string.Join(" | ", parts);
        Debug.Log($"DinRail: {slotsState}", this);
    }
}