using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
public class Level1: MonoBehaviour
{
	[Header ("animations")]
	[SerializeField] public GameObject[] videoPlayers;
	
	[Header ("audios")]
	[SerializeField] AudioSource [] audioSource ;
	[SerializeField] AudioSource  gameAudio ;
	
	[Header ("CANVAS")]
	[SerializeField] GameObject mainCanvas;
	[SerializeField] GameObject nextlvelcanvas;
	[SerializeField] GameObject ExitPanel;
	[SerializeField] GameObject Hint1;
	[SerializeField] GameObject Hint2;
	[SerializeField] GameObject Hint3;
	[SerializeField] GameObject Hint4;
	[SerializeField] Sprite man;
	[SerializeField] Sprite woman;
	[SerializeField] GameObject loginButton;
	
	[SerializeField] GameObject q1;
	[SerializeField] GameObject q2;
	[SerializeField] GameObject q3;
	[SerializeField] GameObject q4;
	[SerializeField] GameObject q5;
	[SerializeField] GameObject q6;
	[Header ("elemets")]
	[SerializeField] public int level1hearts;
	[SerializeField] GameObject[] hearts;
	[SerializeField] Sprite deadHeart;
	[SerializeField] float roundTime;
	float benchTime;
	float studentTime;
	[SerializeField] int totalQustionNum;
	[SerializeField] float WieghtTime;
	[SerializeField] float WieghtAccuracy;
	int totalCorrectQuestionNum;
	float overallScore;
	[SerializeField] public TMP_Text timeText;
	private bool endingRound = false;
	private bool GameEnd = false;
	[SerializeField] GameObject settingPanel;
    //************************************************
    //			q1 
    //**************************************************	
	[Header("qestion 1 / button 1")]
	[SerializeField] Button q1b1;
	[SerializeField] Sprite red;
	[SerializeField] Sprite green;
	[SerializeField] GameObject title1;
	[SerializeField] GameObject Answeretitle1;
	
	[Header("qestion 1 / button 2")]
	[SerializeField] Button q1b2;
	[SerializeField] GameObject title2;
	[SerializeField] GameObject Answeretitle2;

	[Header("qestion 1 / button 3")]
	[SerializeField] Button q1b3;
	[SerializeField] GameObject title3;
	[SerializeField] GameObject Answeretitle3;
	
    //************************************************
    //			q2 
    //**************************************************	
	[Header("qestion 2 / button 1")]
	[SerializeField] Button q2b1;
	[SerializeField] GameObject title21;
	[SerializeField] GameObject Answeretitle21;
	
	[Header("qestion 2 / button 2")]
	[SerializeField] Button q2b2;
	[SerializeField] GameObject title22;
	[SerializeField] GameObject Answeretitle22;

	[Header("qestion 2 / button 3")]
	[SerializeField] Button q2b3;
	[SerializeField] GameObject title23;
	[SerializeField] GameObject Answeretitle23;



	//************************************************
    //			q3 
    //**************************************************	
	[Header("qestion 3 / button 1")]
	[SerializeField] Button q3b1;
	[SerializeField] GameObject title31;
	[SerializeField] GameObject Answeretitle31;
	
	[Header("qestion 3 / button 2")]
	[SerializeField] Button q3b2;
	[SerializeField] GameObject title32;
	[SerializeField] GameObject Answeretitle32;

	[Header("qestion 3 / button 3")]
	[SerializeField] Button q3b3;
	[SerializeField] GameObject title33;
	[SerializeField] GameObject Answeretitle33;	

	
	
	//************************************************
    //			q4 
    //**************************************************	
	[Header("qestion 4 / button 1")]
	[SerializeField] Button q4b1;
	[SerializeField] GameObject title41;
	[SerializeField] GameObject Answeretitle41;
	
	[Header("qestion 4 / button 2")]
	[SerializeField] Button q4b2;
	[SerializeField] GameObject title42;
	[SerializeField] GameObject Answeretitle42;

	[Header("qestion 4 / button 3")]
	[SerializeField] Button q4b3;
	[SerializeField] GameObject title43;
	[SerializeField] GameObject Answeretitle43;	
	
	//************************************************
    //			q5
    //**************************************************	
	[Header("qestion 5 / button 1")]
	[SerializeField] Button q5b1;
	[SerializeField] GameObject title51;
	[SerializeField] GameObject Answeretitle51;
	
	[Header("qestion 5 / button 2")]
	[SerializeField] Button q5b2;
	[SerializeField] GameObject title52;
	[SerializeField] GameObject Answeretitle52;

	[Header("qestion 5 / button 3")]
	[SerializeField] Button q5b3;
	[SerializeField] GameObject title53;
	[SerializeField] GameObject Answeretitle53;		
	
	
	//************************************************
    //			q6
    //**************************************************	
	[Header("qestion 6 / button 1")]
	[SerializeField] Button q6b1;
	[SerializeField] GameObject title61;
	[SerializeField] GameObject Answeretitle61;
	
	[Header("qestion 6 / button 2")]
	[SerializeField] Button q6b2;
	[SerializeField] GameObject title62;
	[SerializeField] GameObject Answeretitle62;

	[Header("qestion 6 / button 3")]
	[SerializeField] Button q6b3;
	[SerializeField] GameObject title63;
	[SerializeField] GameObject Answeretitle63;	
	
	
	
	public static Level1 instance;
	bool isStarted = false;
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		
		for(int i = 0 ; i < videoPlayers.Length ; i++){
			videoPlayers[i].SetActive(true);

		
			videoPlayers[i].GetComponent<VideoPlayer>().Prepare();}
	}
	

    void Start()
    {
    	ShowHint1();


    	
    //	StartGame();

    	
    }
    void StartGame()
    {
    	SetHerats();
    	SetLoginSprite();
    	isStarted = true;
    //	videoPlayers[4].SetActive(false);
    	q1.SetActive(true);
    	q2.SetActive(false);
    	q3.SetActive(false);
    	q4.SetActive(false);
    	q5.SetActive(false);
    	q6.SetActive(false);
    	
    	nextlvelcanvas.SetActive(false);
    	level1hearts = PlayerPrefs.GetInt("hearts" ,3 );
    	settingPanel.SetActive(false);
    	ExitPanel.SetActive(false);
    	
    	roundTime = 40f;
    	//roundTime += 5.5f;
    	benchTime = roundTime;
    	studentTime = 0f;
    	totalCorrectQuestionNum = 0;
    	
    	Debug.Log("start level :" +PlayerPrefs.GetInt("level" , 1));
    }
    


    void Update()
    {
    	if(isStarted){
        if(roundTime > 0)
        {
            roundTime -= Time.deltaTime;
            studentTime += Time.deltaTime;

            if(roundTime <= 0)
            {
                roundTime = 0;

                endingRound = true;
            }
    	}
    }
        
    	if(endingRound){
        	StartCoroutine("Endlevel");
        	endingRound = false;
        	GameEnd = true;
    	}
        timeText.text = roundTime.ToString("0.0") + " s";
    }
    
    public void Home()
    {
    	settingPanel.SetActive(false);
    	Time.timeScale = 1f;
    }
    
    public void Setting()
    {
    	settingPanel.SetActive(true);
    	Time.timeScale = 0f;
    }
    
    public void exitLevel()
    {
    	ExitPanel.SetActive(true);
    }
    
    public void ContinueLavel()
    {
    	ExitPanel.SetActive(false);
    }
    
    //************************************************
    //			q1 
    //**************************************************
    void SetCorrectAnswereQ1_Green()
    {
    	q1b2.GetComponent<Image>().sprite = green;
    	Answeretitle2.SetActive(true);
    	disableButtons(q1b1 , q1b2, q1b3);
    	

    }
    public void Q1B1()
    {
//    	CorrectAnswere(q1b1 , title1 , Answeretitle1);
//    	disableButtons(q1b1 , q1b2, q1b3);
    	FalseAnswere(q1b1 , title1 , Answeretitle1);
    	SetCorrectAnswereQ1_Green();
    	StartCoroutine("LoadQestion2");
    }
    
    public void Q1B2()
    {
    	CorrectAnswere(q1b2 , title2 , Answeretitle2);
    	//FalseAnswere(q1b2 , title2 , Answeretitle2);
    	//SetCorrectAnswereQ1_Green();
    	disableButtons(q1b1 , q1b2, q1b3);
    	StartCoroutine("LoadQestion2");
    }
    
    public void Q1B3()
    {
    	FalseAnswere(q1b3 , title3 , Answeretitle3);
    	SetCorrectAnswereQ1_Green();
    	StartCoroutine("LoadQestion2");
    }
    
     //************************************************
    //			q2 
    //**************************************************
    
    void SetCorrectAnswereQ2_Green()
    {
    	q2b3.GetComponent<Image>().sprite = green;
    	Answeretitle23.SetActive(true);
    	disableButtons(q2b1 , q2b2, q2b3);
    }
    
    
    public void Q2B1()
    {
    	FalseAnswere(q2b1 , title21 , Answeretitle21);
    	SetCorrectAnswereQ2_Green();
    	StartCoroutine("LoadQestion3");
    }
    
    public void Q2B2()
    {
    	FalseAnswere(q2b2 , title22 , Answeretitle22);
    	//disableButtons(q2b1 , q2b2, q2b3);
    	SetCorrectAnswereQ2_Green();
    	StartCoroutine("LoadQestion3");
    }
    
    public void Q2B3()
    {
    	CorrectAnswere(q2b3 , title23 , Answeretitle23);
    	//SetCorrectAnswereQ2_Green();
    	disableButtons(q2b1 , q2b2, q2b3);
    	StartCoroutine("LoadQestion3");
    }   
    
     //************************************************
    //			q3 
    //**************************************************
    void SetCorrectAnswereQ3_Green()
    {
    	q3b3.GetComponent<Image>().sprite = green;
    	Answeretitle33.SetActive(true);
    	disableButtons(q3b1 , q3b2, q3b3);
    }
    public void Q3B1()
    {
    	FalseAnswere(q3b1 , title31 , Answeretitle31);
    	SetCorrectAnswereQ3_Green();
    	StartCoroutine("LoadQestion4");
    	//StartCoroutine("Endlevel");
    }
    
    public void Q3B2()
    {
    	FalseAnswere(q3b2 , title32 , Answeretitle32);
    	SetCorrectAnswereQ3_Green();
    	StartCoroutine("LoadQestion4");
    	//StartCoroutine("Endlevel");
    }
    
    public void Q3B3()
    {
    	CorrectAnswere(q3b3 , title33 , Answeretitle33);
    	disableButtons(q3b1 , q3b2, q3b3);
    	StartCoroutine("LoadQestion4");
    	
    	//StartCoroutine("Endlevel");
    	
    
    }
    
    
    
     //************************************************
    //			q4
    //**************************************************
    void SetCorrectAnswereQ4_Green()
    {
    	q4b1.GetComponent<Image>().sprite = green;
    	Answeretitle41.SetActive(true);
    	disableButtons(q4b1 , q4b2, q4b3);
    }
    public void Q4B1()
    {
    	CorrectAnswere(q4b1 , title41 , Answeretitle41);
    	disableButtons(q4b1 , q4b2, q4b3);
    	//SetCorrectAnswereQ4_Green();
    	StartCoroutine("LoadQestion5");
    }
    
    public void Q4B2()
    {
    	FalseAnswere(q4b2 , title42 , Answeretitle42);
    	SetCorrectAnswereQ4_Green();
    	//disableButtons(q4b1 , q4b2, q4b3);
    	StartCoroutine("LoadQestion5");
    }
    
    public void Q4B3()
    {
    	FalseAnswere(q4b3 , title43 , Answeretitle43);
    	SetCorrectAnswereQ4_Green();
    	StartCoroutine("LoadQestion5");
    }
    
//************************************************
//			q5 
//**************************************************
    
    void SetCorrectAnswereQ5_Green()
    {
    	q5b2.GetComponent<Image>().sprite = green;
    	Answeretitle52.SetActive(true);
    	disableButtons(q5b1 , q5b2, q5b3);
    }
    public void Q5B1()
    {
    	FalseAnswere(q5b1 , title51 , Answeretitle51);
    	SetCorrectAnswereQ5_Green();
    	StartCoroutine("LoadQestion6");
    }
    
    public void Q5B2()
    {
    	CorrectAnswere(q5b2 , title52 , Answeretitle52);
    	//SetCorrectAnswereQ5_Green();
    	disableButtons(q5b1 , q5b2, q5b3);
    	StartCoroutine("LoadQestion6");
    }
    
    public void Q5B3()
    {
    	FalseAnswere(q5b3 , title53 , Answeretitle53);
    	//disableButtons(q5b1 , q5b2, q5b3);
    	
    	SetCorrectAnswereQ5_Green();
    	StartCoroutine("LoadQestion6");
    } 



     //************************************************
    //			q6 
    //**************************************************
    void SetCorrectAnswereQ6_Green()
    {
    	q6b3.GetComponent<Image>().sprite = green;
    	Answeretitle63.SetActive(true);
    	disableButtons(q6b1 , q6b2, q6b3);
    }
    public void Q6B1()
    {
    	FalseAnswere(q6b1 , title61 , Answeretitle61);
    	SetCorrectAnswereQ6_Green();
    	//StartCoroutine("LoadQestion3");
    	StartCoroutine("Endlevel");
    }
    
    public void Q6B2()
    {
    	FalseAnswere(q6b2 , title62 , Answeretitle62);
    	SetCorrectAnswereQ6_Green();
    	//disableButtons(q6b1 , q6b2, q6b3);
    	//StartCoroutine("LoadQestion3");
    	StartCoroutine("Endlevel");
    }
    
    public void Q6B3()
    {
    	CorrectAnswere(q6b3 , title63 , Answeretitle63);
    	SetCorrectAnswereQ6_Green();
    	disableButtons(q6b1 , q6b2, q6b3);
    	//StartCoroutine("LoadQestion3");
    	
    	StartCoroutine("Endlevel");
    	
    
    }    

     //************************************************
    //			general functiins 
    //**************************************************

	void disableButtons(Button b1, Button b2, Button b3)
	{
		b1.interactable = false;
		b2.interactable = false;
		b3.interactable = false;
	}
    
   void FalseAnswere(Button q ,GameObject Title , GameObject answerTitile)
    {
    	q.GetComponent<Image>().sprite = red;
    	Title.SetActive(false);
    	answerTitile.SetActive(true);
    	if(level1hearts > 0)
    		level1hearts -- ;
    	
    	hearts[level1hearts].GetComponent<Image>().sprite = deadHeart;
    	
    	if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    		Handheld.Vibrate();
    	
    	if(PlayerPrefs.GetInt("sound", 1) == 1)
    		audioSource[0].Play();
    	
    	
    }
    
    void CorrectAnswere(Button q ,GameObject Title , GameObject answerTitile)
    {
    	totalCorrectQuestionNum ++;
    	q.GetComponent<Image>().sprite = green;
    	Title.SetActive(false);
    	answerTitile.SetActive(true);
    	
    	
    	
    }
    
    IEnumerator Endlevel()
    {
    	yield return new WaitForSeconds(1.5f);
    	q1.SetActive(false);
    	q2.SetActive(false);
    	q3.SetActive(false);
    	q4.SetActive(false);
    	q5.SetActive(false);
    	
    	q6.SetActive(false);
    	mainCanvas.SetActive(false);
    	
    	SetScore();
    	videoPlayers[PlayerPrefs.GetInt("level1Stars")].SetActive(true);
    	Debug.Log(PlayerPrefs.GetInt("level1Stars"));
    	for(int i = 0 ; i < videoPlayers.Length;i++)
    	{
    		if(i == PlayerPrefs.GetInt("level1Stars"))
    			videoPlayers[PlayerPrefs.GetInt("level1Stars")].GetComponent<VideoPlayer>().Play();
    		else
    			videoPlayers[i].SetActive(false);
    	}
    	if(PlayerPrefs.GetInt("sound", 1) == 1){
    	if(PlayerPrefs.GetInt("level1Stars") >= 2){
    			gameAudio.Stop();
    			audioSource[1].Play();
    		}
    		
    		else{
    			audioSource[2].Play();
    			gameAudio.Stop();}
    	
    	
    	}
    	StartCoroutine("GoNextLevel");
    	
    }
    
    void SetScore()
    {
    	PlayerPrefs.SetInt("hearts" , level1hearts);
    	float normalizedTime = (float)studentTime/ (float)benchTime;
    	float accuracyScore = (float)totalCorrectQuestionNum /(float)totalQustionNum *100f;
    	 Debug.Log(accuracyScore);
    	 overallScore = (WieghtTime * normalizedTime ) + (WieghtAccuracy * accuracyScore);
    	 
    	 Debug.Log(overallScore);
    	 
    	 if(overallScore >= 80f){
    		PlayerPrefs.SetInt("level1Stars" ,3 );
    		PlayerPrefs.SetInt("hearts" ,3 );
    		
    		if((PlayerPrefs.GetInt("level")) < 2)
    			PlayerPrefs.SetInt("level" , 2);
    		Debug.Log("level :" +PlayerPrefs.GetInt("level" , 1));
    	 }
    	 else if(overallScore < 80f && overallScore >= 60f){
    		PlayerPrefs.SetInt("level1Stars" ,2 );
    		if((PlayerPrefs.GetInt("level")) < 2)
    			PlayerPrefs.SetInt("level" , 2);
    	 }
    	 
    	else if (overallScore < 60f && overallScore >= 20f)
    		PlayerPrefs.SetInt("level1Stars" ,1 );
    	else
    		PlayerPrefs.SetInt("level1Stars" ,0 );
    	

    	
    	if( PlayerPrefs.GetInt("level1Stars") > PlayerPrefs.GetInt("Maxlevel1Stars" , 0))
    	 	PlayerPrefs.SetInt("Maxlevel1Stars" , PlayerPrefs.GetInt("level1Stars"));
    }

    
    IEnumerator LoadQestion2()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q1.SetActive(false);
    	q2.SetActive(true);}
    }
    
    
    IEnumerator LoadQestion3()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q2.SetActive(false);
    	q3.SetActive(true);}
    }
    
    IEnumerator LoadQestion4()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q3.SetActive(false);
    	q4.SetActive(true);}
    }
    
    IEnumerator LoadQestion5()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q4.SetActive(false);
    	q5.SetActive(true);}
    }
    
    IEnumerator LoadQestion6()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q5.SetActive(false);
    	q6.SetActive(true);}
    }
    
    IEnumerator GoNextLevel()
    {
    	yield return new WaitForSeconds(7.5f);
    	nextlvelcanvas.SetActive(true);
    	videoPlayers[PlayerPrefs.GetInt("level1Stars")].GetComponent<VideoPlayer>().Pause();
    	videoPlayers[PlayerPrefs.GetInt("level1Stars")].SetActive(false);
    	videoPlayers[4].SetActive(true);
    	videoPlayers[4].GetComponent<VideoPlayer>().Prepare();

    }
    
    public void NextButton()
    {
    	if(PlayerPrefs.GetInt("hearts" , 3) >= 2 || PlayerPrefs.GetInt("level") >= 2){
    	nextlvelcanvas.SetActive(false);
    	Debug.Log("playing video 4");
    	videoPlayers[4].GetComponent<VideoPlayer>().Play();
    
    	StartCoroutine(LoadScene("Level2" , 5.5f));
    	}
    	else{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource[0].Play();
    	}
    }
    
    IEnumerator LoadScene(string sceneName , float delay)
    {
    	yield return new WaitForSeconds(delay);
    
   		 SceneManager.LoadScene(sceneName);
    }
    public void HomeButtonLevelSelection()
    {
    	SceneManager.LoadScene("Levelselection");
    }
    
    
    void SetHerats()
    {
    	int deadheartsNum = 3 - PlayerPrefs.GetInt("hearts" , 3);
    	Debug.Log("initial heart : "+deadheartsNum);
    	if(deadheartsNum == 1)
    	{
    		hearts[2].GetComponent<Image>().sprite = deadHeart;
    	}
    	
    	if(deadheartsNum == 2)
    	{
    		hearts[2].GetComponent<Image>().sprite = deadHeart;
    		hearts[1].GetComponent<Image>().sprite = deadHeart;
    	}
    	
    	if(deadheartsNum == 3)
    	{
    		hearts[2].GetComponent<Image>().sprite = deadHeart;
    		hearts[1].GetComponent<Image>().sprite = deadHeart;
    		hearts[0].GetComponent<Image>().sprite = deadHeart;
    	}

    	
    }
    
    
    void ShowHint1()
    {
    	Hint1.SetActive(true);
    }
    public void ContineHint1()
    {
    	Hint1.SetActive(false);
    	Hint2.SetActive(true);
    }
    public void ContineHint2()
    {
    	Hint2.SetActive(false);
    	Hint3.SetActive(true);
    }
    public void ContineHint3()
    {
    	Hint3.SetActive(false);
    	Hint4.SetActive(true);
    }
   public void ContineHint4()
    {
    	Hint4.SetActive(false);
    	StartGame();
    	
    }
   void SetLoginSprite()
    {
    	if(PlayerPrefs.GetInt("Sex", 0) == 0 )
    		loginButton.GetComponent<Image>().sprite = man;
    	else
    		loginButton.GetComponent<Image>().sprite = woman;
    }
}
