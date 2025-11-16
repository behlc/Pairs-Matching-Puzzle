using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadPuzzleGame : MonoBehaviour
{
    [SerializeField] PuzzleGameManager puzzleGameManager;

    [SerializeField] LevelLocker levelLocker;

    [SerializeField] private LayoutPuzzleButtons layoutPuzzleButtons;

    [SerializeField] private GameObject puzzleLevelsPanel;
    [SerializeField] private Animator puzzleLevelsAnim;

    [SerializeField] 
    private GameObject puzzleGamePanel1, puzzleGamePanel2, puzzleGamePanel3, puzzleGamePanel4, puzzleGamePanel5;

    [SerializeField] 
    private Animator puzzleGamePanel1Anim1, puzzleGamePanel1Anim2, puzzleGamePanel1Anim3, puzzleGamePanel1Anim4, puzzleGamePanel1Anim5;

    private int puzzleLevel;
    private string selectedPuzzle;

    private List<Animator> anims;

    public void LoadPuzzle(int level, string puzzle)
    {
        this.puzzleLevel = level;
        this.selectedPuzzle = puzzle;

        layoutPuzzleButtons.LayoutButtons(level, selectedPuzzle);

        // there is five game panel
        switch(puzzleLevel)
        {
            case 0:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel1, puzzleGamePanel1Anim1));
                break;
            case 1:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel2, puzzleGamePanel1Anim2));
                break;
            case 2:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel3, puzzleGamePanel1Anim3));
                break;
            case 3:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel4, puzzleGamePanel1Anim4));
                break;
            case 4:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel5, puzzleGamePanel1Anim5));
                break;
        }
    }

    public void BackToPuzzleLevelSelectMenu()
    {
        anims = puzzleGameManager.ResetGameplay();

        levelLocker.CheckWhichLevelsAreUnlocked(selectedPuzzle);

        switch(puzzleLevel)
        {
            case 0:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel1, puzzleGamePanel1Anim1));
                break;
            case 1:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel2, puzzleGamePanel1Anim2));
                break;
            case 2:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel3, puzzleGamePanel1Anim3));
                break;
            case 3:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel4, puzzleGamePanel1Anim4));
                break;
            case 4:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel5, puzzleGamePanel1Anim5));
                break;
        }

    }

    IEnumerator LoadPuzzleLevelSelectMenu(GameObject puzzleGamePanel, Animator puzzleGamePanelAnim)
    {
        puzzleLevelsPanel.SetActive(true);
        puzzleLevelsAnim.Play("LevelsPanelSlideIn");
        puzzleGamePanelAnim.Play("PuzzleGamePanelSlideOut");

        yield return new WaitForSeconds(1f);

        // fix the rotation of the backside image of the button (happens only if there are images used)
        foreach(Animator anim in anims)
        {
            anim.Play("PuzzleButtonIdle");
        }
        yield return new WaitForSeconds(0.5f);

        puzzleGamePanel.SetActive(false);
    }

    IEnumerator LoadPuzzleGamePanel(GameObject puzzleGamePanel, Animator puzzleGamePanelAnim)
    {
        puzzleGamePanel.SetActive(true);
        puzzleGamePanelAnim.Play("PuzzleGamePanelSlideIn");
        puzzleLevelsAnim.Play("LevelsPanelSlideOut");

        yield return new WaitForSeconds(1f);
        puzzleLevelsPanel.SetActive(false);

    }

}
