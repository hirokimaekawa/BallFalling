using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
    [SerializeField] GameObject startButton;

    void Awake()
    {
       
        ResetColor();
    }

    void ResetColor()
    {
        /*squareButton = GameObject.Find("SquareButton");
        crossButton = GameObject.Find("CrossButton");
        rhombusButton = GameObject.Find("RhombusButton");
        triangleButton = GameObject.Find("TriangleButton");
        fanButton = GameObject.Find("FanButton");
        heartButton = GameObject.Find("HeartButton");
        */

        squareButton.GetComponent<Image>().color = Color.black;
        crossButton.GetComponent<Image>().color = Color.black;
        rhombusButton.GetComponent<Image>().color = Color.black;
        triangleButton.GetComponent<Image>().color = Color.black;
        fanButton.GetComponent<Image>().color = Color.black;
        heartButton.GetComponent<Image>().color = Color.black;
    }

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
        startButton.SetActive(false);
        redButtonFlag = false;
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
        ball.transform.localPosition = new Vector3(-3.5f, 4.3f, 0f);

        retryButton.SetActive(false);
        goButton.SetActive(true);
        isBallMoving = false;
    }
    
	public void PushBackButton(){
		GobackStageSelect ();
	}


	public void StageClear(){
		audioSource.PlayOneShot (clearSE);
		/*if (PlayerPrefs.GetInt ("CLEAR", 0) < StageNo) {
			PlayerPrefs.SetInt ("CLEAR", StageNo);
		}*/

		clearText.SetActive (true);
		retryButton.SetActive (false);
        //Invoke("GobackStageSelect",3.0f);
        //selectStagePanel.SetActive(true);
        RefreshStagePanel();
    }
    IEnumerator RefreshStagePanel()
    {
        yield return new WaitForSeconds(3.0f);
        clearText.SetActive(false);
        stagePanel1.SetActive(false);
        selectStagePanel.SetActive(true);

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
        //startButton.SetActive(false);
    }
    [SerializeField] GameObject squarePrefab;
    [SerializeField] GameObject crossPrefab;
    [SerializeField] GameObject rhombusPrefab;
    [SerializeField] GameObject trianglePrefab;
    [SerializeField] GameObject fanPrefab;
    [SerializeField] GameObject heartPrefab;
    public void SelectStageButton1()
    {
        selectStagePanel.SetActive(false);
        stagePanel1.SetActive(true);
        ball = (GameObject)Instantiate(ballPrefab);
        ball.transform.localPosition = new Vector3(-3.5f, 4.3f, 0f);

        //ball.transform.SetParent(stagePanel1.transform, false);
        if (redButtonFlag == true)
        {
            GameObject obj = (GameObject)Instantiate(squarePrefab);
            obj.transform.SetParent(stagePanel1.transform,false);
            obj.transform.localPosition = new Vector3(UnityEngine.Random.Range(-650.0f,600.0f),UnityEngine.Random.Range(400.0f,-180.0f),0f);
        }
        if (cyanButtonFlag == true)
        {
            GameObject obj = (GameObject)Instantiate(crossPrefab);
            obj.transform.SetParent(stagePanel1.transform, false);
            obj.transform.localPosition = new Vector3(UnityEngine.Random.Range(-650.0f, 600.0f), UnityEngine.Random.Range(400.0f, -180.0f), 0f);
        }
        if (yellowButtonFlag == true)
        {
            GameObject obj = (GameObject)Instantiate(rhombusPrefab);
            obj.transform.SetParent(stagePanel1.transform, false);
            obj.transform.localPosition = new Vector3(UnityEngine.Random.Range(-650.0f, 600.0f), UnityEngine.Random.Range(400.0f, -180.0f), 0f);
        }
        if (blueButtonFlag == true)
        {
            GameObject obj = (GameObject)Instantiate(trianglePrefab);
            obj.transform.SetParent(stagePanel1.transform, false);
            obj.transform.localPosition = new Vector3(UnityEngine.Random.Range(-650.0f, 600.0f), UnityEngine.Random.Range(400.0f, -180.0f), 0f);
        }
        if (greenButtonFlag == true)
        {
            GameObject obj = (GameObject)Instantiate(fanPrefab);
            obj.transform.SetParent(stagePanel1.transform, false);
            obj.transform.localPosition = new Vector3(UnityEngine.Random.Range(-650.0f, 600.0f), UnityEngine.Random.Range(400.0f, -180.0f), 0f);
        }
        if (magentaButtonFlag == true)
        {
            GameObject obj = (GameObject)Instantiate(heartPrefab);
            obj.transform.SetParent(stagePanel1.transform, false);
            obj.transform.localPosition = new Vector3(UnityEngine.Random.Range(-650.0f, 600.0f), UnityEngine.Random.Range(400.0f, -180.0f), 0f);
        }

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
        //startButton.SetActive(false);
        ResetColor();
        Reset();
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
        if(clickCounter == 3)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
        
    }
    /*private void OnEnable()
    {
        Reset();
    }*/
    public void Reset()
    {
        clickCounter = 0;
        redButtonFlag = false;
        cyanButtonFlag = false;
        yellowButtonFlag = false;
        blueButtonFlag = false;
        greenButtonFlag = false;
        magentaButtonFlag = false;
        startButton.SetActive(false);
    }

    public int clickCounter = 0;
    [SerializeField] bool redButtonFlag;
    [SerializeField] bool cyanButtonFlag;
    [SerializeField] bool yellowButtonFlag;
    [SerializeField] bool blueButtonFlag;
    [SerializeField] bool greenButtonFlag;
    [SerializeField] bool magentaButtonFlag;


    private Color GetColorRed()
    {
        // すでに赤いので黒に戻す
        if (redButtonFlag)
        {
            redButtonFlag = false;
            clickCounter--;
            return Color.black;
        }
        // まだ赤くないので赤にする
        redButtonFlag = true;
        clickCounter++;
        return Color.red;

       
    }
    private Color GetColorCyan()
    {
       
        if (cyanButtonFlag)
        {
            cyanButtonFlag = false;
            clickCounter--;
            return Color.black;
        }

        cyanButtonFlag = true;
        clickCounter++;
        return Color.cyan;

    }

    private Color GetColorYellow()
    {
        if (yellowButtonFlag)
        {
            yellowButtonFlag = false;
            clickCounter--;
            return Color.black;
        }

        yellowButtonFlag = true;
        clickCounter++;
        return Color.yellow;

    }

    private Color GetColorBlue()
    {
        if (blueButtonFlag)
        {
            blueButtonFlag = false;
            clickCounter--;
            return Color.black;
        }

        blueButtonFlag = true;
        clickCounter++;
        return Color.blue;


    }

    private Color GetColorGreen()
    {
        if (greenButtonFlag)
        {
            greenButtonFlag = false;
            clickCounter--;
            return Color.black;
        }

        greenButtonFlag = true;
        clickCounter++;
        return Color.green;


    }

    private Color GetColorMagenta()
    {
        if (magentaButtonFlag)
        {
            magentaButtonFlag = false;
            clickCounter--;
            return Color.black;
        }

        magentaButtonFlag = true;
        clickCounter++;
        return Color.magenta;

    }


    public void ClickSquareButton()
    {
        if (clickCounter >= 3　&&　redButtonFlag == false)
        {
            return;
        }
      
        squareButton.GetComponent<Image>().color = GetColorRed();
    }
    public void ClickCrossButton()
    {
        if (clickCounter >= 3 && cyanButtonFlag == false)
        {
            return;
        }
        crossButton.GetComponent<Image>().color = GetColorCyan();
    }
    public void ClickRhombusButton()
    {
        if (clickCounter >= 3 && yellowButtonFlag == false)
        {
            return;
        }
        rhombusButton.GetComponent<Image>().color = GetColorYellow();
    }
    public void ClickTriangleButton()
    {
        if (clickCounter >= 3 && blueButtonFlag == false)
        {
            return;
        }
        triangleButton.GetComponent<Image>().color = GetColorBlue();
    }

    public void ClickFanButton()
    {
        if (clickCounter >= 3 && greenButtonFlag == false)
        {
            return;
        }
        fanButton.GetComponent<Image>().color = GetColorGreen();
    }

    public void ClickHeartButton()
    {
        if (clickCounter >= 3 && magentaButtonFlag == false)
        {
            return;
        }
        heartButton.GetComponent<Image>().color = GetColorMagenta();
    }

}
