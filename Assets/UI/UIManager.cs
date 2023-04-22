using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject HUD;

    [SerializeField]
    private GameObject PausePlayMenu;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private AnimationHandler anim;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private Rotation rotation;

    [SerializeField]
    private GameObject optionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
        GameObject player = GameObject.FindWithTag("Player");

        if (slider == null) { slider = GameObject.Find("SensitivitySlider").GetComponent<Slider>(); }
        if (volumeSlider == null) { volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>(); }
        if (mainMenu == null) { mainMenu = GameObject.Find("mainMenu"); }

        if (optionsPanel == null) { optionsPanel = GameObject.Find("OptionsPanel"); }

        if (HUD == null) { HUD = GameObject.Find("HUD"); }

        if (PausePlayMenu == null) { PausePlayMenu = GameObject.Find("PausePlayMenu"); }


        if (anim == null) { anim = player.GetComponent<AnimationHandler>(); }
        if(scoreText == null) { scoreText = GameObject.Find("_Score").GetComponent<TextMeshProUGUI>(); }
        if(healthText == null) { healthText = GameObject.Find("_Health").GetComponent<TextMeshProUGUI>(); }

        if (highScoreText == null) { highScoreText = GameObject.Find("_HighScore").GetComponent<TextMeshProUGUI>(); }

        if ( rotation == null) { rotation = player.GetComponent<Rotation>(); }

        if(PlayerPrefs.HasKey("Mouse Sensitivity"))
        {
            slider.value = PlayerPrefs.GetFloat("Mouse Sensitivity");
            rotation.setSpeed(slider.value);
        }
        else
        {
            PlayerPrefs.SetFloat("Mouse Sensitivity", slider.value);
        }


        //checks if the musicVolue variable has no saved volume settings, and sets the variable to one if it's empty
        //Then run the Load function
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            Load();
        }
        //Runs the Load function if there is an existing volume setting
        else
        {
            Load();
        }

        optionsPanel.SetActive(false);

        HUD.SetActive(false);

        PausePlayMenu.SetActive(false);

    }
    public void StartButton()
    {
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainMenu.SetActive(false);
        HUD.SetActive(true);
        PausePlayMenu.SetActive(false);
        
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void setHealthText(string health)
    {
        healthText.text = health;
    }

    public void setScoreText(string score)
    {
        scoreText.text = score;
    }

    public void setHighScore( string highScore)
    {
        highScoreText.text = highScore;
    }

    //Changes the sensitivity of mouse rotation any time the player makes adjustments
    public void setSensitivity() 
    {
        rotation.setSpeed(slider.value);
        PlayerPrefs.SetFloat("Mouse Sensitivity", slider.value);
    }

    //Attaches the game audio volume to the volume slider and runs the Save function
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    //Loads the previous volume saved on the musicVolume variable when the game starts
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    //Saves the user volume settings in the musicVolume variable
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        PausePlayMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        PausePlayMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    //Checks if player has a previous high score greater than zero before proceeding to reset high score
    public void ResetScore()
    {
        if(PlayerPrefs.HasKey("HighScore") && PlayerPrefs.GetFloat("HighScore") > 0)
        {
            PlayerPrefs.DeleteKey("HighScore");
            setHighScore("0");
        }
        else
        {
            Debug.Log("High Socre already cleared!");
        }
    }


}
