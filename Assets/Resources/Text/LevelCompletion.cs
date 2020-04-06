using UnityEngine;
using UnityEngine.UI;

public class LevelCompletion : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Current: " + "0" + "%";
    }

    public void SetCompletion(int completion)
    {
        this.gameObject.GetComponent<Text>().text = "Current: " + completion.ToString() + "%";
    }

}
