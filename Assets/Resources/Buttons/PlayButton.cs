using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    public void SetLevel(int level)
    {
        GameManager.Instance.SelectedLevel = level;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.Instance.SelectedLevel != 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
