using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LayoutPuzzleButtons : MonoBehaviour
{
    [SerializeField] private SetupPuzzleGame setupPuzzleGame;

    [SerializeField] Transform puzzleLevel1, puzzleLevel2, puzzleLevel3, puzzleLevel4, puzzleLevel5;
    public List<Button> level1Buttons, level2Buttons, level3Buttons, level4Buttons, level5Buttons;
    public List<Animator> level1Anims, level2Anims, level3Anims, level4Anims, level5Anims;

    //[SerializeField] private Sprite[] puzzleButtonsBacksideImages;
    [SerializeField] private Sprite puzzleButtonsBacksideImage;

    private int puzzleLevel;
    private string selectedPuzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LayoutButtons(int level, string puzzle)
    {
        this.puzzleLevel = level;
        this.selectedPuzzle = puzzle;
        setupPuzzleGame.SetLevelAndPuzzle(puzzleLevel, selectedPuzzle);

        LayoutPuzzle();
    }

    void LayoutPuzzle()
    {
        switch(puzzleLevel) 
        {
            case 0:
                foreach(Button btn in level1Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy)
                    {
                        btn.gameObject.SetActive(true);
                        btn.interactable = true;
                        btn.gameObject.transform.SetParent(puzzleLevel1, false);
                        // use the same image for all the buttons
                        btn.image.sprite = puzzleButtonsBacksideImage;
                    }
                }
                setupPuzzleGame.SetPuzzleButtonsAndAnimators(level1Buttons, level1Anims);
                break;

            case 1:
                foreach(Button btn in level2Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy)
                    {
                        btn.gameObject.SetActive(true);
                        btn.interactable = true;
                        btn.gameObject.transform.SetParent(puzzleLevel2, false);
                        // use the same image for all the buttons
                        btn.image.sprite = puzzleButtonsBacksideImage;
                    }
                }
                setupPuzzleGame.SetPuzzleButtonsAndAnimators(level2Buttons, level2Anims);
                break;

            case 2:
                foreach(Button btn in level3Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy)
                    {
                        btn.gameObject.SetActive(true);
                        btn.interactable = true;
                        btn.gameObject.transform.SetParent(puzzleLevel3, false);
                        // use the same image for all the buttons
                        btn.image.sprite = puzzleButtonsBacksideImage;
                    }
                }
                setupPuzzleGame.SetPuzzleButtonsAndAnimators(level3Buttons, level3Anims);

                break;

            case 3:
                foreach(Button btn in level4Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy)
                    {
                        btn.gameObject.SetActive(true);
                        btn.interactable = true;
                        btn.gameObject.transform.SetParent(puzzleLevel4, false);
                        // use the same image for all the buttons
                        btn.image.sprite = puzzleButtonsBacksideImage;
                    }
                }
                setupPuzzleGame.SetPuzzleButtonsAndAnimators(level4Buttons, level4Anims);

                break;

            case 4:
                foreach(Button btn in level5Buttons)
                {
                    if(!btn.gameObject.activeInHierarchy)
                    {
                        btn.gameObject.SetActive(true);
                        btn.interactable = true;
                        btn.gameObject.transform.SetParent(puzzleLevel5, false);
                        // use the same image for all the buttons
                        btn.image.sprite = puzzleButtonsBacksideImage;
                    }
                }
                setupPuzzleGame.SetPuzzleButtonsAndAnimators(level5Buttons, level5Anims);
                break;
        }
    }

}
