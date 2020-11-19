using UnityEngine;

public class Deck : MonoBehaviour
{
    public int tier;
    public Shuffler shuffler;
    public Dealer dealer;

    public GameObject cardPrefab;
    public CardData[] cardDataArray;
    int deckSize;
    int counter;

    public GameObject[] shuffledDeck;

    public void InitializeDeck()
    {
        deckSize = cardDataArray.Length;
        ResetDeck();

        dealer.DealCards(this, tier);
    }

    public void ResetDeck()
    {
        // not sure this properly resets everything yet. But it works on start
        shuffledDeck = shuffler.ShuffleDeck(deckSize, this);
    }

    public GameObject CreateCard()
    {
        GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity, transform);
        newCard.name = "Card" + counter;

        Card newCardStats = newCard.GetComponent<Card>();
        TransferCardDataToCard(cardDataArray[counter], newCardStats);

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
    }
}
