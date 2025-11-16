using UnityEngine;
using System.Collections;

public class LevelLocker : MonoBehaviour
{
    [SerializeField]
    private PuzzleGameSaver puzzleGameSaver;

    [SerializeField]
    private StarsLocker starsLocker;

    [SerializeField]
    private GameObject[] levelStarsHolders;

    [SerializeField]
    private GameObject[] levelsPadlocks;

    private bool[] fruitPuzzleLevels;
    private bool[] animalPuzzleLevels;

    void Awake()
    {
        DeactivatedPadlocksAndStarHolders();
    }

    void Start()
    {
        GetLevels();
    }

    public void CheckWhichLevelsAreUnlocked(string selectedPuzzle)
    {
        DeactivatedPadlocksAndStarHolders();
        GetLevels();

        switch(selectedPuzzle)
        {
            case "FruitsPuzzle":
                for (int i = 0; i < fruitPuzzleLevels.Length; i++)
                {
                    if(fruitPuzzleLevels[i])
                    {
                        levelStarsHolders[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    } else
                    {
                        levelsPadlocks[i].SetActive(true);
                    }
                }
                break;

            case "AnimalsPuzzle":
                for (int i = 0; i < animalPuzzleLevels.Length; i++)
                {
                    if(animalPuzzleLevels[i])
                    {
                        levelStarsHolders[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    } else
                    {
                        levelsPadlocks[i].SetActive(true);
                    }
                }
                break;
        }
    }

    void DeactivatedPadlocksAndStarHolders()
    {
        for(int i = 0; i < levelStarsHolders.Length; i++)
        {
            levelStarsHolders[i].SetActive(false);
            levelsPadlocks[i].SetActive(false);
        }
    }

    void GetLevels()
    {
        fruitPuzzleLevels = puzzleGameSaver.fruitPuzzleLevels;
        animalPuzzleLevels = puzzleGameSaver.animalPuzzleLevels;
    }

    public bool[] GetPuzzleLevels(string selectedPuzzle)
    {
        switch (selectedPuzzle)
        {
            case "FruitsPuzzle" :
                return this.fruitPuzzleLevels;
                break;

            case "AnimalsPuzzle" :
                return this.animalPuzzleLevels;
                break;

            default :
                return null;
                break;
        }
    }

}
