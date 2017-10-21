using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spacecraft : MonoBehaviour {

    private float turnForce = 12f;
    private float forwardForce = 16f;
    private float upSpeed = 10f;
    private Rigidbody myBody;
    private ObstacleSpawner obsSpawner;
    [SerializeField]
    private Text scoreText, timeText, finalScoreText;
    private int score;
    private float timeToEnd;
    private AudioSource soundPlayer;
    [SerializeField]
    private AudioClip zap;
    [SerializeField]
    private GameObject gameOverPanel;
    public bool gameOver;

	// Use this for initialization
	void Awake () {
        gameOver = false;
        Time.timeScale = 1f;
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        score = 0;
        gameOverPanel.SetActive(false);
        soundPlayer = this.GetComponent<AudioSource>();
        timeToEnd = Time.time + 6f;
        updateScoreText();
        obsSpawner = GetComponent<ObstacleSpawner>();
        myBody = this.GetComponent<Rigidbody>();
	}


    void updateScoreText ()
    {
        scoreText.text = "Score:" + score; 
    }
	
	// Update is called once per frame
	void Update () {
        moveSpaceship();
        checkConstraints();
        updateTime();
	}

    void updateTime ()
    {
        float newTime = timeToEnd - Time.time;
        if (newTime > 0)
        {
            timeText.text = newTime.ToString("F2") + "s";
        } else
        {
            GameOverPanel(score);
        }
    }

    void checkConstraints()
    {
        if (transform.position.y >= 62.8f)
        {
            Application.LoadLevel("MainScene");
        }   
    }

    void moveSpaceship ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump"))
        {
            myBody.AddForce(new Vector3(h * turnForce, upSpeed, v * forwardForce), ForceMode.Impulse);
        } else
        {
            myBody.AddForce(new Vector3(h * turnForce, 0, v * forwardForce), ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            score++;
            soundPlayer.PlayOneShot(zap);
            timeToEnd += 2.2f;
            updateScoreText();
            Destroy(other.gameObject);
            obsSpawner.nextObstacle();
            
        } else
        {
            GameOverPanel(score);
        }
    }

    void GameOverPanel (int score)
    {
        gameOver = true;
        timeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score:" + score; 
    }

    public void restartButton()
    {
        Application.LoadLevel("MainScene");
    }

    public void mainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
