using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialSliderValueSetter : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Slider>().value = SoundManager.Instance.SoundVolume;

        SoundManager.Instance.IsVolumeSliderReady = true;
    }
}
