using UnityEngine;
using UnityEngine.UI;

public class TierSelector : MonoBehaviour
{
    public Player player;
    public HandUI handUI;

    public Toggle self;

    public Toggle other1;
    public Toggle other2;

    public void SelectTier()
    {        
        if (player.myTurn)
        {
            self.isOn = true;

            other1.isOn = false;
            other2.isOn = false;

            player.SetActiveTier();

            handUI.ToggleTierYields();
        }
    }
}
