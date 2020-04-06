﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("CreditsScene");
    }
}