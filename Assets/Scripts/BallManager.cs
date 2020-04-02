using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "OutArea")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().PushRetryButton();
        }
        if (coll.gameObject.tag == "UnMove")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().TouchUnMoveBox();
        }
        if (coll.gameObject.tag == "Move")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().TouchMoveBox();
        }
        if (coll.gameObject.tag == "Bound")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().TouchBoundMoveBox();
        }
        if (coll.gameObject.tag == "Bound2")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().TouchBoundUnMoveBox();
        }

    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "ClearArea")
            {
                GameObject gameManager = GameObject.Find("GameManager");
                gameManager.GetComponent<GameManager>().StageClear();
            }

        }
    
}
   
