using UnityEngine;
using UnityEngine.UI;

public class WaveCornerController : MonoBehaviour
{
    public Image waveImage;
    public float health;

    private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        maxHealth = health;
        currentHealth = 0;
    }

    public void ReceiveDamage(float damage)
    {
        currentHealth += damage;
        UpdateImage();
    }

    private void UpdateImage()
    {
        waveImage.fillAmount = currentHealth / maxHealth;
    }
}
