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

    public int bTotals;
    public int rTotals;
    public int gTotals;
    public int pTotals;

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
        handTierOne = new Vector2[] { bOrb, rOrb, gOrb, pOrb };
        handTierTwo = new Vector2[] { bTalisman, rTalisman, gTalisman, pTalisman };
        handTierThree = new Vector2[] { bCharm, rCharm, gCharm, pCharm };

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

        CalculateTotals();
    }

    void CalculateTotals()
    {
        while (bOrb.x >= 10)
        {
            bOrb.x -= 10;
            bTalisman.x++;
        }

        while (bTalisman.x >= 10)
        {
            bTalisman.x -= 10;
            bCharm.x++;
        }

        while (rOrb.x >= 10)
        {
            rOrb.x -= 10;
            rTalisman.x++;
        }

        while (rTalisman.x >= 10)
        {
            rTalisman.x -= 10;
            rCharm.x++;
        }

        while (gOrb.x >= 10)
        {
            gOrb.x -= 10;
            gTalisman.x++;
        }

        while (gTalisman.x >= 10)
        {
            gTalisman.x -= 10;
            gCharm.x++;
        }

        while (pOrb.x >= 10)
        {
            pOrb.x -= 10;
            pTalisman.x++;
        }

        while (pTalisman.x >= 10)
        {
            pTalisman.x -= 10;
            pCharm.x++;
        }

        bTotals = Mathf.RoundToInt(bOrb.x + bTalisman.x * 10 + bCharm.x * 100);
        rTotals = Mathf.RoundToInt(rOrb.x + rTalisman.x * 10 + rCharm.x * 100);
        gTotals = Mathf.RoundToInt(gOrb.x + gTalisman.x * 10 + gCharm.x * 100);
        pTotals = Mathf.RoundToInt(pOrb.x + pTalisman.x * 10 + pCharm.x * 100);
    }

    public void MakePurchase(Vector4 costs, Vector4 yields)
    {
        MakePayment(costs);
        AddYield(yields);

        CalculateTotals();

        handUI.UpdateHandUI(true);
        handUI.UpdateHandUI(false);
    }

    void MakePayment(Vector4 costs)
    {
        Vector4 _costs = costs;

        // x = blue
        while (_costs.x >= 100)
        {
            bCharm.x--;
            _costs.x -= 100;
        }

        while (_costs.x >= 10)
        {
            if (bTalisman.x == 0)
            {
                bCharm.x--;
                bTalisman.x += 10;
            }

            bTalisman.x--;
            _costs.x -= 10;
        }

        while (_costs.x >= 1)
        {
            if (bOrb.x == 0)
            {
                bTalisman.x--;
                bOrb.x += 10;
            }

            bOrb.x--;
            _costs.x--;
        }

        // y = red
        while (_costs.y >= 100)
        {
            rCharm.x--;
            _costs.y -= 100;
        }

        while (_costs.y >= 10)
        {
            if (rTalisman.x == 0)
            {
                rCharm.x--;
                rTalisman.x += 10;
            }

            rTalisman.x--;
            _costs.y -= 10;
        }

        while (_costs.y >= 1)
        {
            if (rOrb.x == 0)
            {
                rTalisman.x--;
                rOrb.x += 10;
            }

            rOrb.x--;
            _costs.y--;
        }

        // z = green
        while (_costs.z >= 100)
        {
            gCharm.x--;
            _costs.z -= 100;
        }

        while (_costs.z >= 10)
        {
            if (gTalisman.x == 0)
            {
                gCharm.x--;
                gTalisman.x += 10;
            }

            gTalisman.x--;
            _costs.z -= 10;
        }

        while (_costs.z >= 1)
        {
            if (gOrb.x == 0)
            {
                gTalisman.x--;
                gOrb.x += 10;
            }

            gOrb.x--;
            _costs.z--;
        }

        // w = purple
        while (_costs.w >= 100)
        {
            pCharm.x--;
            _costs.w -= 100;
        }

        while (_costs.w >= 10)
        {
            if (pTalisman.x == 0)
            {
                pCharm.x--;
                pTalisman.x += 10;
            }

            pTalisman.x--;
            _costs.w -= 10;
        }

        while (_costs.w >= 1)
        {
            if (pOrb.x == 0)
            {
                pTalisman.x--;
                pOrb.x += 10;
            }

            pOrb.x--;
            _costs.w--;
        }
    }

    void AddYield(Vector4 yields)
    {
        Vector4 _yields = yields;

        // x = blue
        while (_yields.x >= 100)
        {
            bCharm.y++;
            _yields.x -= 100;
        }

        while (_yields.x >= 10)
        {
            bTalisman.y++;
            _yields.x -= 10;
        }

        while (_yields.x >= 1)
        {
            bOrb.y++;
            _yields.x--;
        }

        // y = red
        while (_yields.y >= 100)
        {
            rCharm.y++;
            _yields.y -= 100;
        }

        while (_yields.y >= 10)
        {
            rTalisman.y++;
            _yields.y -= 10;
        }

        while (_yields.y >= 1)
        {
            rOrb.y++;
            _yields.y--;
        }

        // z = green
        while (_yields.z >= 100)
        {
            gCharm.y++;
            _yields.z -= 100;
        }

        while (_yields.z >= 10)
        {
            gTalisman.y++;
            _yields.z -= 10;
        }

        while (_yields.z >= 1)
        {
            gOrb.y++;
            _yields.z--;
        }

        // w = purple
        while (_yields.w >= 100)
        {
            pCharm.y++;
            _yields.w -= 100;
        }

        while (_yields.w >= 10)
        {
            pTalisman.y++;
            _yields.w -= 10;
        }

        while (_yields.w >= 1)
        {
            pOrb.y++;
            _yields.w--;
        }
    }
}
