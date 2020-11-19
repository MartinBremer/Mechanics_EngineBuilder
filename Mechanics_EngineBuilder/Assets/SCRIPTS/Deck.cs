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

    void Start()
    {
        deckSize = cardDataArray.Length;
        ResetDeck();

        dealer.DealCards(this);
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

        counter++;

        return newCard;
    }

    void TransferCardDataToCard(CardData template, Card _newCard)
    {
        _newCard.cost = template.cost;
        _newCard.yield = template.yield;
        _newCard.tier = tier;
    }
}
