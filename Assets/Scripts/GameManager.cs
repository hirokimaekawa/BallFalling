using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject stagePanel1;
    [SerializeField] GameObject stagePanel2;
    [SerializeField] GameObject stagePanel3;
    [SerializeField] GameObject stagePanel4;
    [SerializeField] GameObject stagePanel5;
    [SerializeField] GameObject stagePanel6;
    [SerializeField] GameObject stagePanel7;
    [SerializeField] GameObject stagePanel8;
    [SerializeField] GameObject stagePanel9;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject selectStagePanel;

    [SerializeField] GameObject squareButton;
    [SerializeField] GameObject crossButton;
    [SerializeField] GameObject rhombusButton;
    [SerializeField] GameObject triangleButton;
    [SerializeField] GameObject fanButton;
    [SerializeField] GameObject heartButton;

    void Awake()
    {
       
        ResetColor();
    }

    void ResetColor()
    {
        squareButton = GameObject.Find("SquareButton");
        crossButton = GameObject.Find("CrossButton");
        rhombusButton = GameObject.Find("RhombusButton");
        triangleButton = GameObject.Find("TriangleButton");
        fanButton = GameObject.Find("FanButton");
        heartButton = GameObject.Find("HeartButton");

        squareButton.GetComponent<Image>().color = Color.black;
        crossButton.GetComponent<Image>().color = Color.black;
        rhombusButton.GetComponent<Image>().color = Color.black;
        triangleButton.GetComponent<Image>().color = Color.black;
        fanButton.GetComponent<Image>().color = Color.black;
        heartButton.GetComponent<Image>().color = Color.black;
    }

    bool isSettingPanel;

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
    public Collider2D movable4;

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
            movable4.isTrigger = false;
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
    
    public void SettingPanelOKButton()
    {
        settingPanel.SetActive(false);
        selectStagePanel.SetActive(true);
    }

    public void SelectStageButton1()
    {
        selectStagePanel.SetActive(false);
        stagePanel1.SetActive(true);
    }
    public void SelectStageButton2()
    {
        selectStagePanel.SetActive(false);
        stagePanel2.SetActive(true);
    }
    public void SelectStageButton3()
    {
        selectStagePanel.SetActive(false);
        stagePanel3.SetActive(true);
    }
    public void SelectStageButton4()
    {
        selectStagePanel.SetActive(false);
        stagePanel4.SetActive(true);
    }
    public void SelectStageButton5()
    {
        selectStagePanel.SetActive(false);
        stagePanel5.SetActive(true);
    }
    public void SelectStageButton6()
    {
        selectStagePanel.SetActive(false);
        stagePanel6.SetActive(true);
    }
    public void SelectStageButton7()
    {
        selectStagePanel.SetActive(false);
        stagePanel7.SetActive(true);
    }
    public void SelectStageButton8()
    {
        selectStagePanel.SetActive(false);
        stagePanel8.SetActive(true);
    }
    public void SelectStageButton9()
    {
        selectStagePanel.SetActive(false);
        stagePanel9.SetActive(true);
    }
    public void BackToSettingPanelButton()
    {
        selectStagePanel.SetActive(false);
        settingPanel.SetActive(true);
        ResetColor();
    }

    private int clickCounter = 0;

    public void ClickSquareButton()
    {
        if (Input.GetMouseButtonDown(1))
        {
            clickCounter++;
        }
        if (clickCounter % 2== 1)
        {
            squareButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            squareButton.GetComponent<Image>().color = Color.black;
        }
    }
    public void ClickCrossButton()
    {
        crossButton.GetComponent<Image>().color = Color.cyan;
    }
    public void ClickRhombusButton()
    {
        rhombusButton.GetComponent<Image>().color = Color.yellow;
    }
    public void ClickTriangleButton()
    {
        triangleButton.GetComponent<Image>().color = Color.blue;
    }

    public void ClickFanButton()
    {
        fanButton.GetComponent<Image>().color = Color.green;
    }

    public void ClickHeartButton()
    {
        heartButton.GetComponent<Image>().color = Color.magenta;
    }

}
