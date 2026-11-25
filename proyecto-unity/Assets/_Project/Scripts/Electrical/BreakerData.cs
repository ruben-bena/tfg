using UnityEngine;

[CreateAssetMenu(fileName = "NewBreakerData", menuName = "TFG/Breaker Data")]
public class BreakerData : ScriptableObject
{
    [SerializeField] private BreakerType type;
    [SerializeField] private string shortName;
    [SerializeField] private string fullName;
    [SerializeField, TextArea(3, 6)] private string description;
    [SerializeField] private int ratedCurrent;

    public BreakerType Type => type;
    public string ShortName => shortName;
    public string FullName => fullName;
    public string Description => description;
    public int RatedCurrent => ratedCurrent;

    // Called by Unity whenever a value changes in the Inspector (also on asset load and recompile).
    private void OnValidate()
    {
        if (string.IsNullOrWhiteSpace(shortName))
            Debug.LogWarning($"{name}: Short Name is empty", this);

        if (string.IsNullOrWhiteSpace(fullName))
            Debug.LogWarning($"{name}: Full Name is empty", this);

        if (string.IsNullOrWhiteSpace(description))
            Debug.LogWarning($"{name}: Description is empty", this);

        if (ratedCurrent <= 0)
            Debug.LogWarning($"{name}: Rated Current must be greater than 0", this);
    }
}