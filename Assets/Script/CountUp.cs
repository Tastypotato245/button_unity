using UnityEngine;
using TMPro; // TextMeshPro

public class CountUp : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private long count = 0;
    public long Count
    {
        get { return count; }
        set { 
            if (count >= 42)
                count = 0;
            else
                count = value;
            }
    }

    private void Start()
    {
        Count = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = Count.ToString();
        }
    }

    public void Counting()
    {
        Count++;
        UpdateText();
    }
}
