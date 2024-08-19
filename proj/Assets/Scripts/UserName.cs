using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UserName : MonoBehaviour
{
	string UserNameinput;
	string Userage;
	string UserSchool;
	[Header("sex buttons ")]
	[SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image[] sexButtons;
    int selectedSex;
    
    // Start is called before the first frame update
    void Start()
    {
        selectedSex = PlayerPrefs.GetInt("Sex", 0);
    	SetupSexButton(selectedSex);
    }
    
    
    void SetupSexButton(int selected)
    {
    	for(int i = 0 ; i < sexButtons.Length ; i++)
    	{
    		if(i == selected)
    			sexButtons[i].sprite = optionsOnSprite;
    		else
    			sexButtons[i].sprite = optionsOffSprite;
    	}
    }
    
    
    public void Man()
    {
    	SetupSexButton(0);
    	PlayerPrefs.SetInt("Sex", 0);
    	
    }
    
    
     public void woman()
    {
    	SetupSexButton(1);
    	PlayerPrefs.SetInt("Sex", 1);
    	
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void GetUserName(string name)
    {
    	UserNameinput = name;
    	PlayerPrefs.SetString("username", UserNameinput);
    	Debug.Log(UserNameinput);
    	PlayerPrefs.SetInt("IsLoggedIn" , 1);
    	
    }
    
    public void GetUserAge(string age)
    {
    	Userage = age;
    	PlayerPrefs.SetString("Age", Userage);
    	Debug.Log("age  : "+Userage);
    }
    
    public void GetSchool(string scName)
    {
    	UserSchool = scName;
    	PlayerPrefs.SetString("School", UserSchool);
    	Debug.Log("school : "+UserSchool);
    }

    
    public void Home()
    {
    	SceneManager.LoadScene("Levelselection");
    }
}
