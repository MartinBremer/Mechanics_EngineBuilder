﻿using UnityEngine;
using System.Collections.Generic;

public class Shuffler : MonoBehaviour
{
    public static string seed;

    public List<GameObject> ShuffleDeck(int deckSize, Deck deck)
    {
        List<GameObject> unshuffledCards = new List<GameObject>();

        for (int i = 0; i < deckSize; i++)
            unshuffledCards.Add(deck.CreateCard());

        List<GameObject> shuffledCards = new List<GameObject>();

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = pseudoRandom.Next(unshuffledCards.Count);
            shuffledCards.Add(unshuffledCards[randomIndex]);
            unshuffledCards.RemoveAt(randomIndex);
        }

        return shuffledCards;
    }
}
