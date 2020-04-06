using UnityEngine;
using UnityEngine.EventSystems;

public class AcceptButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SaveGameSystem.SetSoundVolume(SoundManager.Instance.SoundVolume);
        Debug.Log(SoundManager.Instance.SoundVolume);

        GameManager.Instance.SaveGame();
    }
}
