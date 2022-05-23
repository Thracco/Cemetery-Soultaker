using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public bool canMove = true;
    Vector2 _movement;
    bool _isFacingRight = true;
     SpriteRenderer _mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();        
    }
    // Update is called once per frame
    void Update()
    { 
        if(!canMove) return;
        RotateCharacter();
        
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(_movement * Time.deltaTime * Speed); 
       
    }
    private void RotateCharacter()
    {
        if(_isFacingRight && _movement.x < 0)
            {
                _mySpriteRenderer.flipX = true;
                _isFacingRight = false;
            }
            else if(!_isFacingRight && _movement.x > 0)
            {
                _mySpriteRenderer.flipX = false;
                _isFacingRight = true;
            }
    }
}
