using UnityEngine;

public class Deck : MonoBehaviour
{
    public Shuffler shuffler;

    public GameObject cardPrefab;
    public CardData[] cardDataArray;
    int deckSize;
    int counter;

    public GameObject[] shuffledDeck;

    void Start()
    {
        deckSize = cardDataArray.Length;
        shuffledDeck = shuffler.ShuffleDeck(deckSize);
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
    }
}
