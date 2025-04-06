using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public List<Sprite> tutorials = new();
    public Image tutorialImage;

    private int currentTutorialIndex = 0; 

    public void NextTutorial()
    {
        if(currentTutorialIndex + 1 == tutorials.Count)
        {
            currentTutorialIndex = 0;
        } else
        {
            currentTutorialIndex++;
        }
        UpdateCurrentSprite();
    }

    public void PreviousTutorial()
    {
        if(currentTutorialIndex - 1 == -1)
        {
            currentTutorialIndex = tutorials.Count - 1;
        } else
        {
            currentTutorialIndex--;
        }
        UpdateCurrentSprite();
    }

    private void UpdateCurrentSprite()
    {
        tutorialImage.sprite = tutorials[currentTutorialIndex];
    }
}
