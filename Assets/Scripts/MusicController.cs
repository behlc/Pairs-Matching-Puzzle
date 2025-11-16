using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private PuzzleGameSaver puzzleGameSaver;

    private AudioSource bgMusicClip;

    private float musicVolume;

    void Awake()
    {
        GetAudioSource();
    }

    void Start()
    {
        musicVolume = puzzleGameSaver.musicVolume;
        PlayOrTurnOffMusic(musicVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetAudioSource()
    {
        bgMusicClip = GetComponent<AudioSource>();
    }

    public void SetMusicVolume(float volume)
    {
        PlayOrTurnOffMusic(volume);
    }

    void PlayOrTurnOffMusic(float volume)
    {
        musicVolume = volume;
        bgMusicClip.volume = musicVolume;

        if(bgMusicClip.volume > 0)
        {
            if(!bgMusicClip.isPlaying)
            {
                bgMusicClip.Play();
            }

            puzzleGameSaver.musicVolume = musicVolume;
            puzzleGameSaver.SaveGameData();
            
        } else if(bgMusicClip.volume == 0)
        {
            if(bgMusicClip.isPlaying)
            {
                bgMusicClip.Stop();
            }
            puzzleGameSaver.musicVolume = musicVolume;
            puzzleGameSaver.SaveGameData();
        }
    }

    public float GetMusicVolume()
    {
        return this.musicVolume;
    }
}
