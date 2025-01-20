using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject pauseMenu;
    private Scene_Manager _sceneManager;
    private bool _isGameFreeze = false; 
    public TextMeshProUGUI scoreText;
    private int _score;
    private float _previousInputValue = 0f;
    void Start(){
        _sceneManager = GameObject.Find("Scene Manager").GetComponent<Scene_Manager>();
        pauseMenu.SetActive(false);
    }
    void Update(){
        float currentInputValue = Input.GetAxis("Escape");
        if(currentInputValue > 0 && _previousInputValue == 0)
        {
            ChangeGameState();
        }

        _previousInputValue = currentInputValue;
    }

    public void IncreaseScore(int scoreValue){
        _score += scoreValue;
        UpdateScoreUI();
        if(_sceneManager != null){
            _sceneManager.UpdateScore(_score);
        }
    }

    private void UpdateScoreUI(){
        scoreText.text = "Score: " + _score.ToString();
    }
    private void ChangeGameState()
    {
        if (_isGameFreeze)
        {
            _sceneManager.ResumeGame();
            _isGameFreeze = false;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            _sceneManager.PauseGame();
            _isGameFreeze = true;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
