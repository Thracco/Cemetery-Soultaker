using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    SpriteRenderer _renderer;
    public float alpha = 255f;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * Vector2.up);
        alpha -=  Time.deltaTime * speed;
        _renderer.color = new Color(255f,255f,255f,alpha);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
