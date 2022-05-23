using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class GaveManager : MonoBehaviour
{
    public GameObject WinText, LostText, Angel;
    public UnityEvent GameEnded;
    [SerializeField] List<Grave> graves;
    public int SoulsEscaped;
    float _timer, _timerCoolDown = 2.5f;
    bool _stoptimers;
    

    private void Awake()
    {
        Grave[] tempGraves  = GetComponentsInChildren<Grave>();
        foreach (var tempgrave in tempGraves)
        {
            graves.Add(tempgrave);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if(!_stoptimers)
        {
            if(_timer > _timerCoolDown)
            {
                PickGrave();
            }
        }
    }

    private void PickGrave()
    {
        if(graves.Count == 0){
         _stoptimers = true;  
          GameEnded?.Invoke();  
            if(SoulManager.Instance.PlayerSouls > SoulManager.Instance.EscapedSouls)
              WinText.SetActive(true);
              else
               LostText.SetActive(true); 
        return;
        } 

        int index = Random.Range(0, graves.Count);

        if( !graves[index]._isBeingCollected && graves[index].HasSoul )
        {
            SoulsEscaped += graves[index].Souls;
            graves[index].SoulEscaped();
            
            Instantiate( Angel,graves[index].transform.position,Quaternion.identity );
            
            graves.Remove(graves[index]);
            _timer = 0f;
            return;
        }
        else if(!graves[index].HasSoul)
        {
            graves.Remove(graves[index]);
            PickGrave();
        }
       
    }
}
