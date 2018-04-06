using UnityEngine;
using System.Collections;

public class PositionsReference : MonoBehaviour
{
    public static PositionsReference Instance
    {
        get {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PositionsReference>();
            }
            return _instance;
        }
    }

    private static PositionsReference _instance;

    public Transform startBall;

    public Transform ringRightRange;

    public Transform ringLeftRange;

    public Transform obstacleSpawnRightPos;

    public Transform obstacleSpawnLeftPos;

    public Transform cointSpawnRightPos;

    public Transform cointSpawnLeftPos;

    public Transform ballTargetLeftPos;
    public Transform ballTargetCenterPos;
    public Transform ballTargetRightPos;

    private void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
}
