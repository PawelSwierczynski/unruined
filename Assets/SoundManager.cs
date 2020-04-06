using UnityEngine;
using UnityEngine.UI;

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
    public float SoundVolume;
    private MusicType currentMusicType;
    private int currentMusicIndex;
    public bool IsVolumeSliderReady { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentMusicType = MusicType.MenuMusic;
            currentMusicIndex = Random.Range(0, MenuMusic.Length - 1);
            SoundVolume = GameManager.Instance.SaveGameSystem.GetSoundVolume();
            audioSource.volume = SoundVolume;
            IsVolumeSliderReady = false;
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

        Slider volumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider")?.GetComponent<Slider>();

        if (volumeSlider != null && IsVolumeSliderReady)
        {
            SoundVolume = volumeSlider.value;

            audioSource.volume = volumeSlider.value;
        }
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
}
