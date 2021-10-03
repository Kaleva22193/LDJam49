using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] Slider audioSlider;
    [SerializeField] TMP_Text audioTextLabel;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text lowestScoreText;
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Text resolutionText;
    Resolution[] resolutions;

    private void Start()
    {
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(true);

        if (PlayerPrefs.HasKey("High_Score"))
        {
            highScoreText.text = PlayerPrefs.GetFloat("High_Score").ToString("0.0");
        }
        else
        {
            highScoreText.text = "???????";
        }
        if (PlayerPrefs.HasKey("Lowest_Score"))
        {
            lowestScoreText.text = PlayerPrefs.GetFloat("Lowest_Score").ToString("0.0");
        }
        else
        {
            lowestScoreText.text = "???????";
        }

        audioSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        //resolutionDropdown = GetComponent<Dropdown>();
        resolutionDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(resolutionDropdown); });
        resolutionText.text = resolutionDropdown.name;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsMenu()
    {
        if (!settingsMenu.activeInHierarchy)
        {
            settingsMenu.SetActive(true);
            mainMenuButtons.SetActive(false);
        }
    }
    public void ReturnToMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenuButtons.SetActive(true);
    }
    public void ValueChangeCheck()
    {
        audioTextLabel.color = new Color(audioTextLabel.color.r, audioTextLabel.color.g, audioTextLabel.color.b, audioSlider.value);
    }
    public void DropdownValueChanged(Dropdown dropdown)
    {

    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
 

