using TMPro;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    [SerializeField] private BreakerData data;
    [SerializeField] private TMP_Text labelText;
    [SerializeField] private TMP_Text infoText;

    public BreakerData Data => data;

    private void Awake()
    {
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
}