using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Highscore: " + GameManager.Instance.SaveGameSystem.RetrieveHighscore(GameManager.Instance.SelectedLevel).ToString() + "%";
    }
}
