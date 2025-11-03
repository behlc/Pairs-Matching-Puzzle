using UnityEngine;
using System.Collections;

public class SettingsController : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Animator settingsPanelAnim;

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

}
