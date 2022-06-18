using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator transition;
    public PlayerController playerController;

    public float transitionTime = 1f;
    private GameObject timerController;
    private GameObject backgroundMusic;
    public GameObject victoryScreen;
    public TextMeshProUGUI timeAchievedText;

    void Start(){
        timerController = GameObject.FindGameObjectWithTag("TimerController");
        backgroundMusic = GameObject.FindGameObjectWithTag("MusicPlayerManager");
    }

    void Update()
    {
        if(!playerController.IsAlive()){
            if(SceneManager.GetActiveScene().buildIndex == 1)
                SceneManager.LoadScene(1);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void LoadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex + 1 < 22)
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        else
            EndGame();
    }

    public void RestartGame(){
        Destroy(timerController);
        Destroy(backgroundMusic);
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(1));
    }

    private void EndGame(){
        victoryScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        timeAchievedText.text = timerController.GetComponent<TimerController>().GetTime();
    }

    IEnumerator LoadLevel(int levelIndex){
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}