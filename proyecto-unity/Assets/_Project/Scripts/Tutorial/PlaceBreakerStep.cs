using UnityEngine;

public class PlaceBreakerStep : TutorialStep
{
    [SerializeField] private DinRail rail;
    [SerializeField] private Breaker target;
    [SerializeField] private int expectedSlotIndex;

    private void Awake()
    {
        ValidateReferences();
    }

    public override void Enter()
    {
        rail.BreakerInserted += OnBreakerInserted;
    }

    public override void Exit()
    {
        rail.BreakerInserted -= OnBreakerInserted;
    }

    private void OnBreakerInserted(Breaker breaker, int slotIndex)
    {
        bool isExpectedBreaker = breaker == target;
        if (!isExpectedBreaker) return;
        bool isCorrectSlot = slotIndex == expectedSlotIndex;
        if (!isCorrectSlot)
        {
            string logLine = $"{name}: {breaker.Data.ShortName} placed in slot {slotIndex}, expected slot {expectedSlotIndex}";
            Debug.Log(logLine, this);
            return;
        }
        target.Lock();
        Complete();
    }

    private void ValidateReferences()
    {
        if (!rail) Debug.LogError($"{name}: DinRail ${nameof(rail)} is not assigned", this);
        if (!target) Debug.LogError($"{name}: Breaker ${nameof(target)} is not assigned", this);
    }
}
