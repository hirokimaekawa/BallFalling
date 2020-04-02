using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int StageNo;
	public bool isBallMoving;

    public GameObject ballPrefab;
	public GameObject ball;

	public GameObject goButton;
	public GameObject retryButton;
	public GameObject clearText;

    public Collider2D movable1;
    public Collider2D movable2;
    public Collider2D movable3;

	public AudioClip clearSE;
    public AudioClip unmoveSE;
    public AudioClip moveSE;
    public AudioClip boundSE;
    public AudioClip boundSE2;

	private AudioSource audioSource;
      
    public HandGestureManager _handGestureManager;
    public HandControl _hand;

    private bool goButtonDown = false;
    private bool retryButtonDown = false;
    private bool backButtonDown = false;

    // Use this for initialization
    void Start () {
		retryButton.SetActive (false);
		isBallMoving = false;
		audioSource = gameObject.GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Return) || (this.goButtonDown)))
        {
            PushGoButton();
        }
        if ((Input.GetKey(KeyCode.Backspace) || this.retryButtonDown))
        {
            PushRetryButton();
        }
        if ((Input.GetKey(KeyCode.Delete) || this.backButtonDown))
        {
            GobackStageSelect();
        }
    }

	public void PushGoButton(){
            Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
            rd.isKinematic = false;

            retryButton.SetActive(true);
            goButton.SetActive(false);
            isBallMoving = true;
            movable1.isTrigger = false;
            movable2.isTrigger = false;
            movable3.isTrigger = false;
    }

    public void PushRetryButton()
    {
        Destroy(ball);
        ball = (GameObject)Instantiate(ballPrefab);

        retryButton.SetActive(false);
        goButton.SetActive(true);
        isBallMoving = false;
    }
    
	public void PushBackButton(){
		GobackStageSelect ();
	}


	public void StageClear(){
		audioSource.PlayOneShot (clearSE);
		if (PlayerPrefs.GetInt ("CLEAR", 0) < StageNo) {
			PlayerPrefs.SetInt ("CLEAR", StageNo);
		}

		clearText.SetActive (true);
		retryButton.SetActive (false);
		Invoke("GobackStageSelect",3.0f);
	}
	void GobackStageSelect(){
		SceneManager.LoadScene ("StageSelectScene");
	}

    public void TouchUnMoveBox() {
        audioSource.PlayOneShot(unmoveSE);
    }

    public void TouchMoveBox(){
        audioSource.PlayOneShot(moveSE);
    }

    public void TouchBoundMoveBox()
    {
        audioSource.PlayOneShot(boundSE);
    }

    public void TouchBoundUnMoveBox()
    {
        audioSource.PlayOneShot(boundSE2);
    }

}
