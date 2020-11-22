using UnityEngine;
using UnityEngine.UI;

public class TierSelector : MonoBehaviour
{
    public delegate void TierSelected(int tier);
    public static TierSelected onTierSelected;

    public Player player;
    public HandUI handUI;

    public Toggle self;

    public Toggle other1;
    public Toggle other2;

    void Start()
    {
        TurnManager.onNewTurn += EnableDisableTiers;
    }

    public void EnableDisableTiers()
    {
        if (BoardManager.selectedCard != null && BoardManager.selectedCard.tier != player.activeTier)
            BoardManager.selectedCard = null;

        onTierSelected?.Invoke(player.activeTier);
    }

    public void SelectTier()
    {        
        if (player.myTurn)
        {
            self.isOn = true;

            other1.isOn = false;
            other2.isOn = false;

            player.SetActiveTier();

            EnableDisableTiers();
            handUI.ToggleTierYields();
        }
    }
}
