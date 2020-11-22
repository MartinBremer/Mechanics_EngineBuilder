using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public int tier;
    public Shuffler shuffler;
    public Dealer dealer;

    public GameObject cardPrefab;
    public CardData[] cardDataArray;
    int deckSize;
    int counter;

    public List<GameObject> shuffledDeck = new List<GameObject>();

    public void InitializeDeck()
    {
        deckSize = cardDataArray.Length;
        ResetDeck();

        dealer.DealCards(this);
    }

    public void ResetDeck()
    {
        shuffledDeck = shuffler.ShuffleDeck(deckSize, this);
    }

    public GameObject CreateCard()
    {
        GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity, transform);
        newCard.name = "Card_" + counter;

        TransferCardDataToCard(cardDataArray[counter], newCard.GetComponent<Card>());

        newCard.GetComponent<Card>().SetSymbols();

        counter++;

        return newCard;
    }

    void TransferCardDataToCard(CardData template, Card _newCard)
    {
        _newCard.costBlue = template.costBlue;
        _newCard.costRed = template.costRed;
        _newCard.costRed = template.costGreen;
        _newCard.costPurple = template.costPurple;

        _newCard.yieldBlue = template.yieldBlue;
        _newCard.yieldRed = template.yieldRed;
        _newCard.yieldGreen = template.yieldGreen;
        _newCard.yieldPurple = template.yieldPurple;

        _newCard.tier = tier;

        Debug.Log($"{_newCard.name} / {cardDataArray[counter].name}: {_newCard.costBlue}, {_newCard.costRed}, {_newCard.costGreen}, {_newCard.costPurple}");
    }
}
