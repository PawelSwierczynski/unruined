using UnityEngine;
using UnityEngine.UI;

public class LevelCompletion : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Level completion: " + "0" + "%";
    }

    public void SetCompletion(int completion)
    {
        this.gameObject.GetComponent<Text>().text = "Level completion: " + completion.ToString() + "%";
    }

}
