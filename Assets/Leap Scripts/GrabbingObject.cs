using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingObject : MonoBehaviour
{
    //public float _gravityScale = 0.5f;

    Vector3 _defaultScale = Vector3.one;
    Vector3 _defaultPos;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rg;

    public Sprite Sprite
    {
        set { _spriteRenderer.sprite = value; }
    }

    public int ObjectID { get; set; } = -1;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rg = GetComponent<Rigidbody2D>();
        //_spriteRenderer.sprite = null;
    }

    private void Start()
    {
        _defaultScale = transform.localScale;
        _defaultPos = transform.localPosition;
        _rg.gravityScale = 0;

        StartCoroutine(ShowAnimateCoroutine());
    }

    IEnumerator ShowAnimateCoroutine()
    {
        float duration = 1f;
        Scale = 0;

        for (float tick = 0; tick < duration; tick += Time.deltaTime)
        {
            float t = tick / duration;
            Scale = Easing.Back.easeOut(t);
            yield return null;
        }

        Scale = 1;
    }

    float Scale
    {
        set
        {
            var scale = transform.localScale;
            scale = _defaultScale * value;
            transform.localScale = scale;
        }
    }


    /*private void Update()
    {
        // 画面下に落らた消す
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }*/

    // receive hand event
    //-------------------------------------------------------------------------

    public void OnBeginGrabHand()
    {
        var pos = transform.localPosition;
        pos.z = _defaultPos.z + 0.5f;
        transform.localPosition = pos;
    }
    
    public void OnEndGrabHand()
    {
        //_rg.gravityScale = _gravityScale;
    }
}
