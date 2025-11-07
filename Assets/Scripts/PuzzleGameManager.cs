using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleGameManager : MonoBehaviour
{
    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonsAnimators = new List<Animator>();

    [SerializeField]
    private List<Sprite> gamePuzzleSprites = new List<Sprite>();

    private int level;
    private string selectedPuzzle;

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
        Debug.Log("selected button is" + UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
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
}
