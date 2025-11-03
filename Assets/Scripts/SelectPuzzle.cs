using UnityEngine;
using System.Collections;

public class SelectPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject selectPuzzleMenuPanel;
    [SerializeField] private Animator selectPuzzleMenuAnim;

    [SerializeField] private GameObject puzzleLevelsPanel;  
    [SerializeField] private Animator puzzleLevelsAnim;

    private string selectedPuzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedPuzzle()
    {
        selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        StartCoroutine(ShowPuzzleLevelSelectMenu());
    }

    IEnumerator ShowPuzzleLevelSelectMenu()
    {
        puzzleLevelsPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SelectPuzzleSlideOut");

        puzzleLevelsAnim.Play("LevelsPanelSlideIn");
        yield return new WaitForSeconds(1f);

        selectPuzzleMenuPanel.SetActive(false);


    }
}
