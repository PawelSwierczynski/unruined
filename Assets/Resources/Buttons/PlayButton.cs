using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    private string level;
    public void OnMouseOver()
    {

    }
    public void SetLevel(string level)
    {
        this.level = level;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(level == "Level 1")
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
