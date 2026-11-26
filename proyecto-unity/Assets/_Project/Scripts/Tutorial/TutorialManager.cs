using System;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialStep[] steps;
    private int currentIndex = -1;

    public event Action<TutorialStep> StepStarted;
    public event Action TutorialCompleted;

    private void Start() => StartStep(0);

    private void StartStep(int index)
    {
        bool isPastLastStep = index >= steps.Length;
        if (isPastLastStep)
        {
            Debug.Log($"{name}: Tutorial complete, no more steps.", this);
            TutorialCompleted?.Invoke();
            return;
        }
        currentIndex = index;
        TutorialStep step = steps[currentIndex];
        step.Completed += OnStepCompleted;
        string progress = $"{currentIndex+1}/{steps.Length}";
        string logLine = $"{name}: step {progress} ({step.name})";
        Debug.Log(logLine, this);
        StepStarted?.Invoke(step);
        step.Enter();
    }

    private void OnStepCompleted(TutorialStep step)
    {
        bool isCurrentStep = step == steps[currentIndex];
        if (!isCurrentStep) return;
        step.Completed -= OnStepCompleted;
        step.Exit();
        int nextIndex = currentIndex + 1;
        StartStep(nextIndex);
    }
}