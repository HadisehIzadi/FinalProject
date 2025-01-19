using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("animations")]
	[SerializeField] GameObject loadingVideo;
	[Header ("stars")]
    [SerializeField] GameObject level1Stars;
    [SerializeField] GameObject level2Stars;
    [SerializeField] GameObject level3Stars;
    [SerializeField] GameObject level4Stars;
    [SerializeField] GameObject level5Stars;
    [SerializeField] GameObject level6Stars;
    [SerializeField] GameObject level7Stars; 
    
    [SerializeField] Sprite yellowStar;
    [Header ("hearts")]
    [SerializeField] GameObject[] hearts;
	[SerializeField] Sprite deadHeart;
	[Header ("panels")]
	[SerializeField] GameObject questionPanel;
	[SerializeField] GameObject settingPanel;
	//[SerializeField] GameObject loginCanvas;
	[SerializeField] GameObject mainCanvas;
	[SerializeField]  TMP_Text NameText;
	[SerializeField] Sprite man;
	[SerializeField] Sprite woman;
	[SerializeField] GameObject loginButton;
    //int activeStars;
    [Header ("audios")]
    [SerializeField] AudioSource audioSource ;
    
    [Header ("levels")]
	[SerializeField] GameObject[] levels;
	[SerializeField] Sprite levelBack;
	
	public static LevelSelection instance;
	
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		loadingVideo.SetActive(true);
		loadingVideo.GetComponent<VideoPlayer>().Prepare();
	}
    
    void Start()
    {
    	//PlayerPrefs.DeleteAll();
    	if(PlayerPrefs.GetInt("IsLoggedIn" , 0) == 0 ) // is not login befor
    		SceneManager.LoadScene("login");
    //PlayerPrefs.SetInt("hearts" , 3);
    	loadingVideo.GetComponent<VideoPlayer>().Prepare();
    	//loadingVideo.SetActive(false);
    	SetStars();
    	SetHearts();
    	SetLevels();
    	SetLoginSprite();
    	questionPanel.SetActive(false);
    	settingPanel.SetActive(false);
    	NameText.text =  " سلام " + PlayerPrefs.GetString("username", "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Home()
    {
    	questionPanel.SetActive(false);
    	settingPanel.SetActive(false);
    }
    
    public void Setting()
    {
    	settingPanel.SetActive(true);
    }
    
    public void Question()
    {
    	questionPanel.SetActive(true);
    }
    
    public void Level1()
    {
    	
    	//loadingVideo.SetActive(true);
    	mainCanvas.SetActive(false);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	if(PlayerPrefs.GetInt("level" , 1) <1 )
    		PlayerPrefs.SetInt("level" , 1);
    	StartCoroutine(LoadScene("preLvl1" , 3.5f));
    }
    
    public void Level2()
    {
    	if(canGoLevel[1] == true){
    	mainCanvas.SetActive(false);
    	//loadingVideo.SetActive(true);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	//PlayerPrefs.SetInt("level" , 1);
    	StartCoroutine(LoadScene("level" , 3.5f));
    	}
    	
    	else
    	{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource.Play();
    	}
    	
    }
    
    public void Level3()
    {
    	if(canGoLevel[2] == true){
    	mainCanvas.SetActive(false);	
    	//loadingVideo.SetActive(true);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	
    	//PlayerPrefs.SetInt("level" , 1);
    	
    	StartCoroutine(LoadScene("level2" , 3.5f));
    	}
    	
    	else
    	{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource.Play();
    	}
    	
    }
    
    
    
    public void Level4()
    {
    	if(canGoLevel[3] == true){
    	mainCanvas.SetActive(false);	
    	//loadingVideo.SetActive(true);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	

    	
    	StartCoroutine(LoadScene("level3" , 3.5f));
    	}
    	
    	else
    	{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource.Play();
    	}
    	
    }
    
    public void Level5()
    {
    	if(canGoLevel[4] == true){
    	mainCanvas.SetActive(false);	
    	//loadingVideo.SetActive(true);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	

    	
    	StartCoroutine(LoadScene("level4" , 3.5f));
    	}
    	
    	else
    	{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource.Play();
    	}
    	
    }
    
    
    public void Level6()
    {
    	if(canGoLevel[5] == true){
    	mainCanvas.SetActive(false);
    	//loadingVideo.SetActive(true);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	

    	
    	StartCoroutine(LoadScene("level5" , 3.5f));
    	}
    	
    	else
    	{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource.Play();
    	}
    	
    }
    
    
    
    
    
    public void Level7()
    {
    	if(canGoLevel[6] == true){
    	mainCanvas.SetActive(false);	
    	//loadingVideo.SetActive(true);
    	loadingVideo.GetComponent<VideoPlayer>().Play();
    	

    	
    	StartCoroutine(LoadScene("exam" , 3.5f));
    	}
    	
    	else
    	{
    		if(PlayerPrefs.GetInt("Vibrate", 1) == 1)
    			Handheld.Vibrate();
    	
    		if(PlayerPrefs.GetInt("sound", 1) == 1)
    			audioSource.Play();
    	}
    	
    }
    
    
    public void Login()
    {
    	SceneManager.LoadScene("login");
    }
    public void GreenButton()
    {
        
       if(PlayerPrefs.GetInt("level") != 4)
            SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
        
        
    }
    
    
    void SetStars()
    {
    	int activeStars1 = PlayerPrefs.GetInt("MaxPreLevelStars" , 0);
    	for(int i = 0 ; i < activeStars1 ;i++)
    		level1Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
    	
    	int activeStars2 = PlayerPrefs.GetInt("Maxlevel1Stars" , 0);
    	for(int i = 0 ; i < activeStars2;i++)
    		level2Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
    	int activeStars3 = PlayerPrefs.GetInt("Maxlevel2Stars" , 0);
    	for(int i = 0 ; i < activeStars3;i++)
    		level3Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
    	int activeStars4 = PlayerPrefs.GetInt("Maxlevel3Stars" , 0);
    	for(int i = 0 ; i < activeStars4;i++)
    		level4Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
    	int activeStars5 = PlayerPrefs.GetInt("Maxlevel4Stars" , 0);
    	for(int i = 0 ; i < activeStars5;i++)
    		level5Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
    	int activeStars6 = PlayerPrefs.GetInt("Maxlevel5Stars" , 0);
    	for(int i = 0 ; i < activeStars6;i++)
    		level6Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
    	
    	int activeStars7 = PlayerPrefs.GetInt("Maxlevel6Stars" , 0);
    	for(int i = 0 ; i < activeStars7;i++)
    		level7Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    	
//    	int activeStars8 = PlayerPrefs.GetInt("Maxlevel7Stars" , 0);
//    	for(int i = 0 ; i < activeStars8;i++)
//    		level8Stars.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = yellowStar;
    }
    
    
    void SetHearts()
    {
    	int deadHeartIndex = 3- PlayerPrefs.GetInt("hearts" , 3);
    	for(int i = 0 ; i < deadHeartIndex;i++)
    		hearts[i].GetComponent<Image>().sprite = deadHeart;
    }
    
    IEnumerator LoadScene(string sceneName , float delay)
    {
    	yield return new WaitForSeconds(delay);
    
   		 SceneManager.LoadScene(sceneName);
    }
    
    public bool[] canGoLevel = {true , false , false , false , false , false , false};
    void SetLevels() 
    {
    
    	for(int i = 1 ; i <= PlayerPrefs.GetInt("level" , 1);i++)
    	{
            // baraye roidad mantaghe 
            if (i != 3)
            {
                levels[i].gameObject.GetComponent<Image>().sprite = levelBack;
                levels[i].transform.GetChild(0).gameObject.SetActive(true);
                levels[i].transform.GetChild(2).gameObject.SetActive(true);
                canGoLevel[i] = true;
            }
    	}
    }
    
    void SetLoginSprite()
    {
    	if(PlayerPrefs.GetInt("Sex", 0) == 0 )
    		loginButton.GetComponent<Image>().sprite = man;
    	else
    		loginButton.GetComponent<Image>().sprite = woman;
    }
    
    
}
