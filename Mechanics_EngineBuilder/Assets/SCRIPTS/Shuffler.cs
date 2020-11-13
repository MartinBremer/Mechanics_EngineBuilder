using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Shuffler : MonoBehaviour
{
    public Deck deck = new Deck();
    public string seed;
    public int deckSize;

    List<Card> unshuffledCards;
    List<Card> shuffledCards;

    void Start()
    {
        unshuffledCards = new List<Card>();
        shuffledCards = new List<Card>();
    }

    public void ShuffleDeck()
    {

        for (int i = 0; i < deckSize; i++)
            unshuffledCards.Add(deck.CreateCard());

        shuffledCards.Clear();

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = pseudoRandom.Next(unshuffledCards.Count);
            shuffledCards.Add(unshuffledCards[randomIndex]);
            unshuffledCards.RemoveAt(randomIndex);
        }

        string printOut = $"{seed}: ";

        for (int i = 0; i < shuffledCards.Count; i++)
            printOut += $"{shuffledCards[i]}, ";

        Debug.Log(printOut);
    }
}
