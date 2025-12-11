using System.Collections;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class Porta : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(SoccerManager.Instance.BallTag))
        {
            SoccerManager.Instance.ScorePoints(1);
            StartCoroutine(BallResetWait());
        }
    }

    IEnumerator BallResetWait()
    {
        yield return new WaitForSeconds(0.5f);
        SoccerManager.Instance.ResetBall();
    }
}
