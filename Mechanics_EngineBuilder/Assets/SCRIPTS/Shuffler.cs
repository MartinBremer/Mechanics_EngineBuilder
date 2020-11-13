﻿using UnityEngine;
using System.Collections.Generic;

public class Shuffler : MonoBehaviour
{
    public Deck deck;
    public string seed;

    public GameObject[] ShuffleDeck(int deckSize)
    {
        List<GameObject> unshuffledCards = new List<GameObject>();

        for (int i = 0; i < deckSize; i++)
            unshuffledCards.Add(deck.CreateCard());

        GameObject[] shuffledCards = new GameObject[deckSize];

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = pseudoRandom.Next(unshuffledCards.Count);
            shuffledCards[i] = unshuffledCards[randomIndex];
            unshuffledCards.RemoveAt(randomIndex);
        }

        string printOut = $"{seed}: ";

        for (int i = 0; i < shuffledCards.Length; i++)
            printOut += $"{shuffledCards[i]}, ";

        Debug.Log(printOut);

        return shuffledCards;
    }
}
