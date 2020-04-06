using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    private float musicVolume = 1f;
    void Update()
    {
        FindObjectOfType<SoundManager>().SetVolume(musicVolume);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}