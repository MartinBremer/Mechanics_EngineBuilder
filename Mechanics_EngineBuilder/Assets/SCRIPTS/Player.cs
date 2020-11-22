using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Turns playerID;

    public HandUI handUI;

    public Toggle tierOneToggle;
    public Toggle tierTwoToggle;
    public Toggle tierThreeToggle;

    public bool myTurn;
    public int activeTier = 1;

    Vector2[] handTierOne;
    Vector2[] handTierTwo;
    Vector2[] handTierThree;

    // Vector2.x is resource count and Vector2.y is yield per turn
    #region Resources and Production
    public Vector2 bOrb;
    public Vector2 rOrb;
    public Vector2 gOrb;
    public Vector2 pOrb;
           
    public Vector2 bTalisman;
    public Vector2 rTalisman;
    public Vector2 gTalisman;
    public Vector2 pTalisman;
           
    public Vector2 bCharm;
    public Vector2 rCharm;
    public Vector2 gCharm;
    public Vector2 pCharm;
    #endregion

    void Start()
    {
        handTierOne = new Vector2[] { bOrb, rOrb, gOrb, pOrb};
        handTierTwo = new Vector2[] { bTalisman, rTalisman, gTalisman, pTalisman };
        handTierThree = new Vector2[] { bCharm, rCharm, gCharm, pCharm };

        TurnManager.onNewTurn += CheckNewTurn;

        handUI.UpdateHandUI(false);
    }

    void CheckNewTurn()
    {
        myTurn = TurnManager.turn == playerID ? true: false;

        if (myTurn)
            InitializeTurn();
    }

    void InitializeTurn()
    {
        HarvestPhase();
        handUI.UpdateHandUI(true);
    }

    public void SetActiveTier()
    {
        if (tierOneToggle.isOn)
            activeTier = 1;
        else if (tierTwoToggle.isOn)
            activeTier = 2;
        else if (tierThreeToggle.isOn)
            activeTier = 3;
    }

    void HarvestPhase()
    {
        int i = 0;

        if (activeTier == 1)
        {
            foreach (Vector2 item in handTierOne)
            {
                handTierOne[i].x += item.y;
                i++;
            }

            bOrb.x = handTierOne[0].x;
            rOrb.x = handTierOne[1].x;
            gOrb.x = handTierOne[2].x;
            pOrb.x = handTierOne[3].x;
        }
        else if (activeTier == 2)
        {
            foreach (Vector2 item in handTierTwo)
            {
                handTierTwo[i].x += item.y;
                i++;
            }

            bTalisman.x = handTierTwo[0].x;
            rTalisman.x = handTierTwo[1].x;
            gTalisman.x = handTierTwo[2].x;
            pTalisman.x = handTierTwo[3].x;
        }
        else if (activeTier == 3)
        {
            foreach (Vector2 item in handTierThree)
            {
                handTierThree[i].x += item.y;
                i++;
            }

            bCharm.x = handTierThree[0].x;
            rCharm.x = handTierThree[1].x;
            gCharm.x = handTierThree[2].x;
            pCharm.x = handTierThree[3].x;
        }
    }
}
