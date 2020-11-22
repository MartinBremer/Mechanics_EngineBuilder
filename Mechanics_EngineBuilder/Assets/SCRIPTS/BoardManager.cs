﻿using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public static Card selectedCard;
    public Dealer dealer;

    public Button passTurn;
    public static bool pass;
    public static bool win;

    public Button winCondition;
    public Transform discardPile;

    public static Vector4 costs;
    public static Vector4 yields;

    public void ConfirmPurchase()
    {
        if (pass)
        {
            pass = false;

            TurnManager.NextTurn();
        }
        else if (win)
        {
            win = false;

            Debug.Log(TurnManager.activePlayer + " has a win condition!");

            TurnManager.NextTurn();
        }
        else if (BoardManager.selectedCard != null)
        {
            TurnManager.activePlayer.MakePurchase(costs, yields);

            selectedCard.transform.position = discardPile.position;
            dealer.ReplaceCard(selectedCard);
            selectedCard.boardPosition = discardPile;
            selectedCard = null;

            TurnManager.NextTurn();
        }
    }

    public void SelectPass()
    {
        if (BoardManager.selectedCard != null)
            BoardManager.selectedCard.ResetColor();

        BoardManager.selectedCard = null;

        passTurn.Select(); 

        pass = true;
    }

    public void SelectWin()
    {
        if (TurnManager.activePlayer.bTotals + 
            TurnManager.activePlayer.rTotals + 
            TurnManager.activePlayer.gTotals + 
            TurnManager.activePlayer.pTotals >= 2000)
        {
            if (BoardManager.selectedCard != null)
                BoardManager.selectedCard.ResetColor();

            BoardManager.selectedCard = null;

            winCondition.Select();

            win = true;
        }
    }
}
