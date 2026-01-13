using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance;
    public GameObject optionsPanel;
    public Slider volumeSlider;
    public Text volumeText;

    private float masterVolume = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.minValue = 1;
            volumeSlider.maxValue = 100;
            volumeSlider.wholeNumbers = true;

            if (PlayerPrefs.HasKey("MasterVolume"))
                masterVolume = PlayerPrefs.GetFloat("MasterVolume");

            volumeSlider.value = masterVolume * 100f;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        if (optionsPanel != null)
            optionsPanel.SetActive(false);

        OnVolumeChanged(volumeSlider != null ? volumeSlider.value : 100f);
    }

    public void OpenOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        masterVolume = 1f;
        if (volumeSlider != null)
            volumeSlider.value = 100f;
        AudioListener.volume = 1f;
    }

    public void OnVolumeChanged(float newVolume)
    {
        masterVolume = newVolume / 100f;
        AudioListener.volume = masterVolume;

        if (volumeText != null)
            volumeText.text = "Volume: " + newVolume.ToString("F0") + "%";

        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();
    }
}
