using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// this class is not going to be attached to any game object
[Serializable]
public class GameData
{
    private bool[] fruitPuzzleLevels;
    private bool[] animalPuzzleLevels;

    private int[] fruitPuzzleLevelsStars;
    private int[] animalPuzzleLevelsStars;

    private bool isGameStartedForTheFirstTime;
    private float musicVolume;

    public void SetFruitPuzzleLevels(bool[] fruitPuzzleLevels)
    {
        this.fruitPuzzleLevels = fruitPuzzleLevels;
    }

    public bool[] GetFruitPuzzleLevels()
    {
        return this.fruitPuzzleLevels;
    }

    public void SetAnimalPuzzleLevels(bool[] animalPuzzleLevels)
    {
        this.animalPuzzleLevels = animalPuzzleLevels;
    }

    public bool[] GetAnimalPuzzleLevels()
    {
        return this.animalPuzzleLevels;
    }

    public void SetFruitPuzzleLevelStars(int[] fruitPuzzleLevelsStars)
    {
        this.fruitPuzzleLevelsStars = fruitPuzzleLevelsStars;
    }

    public int[] GetFruitPuzzleLevelStars()
    {
        return this.fruitPuzzleLevelsStars;
    }

    public void SetAnimalPuzzleLevelStars(int[] animalPuzzleLevelsStars)
    {
        this.animalPuzzleLevelsStars = animalPuzzleLevelsStars;
    }

    public int[] GetAnimalPuzzleLevelStars()
    {
        return this.animalPuzzleLevelsStars;
    }

    public void SetIsGameStartedForTheFirstTime(bool isGameStartedForTheFirstTime)
    {
        this.isGameStartedForTheFirstTime = isGameStartedForTheFirstTime;
    }

    public bool GetIsGameStartedForTheFirstTime()
    {
        return this.isGameStartedForTheFirstTime;
    }

    public void SetMusicVolume(float musicVolume)
    {
        this.musicVolume = musicVolume;
    }

    public float GetMusicVolume()
    {
        return this.musicVolume;
    }
}
