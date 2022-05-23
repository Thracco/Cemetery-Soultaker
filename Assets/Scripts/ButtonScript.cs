using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text buttontext;
    private void Awake()
    {
        buttontext = GetComponentInChildren<TMP_Text>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered");
        buttontext.color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
         buttontext.color = Color.white;
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitApp()
    {
        Debug.Log("Main Menu");
    }
}
