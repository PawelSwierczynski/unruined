using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBlockButton3 : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] buildingParts;
    public Sprite[] blockSprites;
    SpawnBuildingParts spawn;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, buildingParts.Length);
        this.gameObject.GetComponent<Image>().sprite = blockSprites[random];
    }
    public void updateButton3()
    {
        random = Random.Range(0, buildingParts.Length);
        this.gameObject.GetComponent<Image>().sprite = blockSprites[random];
    }
    public void OnPointerClick(PointerEventData eventData)
    {        
        FindObjectOfType<SpawnBuildingParts>().SpawnNewBuildingPart(random);
        FindObjectOfType<ChooseBlockButton>().updateButton();
        FindObjectOfType<ChooseBlockButton2>().updateButton2();
        updateButton3();
        enabled = false;
        FindObjectOfType<ChooseBlockButton2>().enabled = false;
        FindObjectOfType<ChooseBlockButton>().enabled = false;
    }
}