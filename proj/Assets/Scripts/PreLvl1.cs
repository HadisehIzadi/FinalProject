using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
public class PreLvl1 : MonoBehaviour
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
	[SerializeField] GameObject q7;
	[SerializeField] GameObject q8;
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

	
	[Header("qestion 1 / button 2")]
	[SerializeField] Button q1b2;
	[SerializeField] GameObject title2;


	[Header("qestion 1 / button 3")]
	[SerializeField] Button q1b3;
	[SerializeField] GameObject title3;
	
	
	//************************************************
    //			q2 
    //**************************************************	
	[Header("qestion 2 / button 1")]
	[SerializeField] Button q2b1;
	[SerializeField] GameObject title21;

	
	[Header("qestion 2 / button 2")]
	[SerializeField] Button q2b2;
	[SerializeField] GameObject title22;


	[Header("qestion 2 / button 3")]
	[SerializeField] Button q2b3;
	[SerializeField] GameObject title23;




	//************************************************
    //			q3 
    //**************************************************	
	[Header("qestion 3 / button 1")]
	[SerializeField] Button q3b1;
	[SerializeField] GameObject title31;

	
	[Header("qestion 3 / button 2")]
	[SerializeField] Button q3b2;
	[SerializeField] GameObject title32;


	[Header("qestion 3 / button 3")]
	[SerializeField] Button q3b3;
	[SerializeField] GameObject title33;
	
	
	
	
	
	//************************************************
    //			q4 
    //**************************************************	
	[Header("qestion 4 / button 1")]
	[SerializeField] Button q4b1;
	[SerializeField] GameObject title41;

	
	[Header("qestion 4 / button 2")]
	[SerializeField] Button q4b2;
	[SerializeField] GameObject title42;


	[Header("qestion 4 / button 3")]
	[SerializeField] Button q4b3;
	[SerializeField] GameObject title43;

	
	//************************************************
    //			q5
    //**************************************************	
	[Header("qestion 5 / button 1")]
	[SerializeField] Button q5b1;
	[SerializeField] GameObject title51;

	
	[Header("qestion 5 / button 2")]
	[SerializeField] Button q5b2;
	[SerializeField] GameObject title52;


	[Header("qestion 5 / button 3")]
	[SerializeField] Button q5b3;
	[SerializeField] GameObject title53;
	
	
	//************************************************
    //			q6
    //**************************************************	
	[Header("qestion 6 / button 1")]
	[SerializeField] Button q6b1;
	[SerializeField] GameObject title61;

	
	[Header("qestion 6 / button 2")]
	[SerializeField] Button q6b2;
	[SerializeField] GameObject title62;


	[Header("qestion 6 / button 3")]
	[SerializeField] Button q6b3;
	[SerializeField] GameObject title63;
	
	//************************************************
    //			q7
    //**************************************************	
	[Header("qestion 7/ button 1")]
	[SerializeField] Button q7b1;
	[SerializeField] GameObject title71;

	
	[Header("qestion 7 / button 2")]
	[SerializeField] Button q7b2;
	[SerializeField] GameObject title72;


	[Header("qestion 7 / button 3")]
	[SerializeField] Button q7b3;
	[SerializeField] GameObject title73;
	

	//************************************************
    //			q8
    //**************************************************	
	[Header("qestion 8/ button 1")]
	[SerializeField] Button q8b1;
	[SerializeField] GameObject title81;

	
	[Header("qestion 8 / button 2")]
	[SerializeField] Button q8b2;
	[SerializeField] GameObject title82;


	[Header("qestion 8 / button 3")]
	[SerializeField] Button q8b3;
	[SerializeField] GameObject title83;
	
	
	public static PreLvl1 instance;
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
    }
    
    void StartGame()
    {
    	SetHerats();
    	SetLoginSprite();
    	isStarted = true;

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
    	q1b3.GetComponent<Image>().sprite = green;
    	disableButtons(q1b1 , q1b2, q1b3);
    	

    }
    public void Q1B1()
    {

    	FalseAnswere(q1b1);
    	SetCorrectAnswereQ1_Green();
    	StartCoroutine("LoadQestion2");
    }
    
    public void Q1B2()
    {
    	FalseAnswere(q1b2);
		SetCorrectAnswereQ1_Green();
    	StartCoroutine("LoadQestion2");
    }
    
    public void Q1B3()
    {
    	CorrectAnswere(q1b3);
    	disableButtons(q1b1 , q1b2, q1b3);
    	StartCoroutine("LoadQestion2");
    }
    
    
    
    //************************************************
    //			q2
    //**************************************************
    void SetCorrectAnswereQ2_Green()
    {
    	q2b2.GetComponent<Image>().sprite = green;
    	disableButtons(q2b1 , q2b2, q2b3);
    	

    }
    public void Q2B1()
    {

    	FalseAnswere(q2b1);
    	SetCorrectAnswereQ2_Green();
    	StartCoroutine("LoadQestion3");
    }
    
    public void Q2B2()
    {
    	CorrectAnswere(q2b2);
    	disableButtons(q2b1, q2b2, q2b3);
    	StartCoroutine("LoadQestion3");
    }
    
    public void Q2B3()
    {
    	FalseAnswere(q3b3);
    	SetCorrectAnswereQ2_Green();
    	StartCoroutine("LoadQestion3");
    }
    //************************************************
    //			q3
    //**************************************************
    void SetCorrectAnswereQ3_Green()
    {
    	q3b3.GetComponent<Image>().sprite = green;
    	disableButtons(q3b1 , q3b2, q3b3);
    	

    }
    public void Q3B1()
    {

    	FalseAnswere(q3b1);
    	SetCorrectAnswereQ3_Green();
    	StartCoroutine("LoadQestion4");
    }
    
    public void Q3B2()
    {
    	FalseAnswere(q3b2);
    	SetCorrectAnswereQ3_Green();
    	
    	StartCoroutine("LoadQestion4");
    }
    
    public void Q3B3()
    {
    	CorrectAnswere(q3b3);
    	disableButtons(q3b1 , q3b2, q3b3);
    	StartCoroutine("LoadQestion4");
    }
    
    
    
    //************************************************
    //			q4
    //**************************************************
    void SetCorrectAnswereQ4_Green()
    {
    	q4b1.GetComponent<Image>().sprite = green;
    	disableButtons(q4b1 , q4b2, q4b3);
    	

    }
    public void Q4B1()
    {

    	CorrectAnswere(q4b1);
    	disableButtons(q4b1 , q4b2, q4b3);
    	StartCoroutine("LoadQestion5");
    }
    
    public void Q4B2()
    {
    	FalseAnswere(q4b2);
    	SetCorrectAnswereQ4_Green();
    	
    	StartCoroutine("LoadQestion5");
    }
    
    public void Q4B3()
    {
    	FalseAnswere(q4b3);
    	SetCorrectAnswereQ4_Green();
    	StartCoroutine("LoadQestion5");
    }
    
    
    
    //************************************************
    //			q5
    //**************************************************
    void SetCorrectAnswereQ5_Green()
    {
    	q5b2.GetComponent<Image>().sprite = green;
    	disableButtons(q5b1 , q5b2, q5b3);
    	

    }
    public void Q5B1()
    {

    	FalseAnswere(q5b1);
    	SetCorrectAnswereQ5_Green();
    	StartCoroutine("LoadQestion6");
    }
    
    public void Q5B2()
    {
    	CorrectAnswere(q5b2);
    	disableButtons(q5b1 , q5b2, q5b3);
    	
    	StartCoroutine("LoadQestion6");
    }
    
    public void Q5B3()
    {
    	FalseAnswere(q5b3);
    	SetCorrectAnswereQ5_Green();
    	StartCoroutine("LoadQestion6");
    }
    
    
    //************************************************
    //			q6
    //**************************************************
    void SetCorrectAnswereQ6_Green()
    {
    	q6b1.GetComponent<Image>().sprite = green;
    	disableButtons(q6b1 , q6b2, q6b3);
    	

    }
    public void Q6B1()
    {

    	CorrectAnswere(q6b1);
    	disableButtons(q6b1 , q6b2, q6b3);
    	StartCoroutine("LoadQestion7");
    }
    
    public void Q6B2()
    {
    	FalseAnswere(q6b2);
    	SetCorrectAnswereQ6_Green();
    	
    	StartCoroutine("LoadQestion7");
    }
    
    public void Q6B3()
    {
    	FalseAnswere(q6b3);
    	SetCorrectAnswereQ6_Green();
    	StartCoroutine("LoadQestion7");
    }
    
    
    //************************************************
    //			q7
    //**************************************************
    void SetCorrectAnswereQ7_Green()
    {
    	q7b3.GetComponent<Image>().sprite = green;
    	disableButtons(q7b1 , q7b2, q7b3);
    	

    }
    public void Q7B1()
    {

    	FalseAnswere(q7b1);
    	SetCorrectAnswereQ7_Green();
    	StartCoroutine("LoadQestion8");
    }
    
    public void Q7B2()
    {
    	FalseAnswere(q7b2);
    	SetCorrectAnswereQ7_Green();
    	
    	StartCoroutine("LoadQestion8");
    }
    
    public void Q7B3()
    {
    	CorrectAnswere(q7b3);
    	disableButtons(q7b1 , q7b2, q7b3);
    	StartCoroutine("LoadQestion8");
    }
    
    
    //************************************************
    //			q8
    //**************************************************
    void SetCorrectAnswereQ8_Green()
    {
    	q8b2.GetComponent<Image>().sprite = green;
    	disableButtons(q8b1 , q8b2, q8b3);
    	

    }
    public void Q8B1()
    {

    	FalseAnswere(q8b1);
    	SetCorrectAnswereQ8_Green();
    	StartCoroutine("Endlevel");
    }
    
    public void Q8B2()
    {
    	CorrectAnswere(q8b2);
    	disableButtons(q8b1 , q8b2, q8b3);
    	StartCoroutine("Endlevel");
    }
    
    public void Q8B3()
    {
    	FalseAnswere(q8b3);
    	SetCorrectAnswereQ8_Green();
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
    
   void FalseAnswere(Button q)
    {
    	q.GetComponent<Image>().sprite = red;
    	if(level1hearts > 0)
    		level1hearts -- ;
    	
    	hearts[level1hearts].GetComponent<Image>().sprite = deadHeart;
    	
    	if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    		Handheld.Vibrate();
    	
    	if(PlayerPrefs.GetInt("sound", 1) == 1)
    		audioSource[0].Play();
    	
    	
    }
    
    void CorrectAnswere(Button q )
    {
    	totalCorrectQuestionNum ++;
    	q.GetComponent<Image>().sprite = green;
    	
    	if(PlayerPrefs.GetInt("sound", 1) == 1)
    		audioSource[3].Play();
    	
    	
    	
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
    	q7.SetActive(false);
    	q8.SetActive(false);
    	mainCanvas.SetActive(false);
    	
    	SetScore();
    	videoPlayers[PlayerPrefs.GetInt("PreLevelStars")].SetActive(true);
    	Debug.Log(PlayerPrefs.GetInt("PreLevelStars"));
    	for(int i = 0 ; i < videoPlayers.Length;i++)
    	{
    		if(i == PlayerPrefs.GetInt("PreLevelStars"))
    			videoPlayers[PlayerPrefs.GetInt("PreLevelStars")].GetComponent<VideoPlayer>().Play();
    		else
    			videoPlayers[i].SetActive(false);
    	}
    	if(PlayerPrefs.GetInt("sound", 1) == 1){
    	if(PlayerPrefs.GetInt("PreLevelStars") >= 2){
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
    		PlayerPrefs.SetInt("PreLevelStars" ,3 );
    		PlayerPrefs.SetInt("hearts" ,3 );
    		
    		if((PlayerPrefs.GetInt("level")) < 1)
    			PlayerPrefs.SetInt("level" , 1);
    		Debug.Log("level :" +PlayerPrefs.GetInt("level" , 1));
    	 }
    	 else if(overallScore < 80f && overallScore >= 60f){
    		PlayerPrefs.SetInt("PreLevelStars" ,2 );
    		if((PlayerPrefs.GetInt("level")) < 1)
    			PlayerPrefs.SetInt("level" , 1);
    	 }
    	 
    	else if (overallScore < 60f && overallScore >= 20f)
    		PlayerPrefs.SetInt("PreLevelStars" ,1 );
    	else
    		PlayerPrefs.SetInt("PreLevelStars" ,0 );
    	

    	
    	if( PlayerPrefs.GetInt("PreLevelStars") > PlayerPrefs.GetInt("MaxPreLevelStars" , 0))
    	 	PlayerPrefs.SetInt("MaxPreLevelStars" , PlayerPrefs.GetInt("PreLevelStars"));
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
    
    IEnumerator LoadQestion7()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q6.SetActive(false);
    	q7.SetActive(true);}
    }
    
    
    IEnumerator LoadQestion8()
    {
    	if(!GameEnd){
    	yield return new WaitForSeconds(2.5f);
    	q7.SetActive(false);
    	q8.SetActive(true);}
    }
    
    IEnumerator GoNextLevel()
    {
    	yield return new WaitForSeconds(7.9f);
    	nextlvelcanvas.SetActive(true);
    	videoPlayers[PlayerPrefs.GetInt("PreLevelStars")].GetComponent<VideoPlayer>().Pause();
    	videoPlayers[PlayerPrefs.GetInt("PreLevelStars")].SetActive(false);
    	videoPlayers[4].SetActive(true);
    	videoPlayers[4].GetComponent<VideoPlayer>().Prepare();

    }
    
    public void NextButton()
    {
    	if(PlayerPrefs.GetInt("hearts" , 3) >= 2 || PlayerPrefs.GetInt("level") >= 2){
    	nextlvelcanvas.SetActive(false);
    	Debug.Log("playing video 4");
    	videoPlayers[4].GetComponent<VideoPlayer>().Play();
    
    	StartCoroutine(LoadScene("Level" , 5f));
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
