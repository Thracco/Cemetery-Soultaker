using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public int Souls;
    [SerializeField] float _speed;
    SoulCollect _soulCollector;
    public bool HasSoul = true, _isBeingCollected;
    public Color Collected;
    public Color Escaped;
    SpriteRenderer _myRenderer;
    Collider2D _myCollider;
    private void Awake()
    {
        _myRenderer = GetComponent<SpriteRenderer>();
        _myCollider = GetComponent<Collider2D>();
        Escaped = Color.yellow;
        _soulCollector = GameObject.FindWithTag("Player").GetComponent<SoulCollect>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            {
                _isBeingCollected = true;
              SoulCollect s =   other.GetComponent<SoulCollect>();
              s.Speed = _speed;
              s.CanCollect = true;
              s.OnCollected += SoulCollected;
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if(other.CompareTag("Player"))
             {
                 _isBeingCollected = false;
              SoulCollect s =   other.GetComponent<SoulCollect>();
              s.CanCollect = false;
              s.OnCollected -= SoulCollected;
            }
    }

    public void SoulCollected()
    {
        // Soul collected
        Debug.Log("Soul Collected");
        _myRenderer.color = Collected;
        _soulCollector.PlayerSoulsCollected += Souls;
        SoulManager.Instance.AddPlayerSouls(Souls);
        _myCollider.enabled = false;
        HasSoul = false;
        Souls = 0;
    }

    public void SoulEscaped()
    {
         Debug.Log("Soul Escaped");
         _myRenderer.color = Escaped;
         HasSoul = false;
        _myCollider.enabled = false;
        SoulManager.Instance.AddEscapedSouls(Souls);
        Souls = 0;
    }
}
