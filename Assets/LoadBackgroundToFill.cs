using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBackgroundToFill : MonoBehaviour
{    
    public Sprite[] backgroundToFillSprites;
    public void LoadBackground(int levelID)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = backgroundToFillSprites[levelID];        
    }
}
