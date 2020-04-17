using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Rigidbody ball;
    private float speedRejection = 10.0f;
    private float forceRebound = 50.0f;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LifesText;
    public TextMeshProUGUI highScore;
    private int score = 0;
    public int lifes = 3;
    public bool gameOver = false;
    public AudioSource greenSphere;
    public AudioSource blackCube;
    public ParticleSystem sphereParticles;
    public ParticleSystem cubeParticles;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.transform.position = new Vector3(0, 20, 0);
        Physics.gravity = new Vector3(0, -30.0F, 0);

        //High Score initialiation
        highScore.text = PlayerPrefs.GetInt("Highest Score", 0).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateBall();

        UpdateScore(score);
        UpdateLifes(lifes);

        HighestScore();

        if (lifes <= 1)
        {
            gameOver = true;
        }

        GameOver();
    }

    private void OnCollisionEnter(Collision other)
    {
        //Collision with bounds and rebound
        if (other.gameObject.CompareTag("Right"))
        {
            ball.AddForce(Vector3.left * speedRejection, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Left"))
        {
            ball.AddForce(Vector3.right * speedRejection, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Down"))
        {
            lifes -= 1;
            UpdateLifes(lifes);

            if (!gameOver)
            {
                RestartBall();
            }
        }

        //Collision with sphere collider's character
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction;
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(other.gameObject.transform.position);
            Vector3 ballPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            float ballAngle = playerPosition.x - ballPosition.x;


            if (ballAngle < -50)
            {
                direction = new Vector3(1, 0.5f, 0);
            }
            else
            if (ballAngle >= -50 && ballAngle < -10)
            {
                direction = new Vector3(0.5f, 1, 0);
            }
            else

            if (ballAngle > 10 && ballAngle <= 50)
            {
                direction = new Vector3(-0.5f, 1, 0);
            }
            else
            if (ballAngle > 50)
            {
                direction = new Vector3(-1, 0.5f, 0);
            }
            else
            {
                direction = Vector3.up;
            }



            ball.AddForce(direction * forceRebound, ForceMode.Impulse);
        }

        //Collision with parietal's character
        /*if (other.gameObject.CompareTag("ParietalDer"))
        {
            ball.AddForce((Vector3.right + Vector3.up) * (forceRebound / 2), ForceMode.Impulse);

        }
        else

        if (other.gameObject.CompareTag("ParietalIzq"))
        {
            ball.AddForce((Vector3.left + Vector3.up) * (forceRebound / 2), ForceMode.Impulse);

        }
        else

        if (other.gameObject.CompareTag("Frente"))
        {
            ball.AddForce(Vector3.up * forceRebound, ForceMode.Impulse);
        }*/


        //Collision with objects and destroy
        if (other.gameObject.CompareTag("Sphere"))
        {
            greenSphere.Play();
            sphereParticles.transform.position = transform.position;
            sphereParticles.Play();
            Destroy(other.gameObject);
            score += 5;
        }

        if (other.gameObject.CompareTag("Cube"))
        {
            blackCube.Play();
            cubeParticles.transform.position = transform.position;
            cubeParticles.Play();
            Destroy(other.gameObject);
            score -= 1;
        }
    }

    void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    void UpdateLifes(int lifes)
    {
        LifesText.text = "Lifes: " + lifes;
    }

    void RestartBall()
    {
        transform.position = new Vector3(0, 25, 0);
    }

    void RotateBall()
    {
        ball.AddTorque(new Vector3(1, 1, 1));
    }

    void GameOver()
    {
        if (lifes < 1)
        {
            gameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    void HighestScore()
    {
        if (score > PlayerPrefs.GetInt("Highest Score", 0))
        {
            PlayerPrefs.SetInt("Highest Score", score);
            highScore.text = score.ToString();
        }
    }
}
