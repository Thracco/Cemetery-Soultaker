using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SoulCollect : MonoBehaviour
{
   public bool CanCollect;
    public float Speed;
   public int PlayerSoulsCollected = 0;
   public event Action OnCollected;
    [SerializeField] GameObject _myCanvas;
    [SerializeField] Image _myprogressbar;
    bool _progressBarStarted;
    PlayerController _myController;

    private void Awake() {
        _myController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()   {
        if(!CanCollect){
            _myCanvas.SetActive(false);
            return;
        }
        _myCanvas.SetActive(true);
        if(Input.GetButtonDown("Jump")){
           _progressBarStarted = true;
           _myController.canMove = false;
        }
        if(Input.GetButtonUp("Jump")){
            _progressBarStarted = false;
            _myController.canMove = true;
        }
        StartProgressBar();
    }
    void StartProgressBar()
    {
        if(_progressBarStarted) {
         Debug.Log("Jump buton enabled");
            
            _myprogressbar.fillAmount += Speed *  Time.deltaTime;
            if(_myprogressbar.fillAmount == 1){
                _myCanvas.SetActive(false);
                OnCollected?.Invoke();
                CanCollect = false;
                _myprogressbar.fillAmount = 0f;
                _progressBarStarted = false;
                _myController.canMove = true;
                return;
            }
        } else{   
                _myprogressbar.fillAmount = 0f; 
        }
    }
}
