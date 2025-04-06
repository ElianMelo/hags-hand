using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveCornerController : MonoBehaviour
{
    public Image waveImage;
    public float health;
    public TMP_Text waveCountText;

    private float maxHealth;
    private float currentHealth;
    private int waveCount = 1;
    private float currentPercentage;

    private void Start()
    {
        maxHealth = health;
        currentHealth = 0;
    }

    public void ReceiveDamage(float damage)
    {
        currentHealth += damage;
        SoundSystemManager.Instance.PlayerHurt();
        UpdateImage();
    }

    private void UpdateImage()
    {
        currentPercentage = currentHealth / maxHealth;
        if(currentPercentage >= 1)
        {
            LevelSystemManager.Instance.GoToLose();
        }
        InterfaceSystemManager.Instance.SetCurrentWavePercentage(currentPercentage);
        waveImage.fillAmount = currentHealth / maxHealth;
    }

    public void AddWaveCount()
    {
        waveCount++;
        UpdateWaveCont();
    }

    private void UpdateWaveCont()
    {
        waveCountText.text = "Wave " + waveCount;
    }
}
