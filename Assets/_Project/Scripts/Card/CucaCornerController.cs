using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CucaCornerController : MonoBehaviour
{
    [Header("Rarity")]
    public TMP_Text commomText;
    public TMP_Text uncommomText;
    public TMP_Text rareText;
    public TMP_Text epicText;
    public TMP_Text legendaryText;

    [Header("Level")]
    public TMP_Text levelText;
    public Image experienceBar;

    private int commomPercentage = 100;
    private int uncommomPercentage = 0;
    private int rarePercentage = 0;
    private int epicPercentage = 0;
    private int legendaryPercentage = 0;

    private int currentLevel = 1;
    private int currentExperience = 0;
    private int maxExperience = 20;

    private void LevelUp()
    {
        currentLevel++;
        if(currentLevel == 10)
        {
            currentExperience = maxExperience;
            UpdateExperience();
        }
        ChangeRarityPercentage();
        UpdateRarityText();
        levelText.text = "LV " + currentLevel.ToString();
    }

    public void AddExperience(int amount)
    {
        if (currentLevel == 10) return;
        if(currentExperience + amount >= maxExperience)
        {
            currentExperience = 0;
            LevelUp();
        } else
        {
            currentExperience += amount;
        }
        UpdateExperience();
    }

    private void UpdateExperience()
    {
        experienceBar.fillAmount = (float) currentExperience / maxExperience;
    }

    private void UpdateRarityText()
    {
        commomText.text = commomPercentage + "%";
        uncommomText.text = uncommomPercentage + "%";
        rareText.text = rarePercentage + "%";
        epicText.text = epicPercentage + "%";
        legendaryText.text = legendaryPercentage + "%";
    }

    public Rarity CalculateCurrentPercentage()
    {
        int randomValue = Random.Range(0, 100) + 1;
        int currentValue = 1;
        if(randomValue >= currentValue && randomValue < currentValue + commomPercentage)
        {
            return Rarity.Common;
        }
        currentValue += commomPercentage;
        if (randomValue >= currentValue && randomValue < currentValue + uncommomPercentage)
        {
            return Rarity.Uncommon;
        }
        currentValue += uncommomPercentage;
        if (randomValue >= currentValue && randomValue < currentValue + rarePercentage)
        {
            return Rarity.Rare;
        }
        currentValue += rarePercentage;
        if (randomValue >= currentValue && randomValue < currentValue + epicPercentage)
        {
            return Rarity.Epic;
        }
        currentValue += epicPercentage;
        if (randomValue >= currentValue && randomValue < currentValue + legendaryPercentage)
        {
            return Rarity.Legendary;
        }
        return Rarity.Common;
    }

    private void ChangeRarityPercentage()
    {
        switch (currentLevel)
        {
            case 1:
                commomPercentage = 100;
                uncommomPercentage = 0;
                rarePercentage = 0;
                epicPercentage = 0;
                legendaryPercentage = 0;
                break;
            case 2:
                commomPercentage = 100;
                uncommomPercentage = 0;
                rarePercentage = 0;
                epicPercentage = 0;
                legendaryPercentage = 0;
                break;
            case 3:
                commomPercentage = 75;
                uncommomPercentage = 25;
                rarePercentage = 0;
                epicPercentage = 0;
                legendaryPercentage = 0;
                break;
            case 4:
                commomPercentage = 55;
                uncommomPercentage = 30;
                rarePercentage = 15;
                epicPercentage = 0;
                legendaryPercentage = 0;
                break;
            case 5:
                commomPercentage = 45;
                uncommomPercentage = 33;
                rarePercentage = 20;
                epicPercentage = 2;
                legendaryPercentage = 0;
                break;
            case 6:
                commomPercentage = 30;
                uncommomPercentage = 40;
                rarePercentage = 25;
                epicPercentage = 5;
                legendaryPercentage = 0;
                break;
            case 7:
                commomPercentage = 19;
                uncommomPercentage = 30;
                rarePercentage = 40;
                epicPercentage = 10;
                legendaryPercentage = 1;
                break;
            case 8:
                commomPercentage = 17;
                uncommomPercentage = 24;
                rarePercentage = 32;
                epicPercentage = 24;
                legendaryPercentage = 3;
                break;
            case 9:
                commomPercentage = 15;
                uncommomPercentage = 18;
                rarePercentage = 25;
                epicPercentage = 30;
                legendaryPercentage = 12;
                break;
            case 10:
                commomPercentage = 5;
                uncommomPercentage = 10;
                rarePercentage = 20;
                epicPercentage = 40;
                legendaryPercentage = 25;
                break;
            default:
                break;
        }
    }
}
