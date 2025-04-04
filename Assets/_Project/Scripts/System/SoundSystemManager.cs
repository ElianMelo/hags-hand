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

    public void EnemyHitSFX()
    {
        enemyHitSFX?.PlayFeedbacks();
    }
}
