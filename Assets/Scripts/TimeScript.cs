using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    //public GameObject gameobject;
    GameObject gameobject;

    GameObject limitTimeUI;

    float time = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        limitTimeUI = GameObject.Find("LimitTimeUI");
        gameobject = GameObject.Find("Time");
        //bool B = gameObject.GetComponent<GameManager>().isBallMoving;
        //Debug.Log(B);

        //B = false;

        //gameobject.GetComponent<GameManager>().ReturnAccess();
    }

    // Update is called once per frame
    void Update()
    {
        // 毎フレーム毎に残り時間を減らしていく
        //for (int i = 0; i < 5; i++)
        //{
            this.time -= Time.deltaTime;
            if (this.time < 0)
            {
                this.limitTimeUI.GetComponent<Text>().text = "Time: 0";

                GameManager a = GameObject.Find("GameManager").GetComponent<GameManager>();
                a.PushGoButton();
            }
            else
            {
                // timeを文字列に変換したものをテキストに表示する
                this.limitTimeUI.GetComponent<Text>().text = "Time: " + this.time.ToString("F0");
            }
        //}

        }

    public void reset()
    {

    }
    

}

