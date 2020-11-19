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

    bool newGame = true;

    public void DealCards(Deck activeDeck, int tier)
    {
        if (newGame)
            InitializeLists();

        int counter = 0;

        foreach (bool spotTaken in SelectDeckBool(tier))
        {
            if (!spotTaken && activeDeck.shuffledDeck.Length > 0)
            {
                activeDeck.shuffledDeck[counter].transform.position = SelectDeckPosition(tier)[counter].position;

                SelectDeckBool(tier)[counter] = true;
            }

            counter++;
        }
    }

    bool[] SelectDeckBool(int tier)
    {
        if (tier == 1)
            return spotTakenListT1;
        else if (tier == 2)
            return spotTakenListT2;
        else if (tier == 3)
            return spotTakenListT3;
        else
            return null;
    }

    List<Transform> SelectDeckPosition(int tier)
    {
        if (tier == 1)
            return cardPositionsT1;
        else if (tier == 2)
            return cardPositionsT2;
        else if (tier == 3)
            return cardPositionsT3;
        else
            return null;
    }

    void InitializeLists()
    {
        spotTakenListT1 = new bool[cardPositionsT1.Count];
        spotTakenListT2 = new bool[cardPositionsT2.Count];
        spotTakenListT3 = new bool[cardPositionsT3.Count];

        newGame = false;
    }
}
