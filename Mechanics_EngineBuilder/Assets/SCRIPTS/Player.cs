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

    public GameObject winConditionGraphic;

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
        while (bOrb.x >= 5)
        {
            bOrb.x -= 5;
            bTalisman.x++;
        }

        while (bTalisman.x >= 5)
        {
            bTalisman.x -= 5;
            bCharm.x++;
        }

        while (rOrb.x >= 5)
        {
            rOrb.x -= 5;
            rTalisman.x++;
        }

        while (rTalisman.x >= 5)
        {
            rTalisman.x -= 5;
            rCharm.x++;
        }

        while (gOrb.x >= 5)
        {
            gOrb.x -= 5;
            gTalisman.x++;
        }

        while (gTalisman.x >= 5)
        {
            gTalisman.x -= 5;
            gCharm.x++;
        }

        while (pOrb.x >= 5)
        {
            pOrb.x -= 5;
            pTalisman.x++;
        }

        while (pTalisman.x >= 5)
        {
            pTalisman.x -= 5;
            pCharm.x++;
        }

        bTotals = Mathf.RoundToInt(bOrb.x + bTalisman.x * 5 + bCharm.x * 25);
        rTotals = Mathf.RoundToInt(rOrb.x + rTalisman.x * 5 + rCharm.x * 25);
        gTotals = Mathf.RoundToInt(gOrb.x + gTalisman.x * 5 + gCharm.x * 25);
        pTotals = Mathf.RoundToInt(pOrb.x + pTalisman.x * 5 + pCharm.x * 25);
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
        while (_costs.x >= 25)
        {
            bCharm.x--;
            _costs.x -= 25;
        }

        while (_costs.x >= 5)
        {
            if (bTalisman.x == 0)
            {
                bCharm.x--;
                bTalisman.x += 5;
            }

            bTalisman.x--;
            _costs.x -= 5;
        }

        while (_costs.x >= 1)
        {
            if (bOrb.x == 0)
            {
                bTalisman.x--;
                bOrb.x += 5;
            }

            bOrb.x--;
            _costs.x--;
        }

        // y = red
        while (_costs.y >= 25)
        {
            rCharm.x--;
            _costs.y -= 100;
        }

        while (_costs.y >= 5)
        {
            if (rTalisman.x == 0)
            {
                rCharm.x--;
                rTalisman.x += 5;
            }

            rTalisman.x--;
            _costs.y -= 5;
        }

        while (_costs.y >= 1)
        {
            if (rOrb.x == 0)
            {
                rTalisman.x--;
                rOrb.x += 5;
            }

            rOrb.x--;
            _costs.y--;
        }

        // z = green
        while (_costs.z >= 25)
        {
            gCharm.x--;
            _costs.z -= 100;
        }

        while (_costs.z >= 5)
        {
            if (gTalisman.x == 0)
            {
                gCharm.x--;
                gTalisman.x += 5;
            }

            gTalisman.x--;
            _costs.z -= 5;
        }

        while (_costs.z >= 1)
        {
            if (gOrb.x == 0)
            {
                gTalisman.x--;
                gOrb.x += 5;
            }

            gOrb.x--;
            _costs.z--;
        }

        // w = purple
        while (_costs.w >= 25)
        {
            pCharm.x--;
            _costs.w -= 100;
        }

        while (_costs.w >= 5)
        {
            if (pTalisman.x == 0)
            {
                pCharm.x--;
                pTalisman.x += 5;
            }

            pTalisman.x--;
            _costs.w -= 5;
        }

        while (_costs.w >= 1)
        {
            if (pOrb.x == 0)
            {
                pTalisman.x--;
                pOrb.x += 5;
            }

            pOrb.x--;
            _costs.w--;
        }
    }

    void AddYield(Vector4 yields)
    {
        Vector4 _yields = yields;

        // x = blue
        while (_yields.x >= 25)
        {
            bCharm.y++;
            _yields.x -= 25;
        }

        while (_yields.x >= 5)
        {
            bTalisman.y++;
            _yields.x -= 5;
        }

        while (_yields.x >= 1)
        {
            bOrb.y++;
            _yields.x--;
        }

        // y = red
        while (_yields.y >= 25)
        {
            rCharm.y++;
            _yields.y -= 25;
        }

        while (_yields.y >= 5)
        {
            rTalisman.y++;
            _yields.y -= 5;
        }

        while (_yields.y >= 1)
        {
            rOrb.y++;
            _yields.y--;
        }

        // z = green
        while (_yields.z >= 25)
        {
            gCharm.y++;
            _yields.z -= 25;
        }

        while (_yields.z >= 5)
        {
            gTalisman.y++;
            _yields.z -= 5;
        }

        while (_yields.z >= 1)
        {
            gOrb.y++;
            _yields.z--;
        }

        // w = purple
        while (_yields.w >= 25)
        {
            pCharm.y++;
            _yields.w -= 25;
        }

        while (_yields.w >= 5)
        {
            pTalisman.y++;
            _yields.w -= 5;
        }

        while (_yields.w >= 1)
        {
            pOrb.y++;
            _yields.w--;
        }
    }
}
