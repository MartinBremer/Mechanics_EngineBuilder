using UnityEngine;
using UnityEngine.EventSystems;
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

            TurnManager.activePlayer.winConditionGraphic.SetActive(true);

            TurnManager.NextTurn();
        }
        else if (selectedCard != null)
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
        if (selectedCard != null)
            selectedCard.ResetColor();

        selectedCard = null;

        passTurn.Select(); 

        pass = true;
    }

    public void SelectWin()
    {
        if (TurnManager.activePlayer.bTotals + 
            TurnManager.activePlayer.rTotals + 
            TurnManager.activePlayer.gTotals + 
            TurnManager.activePlayer.pTotals >= 200)
        {
            if (selectedCard != null)
                selectedCard.ResetColor();

            selectedCard = null;

            winCondition.Select();

            win = true;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
