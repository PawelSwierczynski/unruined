using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler
{

    public void OnMouseOver()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
}
