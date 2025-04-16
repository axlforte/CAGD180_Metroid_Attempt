using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    //the player, duh
    public PlayerController PC;

    //the different colored text for when you are low on health
    public Sprite[] greenText;
    public Sprite[] yellowText;
    public Sprite[] RedText;

    //the percentage (in decimal) when the health changes colors
    public float yellowRate, redRate;

    //the images that represent the numbers
    public Image number1, number2, number3, HudBar;
    Sprite BarSprite;
    float NoteTimer = 180;
    float NoteTimerMax = 180;
    public TMP_Text Note;

    // Start is called before the first frame update
    void Start()
    {
        BarSprite = HudBar.sprite;
        ShowMessageOnscreen("Press A and D to move around");
        if (PC == null)
        {
            //this is dogshit code but the prefab is called BrazenBlonde so it should be safe to do
            PC = GameObject.Find("BrazenBlonde").GetComponent<PlayerController>();
        }
        PC.UHandler = this;
    }

    // Update is called once per frame
    void Update()
    {
        int hpValA = (((int)PC.health / 100) - 1) % 10;
        int hpValB = (((int)PC.health / 10) - 1) % 10;
        int hpValC = ((int)PC.health - 1) % 10;

        if (PC.health < 10) { 
            hpValA = 9;
            hpValB = 9;
        } else if (PC.health < 100)
        {
            hpValA = 9;
        }

        if (PC.iAmInvincible)
        {
            if (HudBar.sprite == null)
            {
                HudBar.sprite = BarSprite;
            } else
            {
                HudBar.sprite = null;
            }
        } else
        {
            HudBar.sprite = BarSprite;
        }

        if (PC.health / PC.maxHealth > yellowRate)
        {
            number1.sprite = greenText[hpValA];
            number2.sprite = greenText[hpValB];
            number3.sprite = greenText[hpValC];
        }
        else if (PC.health / PC.maxHealth > redRate)
        {
            number1.sprite = yellowText[hpValA];
            number2.sprite = yellowText[hpValB];
            number3.sprite = yellowText[hpValC];
        }
        else
        {
            number1.sprite = RedText[hpValA];
            number2.sprite = RedText[hpValB];
            number3.sprite = RedText[hpValC];
        }

        if(NoteTimer > 0)
        {
            NoteTimer--;
            if(NoteTimer < 30)
            {
                Note.rectTransform.anchoredPosition = new Vector2(NoteTimer * 7 - 135, -33.2f);
            }
        } 
    }

    public void ShowMessageOnscreen(string message)
    {
        Note.text = message;
        NoteTimer = NoteTimerMax;
        Note.rectTransform.anchoredPosition = new Vector2(69, -33.2f);
    }
}
