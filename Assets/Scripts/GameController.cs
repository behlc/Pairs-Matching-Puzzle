using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] Sprite btnBgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;
    private int countGuesses, countCorrectGuesses, gameGuesses, firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;


    
    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Arts/FruitsPuzzle");
    }

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = btnBgImage;
        }
    }

    public void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Button Name " + name);
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index ++;
        }
    }
}
