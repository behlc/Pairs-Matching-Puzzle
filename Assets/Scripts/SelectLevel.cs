using UnityEngine;
using System.Collections;


public class SelectLevel : MonoBehaviour
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

    public void BackToPuzzleLevelsMenu()
    {
        StartCoroutine(ShowPuzzleSelectMenu());

    }

    IEnumerator ShowPuzzleSelectMenu()
    {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SelectPuzzleSlideIn");

        puzzleLevelsAnim.Play("LevelsPanelSlideOut");
        yield return new WaitForSeconds(1f);

        puzzleLevelsPanel.SetActive(false);

    }
}
