using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Level: " + GameManager.Instance.SelectedLevel.ToString();
    }
}
