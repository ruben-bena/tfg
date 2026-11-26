using System;
using UnityEngine;

public abstract class TutorialStep : MonoBehaviour
{
    [SerializeField, TextArea(2, 4)] private string instruction;
    [SerializeField] private string buttonHint;

    public string Instruction => instruction;
    public string ButtonHint => buttonHint;
    
    public event Action<TutorialStep> Completed;

    public abstract void Enter();
    public abstract void Exit();
    protected void Complete() => Completed?.Invoke(this);
}
