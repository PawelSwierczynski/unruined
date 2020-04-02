using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBlockButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] buildingParts;
    public Sprite[] blockSprites;
    SpawnBuildingParts spawn;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, buildingParts.Length);
        this.gameObject.GetComponent<Text>().text = buildingParts[random].name;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[random];
    }
    public void updateButton()
    {
        random = Random.Range(0, buildingParts.Length);
        this.gameObject.GetComponent<Text>().text = buildingParts[random].name;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
            FindObjectOfType<SpawnBuildingParts>().SpawnNewBuildingPart(random);
            updateButton();
            FindObjectOfType<ChooseBlockButton2>().updateButton2();
            FindObjectOfType<ChooseBlockButton3>().updateButton3();      
    }
}
