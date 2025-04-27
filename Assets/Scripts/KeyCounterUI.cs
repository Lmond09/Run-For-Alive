using UnityEngine;
using TMPro;

public class KeyCounterUI : MonoBehaviour
{
    public TextMeshProUGUI keyText;

    public void UpdateKeyDisplay(int count)
    {
        if (keyText != null)
        {
            keyText.text = "Keys: " + count;
        }
    }
}
