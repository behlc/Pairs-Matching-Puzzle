using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] MusicController musicController;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Animator settingsPanelAnim;

    [SerializeField] private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettingsPanel()
    {
        slider.value = musicController.GetMusicVolume();
        settingsPanel.SetActive(true);
        settingsPanelAnim.Play("SettingsPanelSlideIn");
    }

    public void CloseSettingsPanel()
    {
        StartCoroutine(CloseSettings());
    }

    IEnumerator CloseSettings()
    {
        settingsPanelAnim.Play("SettingsPanelSlideOut");
        yield return new WaitForSeconds(1f);
        settingsPanel.SetActive(false);
    }

    public void GetVolume(float volume)
    {
        musicController.SetMusicVolume(volume);
    }

}
