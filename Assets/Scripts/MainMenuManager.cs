using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    [Header("Sliders")]
    public Slider fovSlider;
    public Slider volumeSlider;

    [Header("Camera & Audio")]
    public Camera playerCamera;
    public AudioListener audioListener;

    [Header("Buttons")]
    public GameObject backButton;

    [Header("Value Display Texts")]
    public TextMeshProUGUI fovValueText;
    public TextMeshProUGUI volumeValueText;

    public GameObject exitbuttoninsettings;

    private float originalFOV;
    private float originalVolume;

    private bool isSettingsOpen = false;

    [Header("Key to Toggle")]
    public KeyCode toggleKey = KeyCode.Escape;  // Now default is ESC key

    void Start()
    {
        // Save original values
        originalFOV = playerCamera.fieldOfView;
        originalVolume = AudioListener.volume;

       // Initialize the FOV slider
        if (fovSlider != null && playerCamera != null)
        {
            fovSlider.minValue = 30f; // Set reasonable min FOV
            fovSlider.maxValue = 120f; // Set reasonable max FOV
            fovSlider.value = playerCamera.fieldOfView;
            fovSlider.onValueChanged.AddListener(OnFOVChanged);
        }

        // Same for volume if needed
        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = 1.0f;  // Set slider to 100% initially
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

      
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        backButton.SetActive(false);
        exitbuttoninsettings.SetActive(true);
    }

   public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
    

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OnFOVChanged(float newFOV)
    {
        playerCamera.fieldOfView = newFOV;
        if (fovValueText != null)
            fovValueText.text = Mathf.RoundToInt(newFOV).ToString();  // Round nicely to int
    }

    public void OnVolumeChanged(float newVolume)
    {
        AudioListener.volume = newVolume;
        if (volumeValueText != null)
            volumeValueText.text = (newVolume * 100f).ToString("F0") + "%";  // Show as percentage
    }


    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (settingsPanel != null)
            {
                isSettingsOpen = !isSettingsOpen;
                settingsPanel.SetActive(isSettingsOpen);

                // Optional: Pause/Resume the game
                if (isSettingsOpen)
                    Time.timeScale = 0f;  // Pause game when settings open
                else
                    Time.timeScale = 1f;  // Resume game when settings closed
            }
        }
    }
}