using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PuzzleGameManager : MonoBehaviour
{
    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonsAnimators = new List<Animator>();

    [SerializeField]
    private List<Sprite> gamePuzzleSprites = new List<Sprite>();

    private int level;
    private string selectedPuzzle;

    // boolean variables are set to false by default
    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private Sprite puzzleBackgroundImage;

    private int countTryGuess;
    private int countCorrectGuess;
    private int gameGuess;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickAPuzzle()
    {
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzleSprites[firstGuessIndex].name;
            StartCoroutine(TurnPuzzleButtonUp(puzzleButtonsAnimators[firstGuessIndex], puzzleButtons[firstGuessIndex], gamePuzzleSprites[firstGuessIndex]));

        } else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzleSprites[secondGuessIndex].name;
            StartCoroutine(TurnPuzzleButtonUp(puzzleButtonsAnimators[secondGuessIndex], puzzleButtons[secondGuessIndex], gamePuzzleSprites[secondGuessIndex]));
            StartCoroutine(CheckIfThePuzzlesMatch(puzzleBackgroundImage));

            countTryGuess++;
        }

    }

    IEnumerator TurnPuzzleButtonUp(Animator anim, Button btn, Sprite puzzleImage)
    {
        anim.Play("PuzzleButtonTurnUp");
        yield return new WaitForSeconds(0.4f);
        btn.image.sprite = puzzleImage;

    }

    IEnumerator TurnPuzzleButtonBack(Animator anim, Button btn, Sprite puzzleImage)
    {
        anim.Play("PuzzleButtonTurnBack");
        yield return new WaitForSeconds(0.4f);
        btn.image.sprite = puzzleImage;

    }

    IEnumerator CheckIfThePuzzlesMatch(Sprite puzzleBackgroundImage)
    {
        yield return new WaitForSeconds(1.7f);
        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            puzzleButtonsAnimators[firstGuessIndex].Play("PuzzleButtonFadeOut");
            puzzleButtonsAnimators[secondGuessIndex].Play("PuzzleButtonFadeOut");

            //increment score
            CheckIfTheGameIsFinished();

        } else
        {
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimators[firstGuessIndex], puzzleButtons[firstGuessIndex], puzzleBackgroundImage));
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimators[secondGuessIndex], puzzleButtons[secondGuessIndex], puzzleBackgroundImage));
        }
        yield return new WaitForSeconds(0.7f);
        firstGuess = false;
        secondGuess = false;
    }


    void AddListeners()
    {
        foreach (Button btn in puzzleButtons)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void SetUpButtonsAndAnimators(List<Button> buttons, List<Animator> animators)
    {
        this.puzzleButtons = buttons;
        this.puzzleButtonsAnimators = animators;

        gameGuess = puzzleButtons.Count / 2;
        puzzleBackgroundImage = puzzleButtons[0].image.sprite;

        AddListeners();

    }

    public void SetGamePuzzleSprites(List<Sprite> gamePuzzlesSprites)
    {
        this.gamePuzzleSprites = gamePuzzlesSprites;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetSelectedPuzzle(string selectedPuzzle)
    {
        this.selectedPuzzle = selectedPuzzle;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuess++;
        if(countCorrectGuess == gameGuess)
        {
            Debug.Log("Game ends");
        }
    }
}
