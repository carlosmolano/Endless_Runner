using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	
    public static GameManager Instance { set; get; }

	public Text scoreText;
    public Text coinsText;
	public Text totalScoreText;
	public Text totalCoinsText;
	public Text finalScoreText;
	public GameObject gameOverPanel;
	public GameObject puntuacionPanel;
    
	public AudioClip[] audioClips;
    
	public AudioSource SFX;
	public ParticleSystem coinsParticles;


    private bool isGameStarted = false;
    private PlayerMotor motor;
	private AudioSource sound;

   
    private float score;
    private float coins;
	private float finalScore;

	public bool IsGameStarted{
		get{
			return isGameStarted;
		}
	}

    void Awake(){
        Instance = this;
        UpdateScores();
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
		sound = GetComponent<AudioSource>();
    }

    void Update(){
        if(isGameStarted){
            score += (Time.deltaTime*2);
            scoreText.text = score.ToString("0");
        }
    }

    public void UpdateScores(){
        scoreText.text = score.ToString();
        coinsText.text = coins.ToString();
    }

    public void GetCollectable(int collectableAmn, int audioIndex){
		if (collectableAmn >= 15)
        {
            coinsParticles.Play(true);
			coins += collectableAmn;

        }
        coins++;
		score += collectableAmn;
		sound.PlayOneShot(audioClips[audioIndex]);

        UpdateScores();
    }
    public void StartGame(){
        isGameStarted = true;
        motor.StartRun();
    }

	public void GameOver(){
		gameOverPanel.SetActive(true);
		sound.pitch = 1;
		sound.PlayOneShot(audioClips[2]);
		finalScore = coins + score;
		puntuacionPanel.SetActive(true);
        totalScoreText.text = score.ToString("0");
        totalCoinsText.text = coins.ToString("0");
        finalScoreText.text = finalScore.ToString("0");
		SFX.Stop();
    }
       
	public void playAgain()
    {
		Invoke("LoadScene", 1f);
    }

	void LoadScene(){
		SceneManager.LoadScene(0);
	}

}
