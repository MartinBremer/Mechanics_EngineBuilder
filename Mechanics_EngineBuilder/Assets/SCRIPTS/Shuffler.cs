using UnityEngine;
using System.Collections.Generic;

public class Shuffler : MonoBehaviour
{
    public string seed;
    public int deckSize;

    List<int> unshuffledCards;
    List<int> shuffledCards;

    void Start()
    {
        unshuffledCards = new List<int>();
        shuffledCards = new List<int>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < deckSize; i++)
                unshuffledCards.Add(i);

            shuffledCards.Clear();
            ShuffleDeck();
        }
    }

    public void ShuffleDeck()
    {
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
