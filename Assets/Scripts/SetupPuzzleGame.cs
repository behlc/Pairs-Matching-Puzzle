using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetupPuzzleGame : MonoBehaviour
{
    [SerializeField] private PuzzleGameManager puzzleGameManager;

    private Sprite[] fruitPuzzleSprites, animalPuzzleSprites;

    [SerializeField]
    private List<Sprite> gamePuzzles = new List<Sprite>();

    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonsAnimators = new List<Animator>();

    private int level;
    private string selectedPuzzle;
    private int looper;

    void Awake()
    {
        fruitPuzzleSprites = Resources.LoadAll<Sprite>("Arts/FruitsSprites");
        animalPuzzleSprites = Resources.LoadAll<Sprite>("Arts/AnimalsSprites");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelAndPuzzle(int level, string selectedPuzzle)
    {
        this.level = level;
        this.selectedPuzzle = selectedPuzzle;

        PrepareGameSprites();

        puzzleGameManager.SetGamePuzzleSprites(this.gamePuzzles);


    }

    void PrepareGameSprites()
    {
        gamePuzzles.Clear();
        gamePuzzles = new List<Sprite>();
        
        int index = 0;
        switch(level) 
        {
            case 0:
                looper = 4;
                break;
            case 1:
                looper = 6;
                break;
            case 2:
                looper = 8;
                break;
            case 3:
                looper = 10;
                break;
            case 4:
                looper = 12;
                break;
        }

        switch(selectedPuzzle)
        {
            case "FruitsPuzzle" :
                ShuffleSprites(fruitPuzzleSprites);
                for (int i = 0; i < looper; i++)
                {
                    if(index == (looper / 2))
                    {
                        index = 0;
                    }

                    gamePuzzles.Add(fruitPuzzleSprites[index]);
                    index++;
                }
                break;

            case "AnimalsPuzzle" :
                ShuffleSprites(animalPuzzleSprites);

                for (int i = 0; i < looper; i++)
                {
                    if(index == (looper / 2))
                    {
                        index = 0;
                    }
                    gamePuzzles.Add(animalPuzzleSprites[index]);
                    index++;
                }
                break;
        }
        Shuffle(gamePuzzles);
    }

    public void SetPuzzleButtonsAndAnimators(List<Button> puzzleButtons, List<Animator> puzzleButtonsAnimators)
    {
        this.puzzleButtons = puzzleButtons;
        this.puzzleButtonsAnimators = puzzleButtonsAnimators;

        puzzleGameManager.SetUpButtonsAndAnimators(puzzleButtons, puzzleButtonsAnimators);
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void ShuffleSprites(Sprite[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            Sprite temp = arr[i];
            int randomIndex = Random.Range(i, arr.Length);
            arr[i] = arr[randomIndex];
            arr[randomIndex] = temp;
        }
    }



}
