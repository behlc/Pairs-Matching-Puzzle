using UnityEngine;
using System.Collections;


public class SelectLevel : MonoBehaviour
{
    [SerializeField] private PuzzleGameManager puzzleGameManager;

    [SerializeField] private LevelLocker levelLocker;

    [SerializeField] private LoadPuzzleGame loadPuzzleGame;
    // this is a script

    [SerializeField] private PuzzleGameSaver puzzleGameSaver;

    [SerializeField] private GameObject selectPuzzleMenuPanel;
    [SerializeField] private Animator selectPuzzleMenuAnim;

    [SerializeField] private GameObject puzzleLevelsPanel;  
    [SerializeField] private Animator puzzleLevelsAnim;

    private string selectedPuzzle;
    private bool[] puzzle;

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
        puzzleGameSaver.SaveGameData();
        
    }

    IEnumerator ShowPuzzleSelectMenu()
    {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SelectPuzzleSlideIn");

        puzzleLevelsAnim.Play("LevelsPanelSlideOut");
        yield return new WaitForSeconds(1f);

        puzzleLevelsPanel.SetActive(false);
    }

    public void SelectPuzzleLevel()
    {
        int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        puzzle = levelLocker.GetPuzzleLevels(selectedPuzzle);

        if(puzzle[level]) 
        {
            puzzleGameManager.SetLevel(level);
            loadPuzzleGame.LoadPuzzle(level, selectedPuzzle);
        }
    }

    public void SetSelectedPuzzle(string selectedPuzzle)
    {
        // set the selectedPuzzle variable in this script to the selectedPuzzle parameter
        this.selectedPuzzle = selectedPuzzle;
        
    }
}
