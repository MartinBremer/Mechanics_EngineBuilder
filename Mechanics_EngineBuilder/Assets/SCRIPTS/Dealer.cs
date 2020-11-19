using UnityEngine;
using System.Collections.Generic;

public class Dealer : MonoBehaviour
{
    public Deck tierOne;
    public Deck tierTwo;
    public Deck tierThree;

    bool[] spotTakenListT1;
    bool[] spotTakenListT2;
    bool[] spotTakenListT3;

    public List<Transform> cardPositionsT1;
    public List<Transform> cardPositionsT2;
    public List<Transform> cardPositionsT3;

    void Start()
    {
        spotTakenListT1 = new bool[cardPositionsT1.Count];
        spotTakenListT2 = new bool[cardPositionsT2.Count];
        spotTakenListT3 = new bool[cardPositionsT3.Count];
    }

    public void DealCards(Deck activeDeck)
    {
        bool[] activeDeckBools = SelectDeckBool(activeDeck);
        List<Transform> activeDeckPositions = SelectDeckPosition(activeDeck);

        int counter = 0;

        foreach (bool spotTaken in activeDeckBools)
        {
            if (!spotTaken) // && deck not empty
            {
                activeDeck.shuffledDeck[counter].transform.position = activeDeckPositions[counter].position;
                SelectDeckBool(activeDeck)[counter] = true;
            }

            counter++;
        }
    }

    bool[] SelectDeckBool(Deck activeDeck)
    {
        if (activeDeck == tierOne)
            return spotTakenListT1;
        else if (activeDeck == tierTwo)
            return spotTakenListT2;
        else
            return spotTakenListT3;
    }

    List<Transform> SelectDeckPosition(Deck activeDeck)
    {
        if (activeDeck == tierOne)
            return cardPositionsT1;
        else if (activeDeck == tierTwo)
            return cardPositionsT2;
        else
            return cardPositionsT3;
    }
}
