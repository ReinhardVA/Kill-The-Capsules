using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Scene_Manager : MonoBehaviour
{
    private int _currentScore;
    private bool _isLevelComplete = false;
    public void UpdateScore(int score){
        _currentScore = score;
        CheckForSceneChange();
    }
    private void CheckForSceneChange(){
        if(_currentScore >= 50){
            _isLevelComplete = true;
            ChangeScene();
        }
    }

    private void ChangeScene(){
        if(_isLevelComplete == true){
            StartCoroutine(NextScene());
        }
    }
    IEnumerator NextScene(){
        yield return new WaitForSeconds(3.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
        while(!asyncLoad.isDone){
            yield return null;
        }
    }
    public void PauseGame(){
        Time.timeScale = 0.01f;
    }

    public void ResumeGame(){
        Time.timeScale = 1;
    }
    public void LoadMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
