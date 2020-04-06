using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ResetProgressButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SaveGameSystem.ResetProgress();
        GameManager.Instance.SaveGameSystem.SetSoundVolume(SoundManager.Instance.SoundVolume);
        GameManager.Instance.SaveGame();
    }
}
