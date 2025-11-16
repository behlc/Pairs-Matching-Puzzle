using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PuzzleGameSaver : MonoBehaviour
{
    private GameData gameData;

    public bool[] fruitPuzzleLevels;
    public bool[] animalPuzzleLevels;

    public int[] fruitPuzzleLevelsStars;
    public int[] animalPuzzleLevelsStars;

    private bool isGameStartedForTheFirstTime;

    public float musicVolume;

    void Awake()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        LoadGameData();

        if(gameData != null)
        {
            isGameStartedForTheFirstTime = gameData.GetIsGameStartedForTheFirstTime();
        }
        else
        {
            isGameStartedForTheFirstTime = true;
        }

        //isGameStartedForTheFirstTime = true;
        if(isGameStartedForTheFirstTime)
        {
            isGameStartedForTheFirstTime = false;
            
            fruitPuzzleLevels = new  bool[5];
            animalPuzzleLevels = new  bool[5];

            fruitPuzzleLevels[0] = true;
            animalPuzzleLevels[0] = true;

            for (int i = 1; i < fruitPuzzleLevels.Length; i++)
            {
                fruitPuzzleLevels[i] = false;
                animalPuzzleLevels[i] = false;
            }

            fruitPuzzleLevelsStars = new int[5];
            animalPuzzleLevelsStars = new int[5];
            musicVolume = 0;
            
            for (int i = 0; i < fruitPuzzleLevelsStars.Length; i++)
            {
                fruitPuzzleLevelsStars[i] = 0;
                animalPuzzleLevelsStars[i] = 0;
            }

            gameData = new GameData();
            gameData.SetFruitPuzzleLevels(fruitPuzzleLevels);
            gameData.SetAnimalPuzzleLevels(animalPuzzleLevels);

            gameData.SetFruitPuzzleLevelStars(fruitPuzzleLevelsStars);
            gameData.SetAnimalPuzzleLevelStars(animalPuzzleLevelsStars);

            gameData.SetIsGameStartedForTheFirstTime(isGameStartedForTheFirstTime);
            gameData.SetMusicVolume(musicVolume);

            SaveGameData();
            LoadGameData();
        }
    }

    public void SaveGameData()
    {
        FileStream file = null;
        try 
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/GameData.dat");
            if(gameData != null)
            {
                gameData.SetFruitPuzzleLevels (fruitPuzzleLevels);
                gameData.SetAnimalPuzzleLevels (animalPuzzleLevels);

                gameData.SetFruitPuzzleLevelStars (fruitPuzzleLevelsStars);
                gameData.SetAnimalPuzzleLevelStars (animalPuzzleLevelsStars);

                gameData.SetIsGameStartedForTheFirstTime (isGameStartedForTheFirstTime);
                gameData.SetMusicVolume (musicVolume);

                bf.Serialize(file, gameData);
            }

        } catch (Exception e)
        {

        } finally 
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    void LoadGameData()
    {
        FileStream file = null;
        try {

            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            gameData = (GameData)bf.Deserialize(file);
            if(gameData != null)
            {
                fruitPuzzleLevels = gameData.GetFruitPuzzleLevels();
                animalPuzzleLevels = gameData.GetAnimalPuzzleLevels();

                fruitPuzzleLevelsStars = gameData.GetFruitPuzzleLevelStars();
                animalPuzzleLevelsStars = gameData.GetAnimalPuzzleLevelStars();

                musicVolume = gameData.GetMusicVolume();

            }


        }  catch(Exception e)
        {

        } finally {
            if (file != null)
            {
                file.Close();
            }
        }

    }

    public void Save(int level, string selectedPuzzle, int stars)
    {
        int unlockedNextLevel = -1;

        switch(selectedPuzzle)
        {
            case "FruitsPuzzle" :
                unlockedNextLevel = level + 1;
                fruitPuzzleLevelsStars[level] = stars;
                if(unlockedNextLevel < fruitPuzzleLevels.Length)
                {
                    fruitPuzzleLevels[unlockedNextLevel] = true;
                }
                break;

            case "AnimalsPuzzle" :
                unlockedNextLevel = level + 1;
                animalPuzzleLevelsStars[level] = stars;
                if(unlockedNextLevel < animalPuzzleLevels.Length)
                {
                    animalPuzzleLevels[unlockedNextLevel] = true;
                }
                break;   
        }
    }
}
