using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();

        if (scoreCounter.IsHighScorePassed)
        {
            GameManager.Instance.SaveGameSystem.SetLevelAsCompleted(GameManager.Instance.SelectedLevel, scoreCounter.HighScore);
            GameManager.Instance.SaveGame();
        }

        SoundManager.Instance.PlayMenuMusic();
        SceneManager.LoadScene("LevelSelectScene");
    }
}
