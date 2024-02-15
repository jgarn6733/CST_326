using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public LeftScore leftScore;
    public RightScore rightScore;
    public GameObject speedUp;
    public GameObject smaller;

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;
    private int totalScores = 0;
    private Vector3 ballStartPos;
    private bool leftColor = true;
    private bool rightColor = true;

    private const int scoreToWin = 11;

    // Start is called before the first frame update
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    // If the ball entered the goal area, increment the score, check for win, and reset the ball
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            rightScore.UpdateScore(rightPlayerScore, rightColor);
            Debug.Log($"Right player scored: {rightPlayerScore}");
            rightColor = !rightColor;
            
            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
            }
            else
            {
                ResetBall(-1f);
            }
        }
        else if (trigger == rightGoalTrigger)
        {

            leftPlayerScore++;
            leftScore.UpdateScore(leftPlayerScore, leftColor);
            Debug.Log($"Left player scored: {leftPlayerScore}");
            leftColor = !leftColor;
            if (rightPlayerScore == scoreToWin)
            {
                Debug.Log("Right player wins!");
            }
            else
            {
                ResetBall(1f);
            }
        }

        totalScores++;
    }

    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;
        ball.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();

        if (totalScores == 2)
        {
            Instantiate(speedUp);
        } else if (totalScores == 4)
        {
            Instantiate(smaller);
        }

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }

    public void SpeedUp()
    {
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ballRb.velocity *= 1.5f;
    }

    public void Smaller()
    {
        Transform ballTransform = ball.GetComponent<Transform>();
        ballTransform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
