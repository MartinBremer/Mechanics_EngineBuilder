using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Dealer : MonoBehaviour
{
    public Deck tierOne;
    public Deck tierTwo;
    public Deck tierThree;

    public TMP_Text counterDeck1Text;
    public TMP_Text counterDeck2Text;
    public TMP_Text counterDeck3Text;

    int counterDeck1;
    int counterDeck2;
    int counterDeck3;

    bool[] spotTakenListT1;
    bool[] spotTakenListT2;
    bool[] spotTakenListT3;

    public List<Transform> cardPositionsT1;
    public List<Transform> cardPositionsT2;
    public List<Transform> cardPositionsT3;

    bool newGame = true;
    bool countersInitialized;

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

                if (tier == 1)
                    counterDeck1--;
                else if (tier == 2)
                    counterDeck2--;
                else if (tier == 3)
                    counterDeck3--;

                if (countersInitialized)
                    UpdateDeckCounters(tier);
            }

            counter++;
        }

        if (!countersInitialized && tier == 3)
            InitializeCounters();
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

    void InitializeCounters()
    {
        counterDeck1 += tierOne.shuffledDeck.Length;
        counterDeck2 += tierTwo.shuffledDeck.Length;
        counterDeck3 += tierThree.shuffledDeck.Length;

        for (int i = 1; i < 4; i++)
            UpdateDeckCounters(i);

        countersInitialized = true;
    }

    void UpdateDeckCounters(int tier)
    {
        if (tier == 1)
            counterDeck1Text.text = counterDeck1.ToString();
        else if (tier == 2)
            counterDeck2Text.text = counterDeck2.ToString();
        else if (tier == 3)
            counterDeck3Text.text = counterDeck3.ToString();
    }
}
