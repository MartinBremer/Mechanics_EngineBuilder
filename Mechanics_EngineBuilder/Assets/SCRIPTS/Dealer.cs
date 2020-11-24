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

    public void DealCards(Deck activeDeck)
    {
        if (newGame)
            InitializeLists();

        int counter = 0;

        foreach (bool spotTaken in SelectDeckBool(activeDeck.tier))
        {
            if (!spotTaken && activeDeck.shuffledDeck.Count > 0)
            {
                activeDeck.shuffledDeck[0].transform.position = SelectDeckPosition(activeDeck.tier)[counter].position;
                SelectDeckBool(activeDeck.tier)[counter] = true;

                if (activeDeck.tier == 1)
                    counterDeck1--;
                else if (activeDeck.tier == 2)
                    counterDeck2--;
                else if (activeDeck.tier == 3)
                    counterDeck3--;

                activeDeck.shuffledDeck[0].GetComponent<Card>().boardPosition = SelectDeckPosition(activeDeck.tier)[counter];

                if (countersInitialized)
                    UpdateDeckCounters(activeDeck.tier);
                
                activeDeck.shuffledDeck.Remove(activeDeck.shuffledDeck[0]);
            }
            
            counter++;
        }

        if (!countersInitialized && activeDeck.tier == 3)
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
        counterDeck1 += tierOne.shuffledDeck.Count + cardPositionsT1.Count;
        counterDeck2 += tierTwo.shuffledDeck.Count + cardPositionsT2.Count;
        counterDeck3 += tierThree.shuffledDeck.Count + cardPositionsT3.Count;

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

    public void ReplaceCard(Card cardToReplace)
    {
        int counter = 0;

        if (cardToReplace.tier == 1)
        {
            foreach (Transform t in cardPositionsT1)
            {
                if (t == cardToReplace.boardPosition)
                    break;
                else
                    counter++;
            }

            spotTakenListT1[counter] = false;

            DealCards(tierOne);
        }
        else if (cardToReplace.tier == 2)
        {
            foreach (Transform t in cardPositionsT2)
            {
                if (t == cardToReplace.boardPosition)
                    break;
                else
                    counter++;
            }

            spotTakenListT2[counter] = false;

            DealCards(tierTwo);
        }
        else if (cardToReplace.tier == 3)
        {
            foreach (Transform t in cardPositionsT3)
            {
                if (t == cardToReplace.boardPosition)
                    break;
                else
                    counter++;
            }

            spotTakenListT3[counter] = false;

            DealCards(tierThree);
        }
    }
}
