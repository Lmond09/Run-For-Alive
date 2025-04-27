using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleUIWithKeyboard : MonoBehaviour
{
    [Header("UI Canvas to Toggle")]
    public GameObject uiCanvas;

    [Header("Key to Toggle UI")]
    public Key toggleKey = Key.M;  // You can still assign in Inspector if needed

    void Update()
    {
        // Convert legacy KeyCode to new InputSystem Key enum
        var key = (Key)System.Enum.Parse(typeof(Key), toggleKey.ToString());

        if (Keyboard.current[key].wasPressedThisFrame)
        {
            if (uiCanvas != null)
            {
                uiCanvas.SetActive(!uiCanvas.activeSelf);
            }
        }
    }
}
