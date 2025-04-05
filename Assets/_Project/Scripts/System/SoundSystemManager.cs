using UnityEngine;
using MoreMountains.Feedbacks;

public class SoundSystemManager : MonoBehaviour
{
    public static SoundSystemManager Instance;

    [SerializeField] private MMFeedbacks enemyHitSFX;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void EnemyHitSFX()
    {
        enemyHitSFX?.PlayFeedbacks();
    }
}
