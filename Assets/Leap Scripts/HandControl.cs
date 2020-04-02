using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Leap;

//public class GrabbingObject : MonoBehaviour
//{ 

  //  public GrabbingObject _grabedObject;
//}

    public class HandControl : MonoBehaviour
{
    
    public Vector2 _positionScale = Vector2.one;

    public Transform _handPointer;
    public GameObject _openHandObj;
    public GameObject _closeHandObj;
    bool _isGrabbing, _isLastGrabbing;
    GrabbingObject _grabedObject = null;

    Vector2 Position
    {
        set
        {
            var pos = _handPointer.localPosition;
            pos.x = value.x;
            pos.y = value.y;
            _handPointer.localPosition = pos;
        }
        get { return _handPointer.position; }
    }

    bool Visible
    {
        set
        {
            _handPointer.gameObject.SetActive(value);
        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        OpenHand();

    }

    // Update is called once per frame
    private void Update()
    {
        if (_grabedObject)
        {
            _grabedObject.transform.position = Position;
        }
    }

    void OpenHand()
    {
        _openHandObj.SetActive(true);
        _closeHandObj.SetActive(false);

        if (_isGrabbing)
        {
            EndGrab();
            _isGrabbing = false;
        }
    }

    void CloseHand()
    {
        _openHandObj.SetActive(false);
        _closeHandObj.SetActive(true);

        if (_isGrabbing == false)
        {
            BeginGrab();
            _isGrabbing = true;
        }
    }

    void BeginGrab()
    {
        RaycastHit2D hit = Physics2D.Raycast(Position, Vector3.forward);
        if (hit)
        {
            var go = hit.transform.GetComponent<GrabbingObject>();
            if (go)
            {
                _grabedObject = go;
            }
        }
    }

    void EndGrab()
    {
        if (_grabedObject)
        {
            _grabedObject.OnEndGrabHand();
        }
        _grabedObject = null;
    }

    public void SetPosition(Frame frame)
    {
        if (frame.Hands.Count > 0)
        {
            Visible = true;
            var hand = frame.Hands.Last();
            var palm = hand.PalmPosition;
            Position = new Vector2(palm.x, palm.y) * _positionScale;

            if (hand.GrabStrength < 1)
                OpenHand();
            else
                CloseHand();
        }
        else
        {
            Visible = false;
        }
    }
}
