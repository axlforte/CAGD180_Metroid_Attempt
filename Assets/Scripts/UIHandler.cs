using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image number1, number2, HudBar;
    Sprite BarSprite;

    // Start is called before the first frame update
    void Start()
    {
        BarSprite = HudBar.sprite;
        if (PC == null)
        {
            //this is dogshit code but the prefab is called BrazenBlonde so it should be safe to do
            PC = GameObject.Find("BrazenBlonde").GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int hpValA = (((int)PC.health / 10) - 1) % 10;
        int hpValB = ((int)PC.health - 1) % 10;

        if (PC.health < 10)
            hpValA = 9;

        if (PC.iAmInvincible)
        {
            if (HudBar.sprite == null)
            {
                HudBar.sprite = BarSprite;
            } else
            {
                HudBar.sprite = null;
            }
        }

        number1.sprite = greenText[hpValA];
        number2.sprite = greenText[hpValB];
    }
}
