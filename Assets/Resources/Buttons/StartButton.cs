using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public Sprite newSprite;
    public Sprite oldSprite;

    void Start()
    {

    }

    public void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }
}
