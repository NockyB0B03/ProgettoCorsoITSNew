using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerManager : MonoBehaviour
{
    public static SoccerManager Instance;

    [SerializeField, ReadOnly(true)] int points = 0;
    [SerializeField] int pointsToNextGame = 5;
    [SerializeField] string ballTag = "Ball";
    public string BallTag => ballTag;
    [SerializeField] string ballSpawnTag = "BallSpawn";
    public string BallSpawnTag => ballSpawnTag;

    GameObject ballObject;
    GameObject ballSpawnPoint;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += RefreshLevelReferences;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= RefreshLevelReferences;
    }
    private void RefreshLevelReferences(Scene scene, LoadSceneMode loadSceneMode)
    {
        ballObject = GameObject.FindGameObjectWithTag("Ball");
        ballSpawnPoint = GameObject.FindGameObjectWithTag("BallSpawn");

        ResetBall();
    }

    public void ScorePoints(int _points) {
        this.points += _points;
        Debug.Log($"Scored: {_points}! Total points: {this.points}");

        if (points >= pointsToNextGame) ResetGame();
    }
    private void ResetGame()
    {
        points = 0;
        Debug.Log("Game reset");
    }

    public void ResetBall()
    {
        if (ballSpawnPoint != null && ballSpawnPoint != null)
        {
            ballObject.transform.position = ballSpawnPoint.transform.position;
            Rigidbody ballRB = ballObject.GetComponent<Rigidbody>();

            ballRB.linearVelocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;
        }
    }
}
