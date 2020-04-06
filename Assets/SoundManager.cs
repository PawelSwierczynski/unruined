using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private enum MusicType
    {
        MenuMusic,
        GameMusic
    }

    public static SoundManager Instance { get; private set; }
    public AudioSource audioSource;
    public AudioClip[] MenuMusic;
    public AudioClip[] GameMusic;
    private MusicType currentMusicType;
    private int currentMusicIndex;
    private float audioVolume = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentMusicType = MusicType.MenuMusic;
            currentMusicIndex = Random.Range(0, MenuMusic.Length - 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {        
        if (audioSource.isPlaying == false)
        {
            if (currentMusicType == MusicType.MenuMusic && currentMusicIndex == MenuMusic.Length - 1)
            {
                currentMusicIndex = 0;
            }
            else if (currentMusicType == MusicType.GameMusic && currentMusicIndex == GameMusic.Length - 1)
            {
                currentMusicIndex = 0;
            }
            else
            {
                currentMusicIndex++;
            }

            audioSource.clip = (currentMusicType == MusicType.MenuMusic) ? MenuMusic[currentMusicIndex] : GameMusic[currentMusicIndex];            
            audioSource.Play();
        }
        audioSource.volume = audioVolume;
    }

    public void PlayMenuMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        currentMusicType = MusicType.MenuMusic;
        currentMusicIndex = Random.Range(0, MenuMusic.Length - 1);
    }

    public void PlayGameMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        currentMusicType = MusicType.GameMusic;
        currentMusicIndex = Random.Range(0, GameMusic.Length - 1);
    }

    public void SetVolume(float volume)
    {
        audioVolume = volume;
    }
}
