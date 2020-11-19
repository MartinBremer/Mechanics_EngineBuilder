﻿using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public InputField inputField;
    public Button button;

    public Deck tierOne;
    public Deck tierTwo;
    public Deck tierThree;

    bool validSeed;

    void Update()
    {
        if (!StateMachine.gameStarted)
        {
            if (inputField.text.Length > 5)
            {
                validSeed = true;
                button.image.color = Color.green;
            }
            else
            {
                validSeed = false;
                button.image.color = Color.grey;
            }
        }
    }

    public void StartGame()
    {
        if (validSeed)
        {
            Shuffler.seed = inputField.text;

            tierOne.InitializeDeck();
            tierTwo.InitializeDeck();
            tierThree.InitializeDeck();

            StateMachine.gameStarted = true;

            gameObject.SetActive(false);
        }
    }
}