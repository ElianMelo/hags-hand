using System.Collections;
using UnityEngine;

public class InterfaceSystemManager : MonoBehaviour
{
    public static InterfaceSystemManager Instance;

    private StoreCornerController storeCornerController;
    private CucaCornerController cucaCornerController;
    private WaveCornerController waveCornerController;
    private PlayerVirtualHand playerVirtualHand;

    private void Awake()
    {
        Instance = this;
        storeCornerController = GetComponentInChildren<StoreCornerController>();
        cucaCornerController = GetComponentInChildren<CucaCornerController>();
        waveCornerController = GetComponentInChildren<WaveCornerController>();
        playerVirtualHand = FindFirstObjectByType<PlayerVirtualHand>();
    }

    public void WaveDamage(float damage)
    {
        waveCornerController.ReceiveDamage(damage);
    }

    public void AddWaveCount()
    {
        waveCornerController.AddWaveCount();
    }

    public void AddCoin(int amount)
    {
        storeCornerController.AddCoin(amount);
    }

    public void AddExperience(int amount)
    {
        cucaCornerController.AddExperience(amount);
    }

    public Rarity GetCardRarity()
    {
        return cucaCornerController.CalculateCurrentPercentage();
    }

    public void SetCucaReaction(CucaReaction reaction)
    {
        cucaCornerController.SetCucaReaction(reaction);
    }

    public void SetMouseReaction(MouseReaction mouseReation)
    {
        CursorSystemManager.Instance.SetMouseReaction(mouseReation);
    }

    public void SetMouseReactionDelayed(MouseReaction mouseReation, float time)
    {
        StartCoroutine(SetMouseReactionDelayedCoroutine(mouseReation, time));
    }

    private IEnumerator SetMouseReactionDelayedCoroutine(MouseReaction mouseReation, float time)
    {
        yield return new WaitForSeconds(time);
        SetMouseReaction(mouseReation);
    }

    public void ConsumeCard()
    {
        storeCornerController.ConsumeCard();
    }
}
