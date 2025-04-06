using UnityEngine;
using MoreMountains.Feedbacks;

public class SoundSystemManager : MonoBehaviour
{
    public static SoundSystemManager Instance;

    [SerializeField] private MMFeedbacks enemyHitSFX;
    [SerializeField] private MMFeedbacks uIClickCard;
    [SerializeField] private MMFeedbacks cardHover;
    [SerializeField] private MMFeedbacks cardCancel;
    [SerializeField] private MMFeedbacks buyDrawCard;
    [SerializeField] private MMFeedbacks menuClick;
    [SerializeField] private MMFeedbacks upgradeLevel;
    [SerializeField] private MMFeedbacks menuSelection;
    [SerializeField] private MMFeedbacks enemyDie;

    private void Awake() { Instance = this; }

    public void EnemyHitSFX() { enemyHitSFX?.PlayFeedbacks(); }
    public void UIClickCard() { uIClickCard?.PlayFeedbacks(); }
    public void CardHover() { cardHover?.PlayFeedbacks(); }
    public void CardCancel() { cardCancel?.PlayFeedbacks(); }
    public void BuyDrawCard() { buyDrawCard?.PlayFeedbacks(); }
    public void MenuClick() { menuClick?.PlayFeedbacks(); }
    public void UpgradeLevel() { upgradeLevel?.PlayFeedbacks(); }
    public void MenuSelection() { menuSelection?.PlayFeedbacks(); }
    public void EnemyDie() { enemyDie?.PlayFeedbacks(); }
}
