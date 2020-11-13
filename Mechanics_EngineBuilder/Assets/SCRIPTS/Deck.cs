using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Shuffler shuffler = new Shuffler();
    public GameObject cardPrefab;
    int counter;

    void Start()
    {
        shuffler.ShuffleDeck();
    }

    
    public Card CreateCard()
    {
        GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity, transform);
        newCard.name = "Card" + counter;
        counter++;

        newCard.AddComponent<Card>(); 
        return newCard;
    }


}
