using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image self;
    public Button button;

    public Transform boardPosition;

    public Sprite blue;
    public Sprite red;
    public Sprite green;
    public Sprite purple;
    
    public int tier;

    public int costBlue;
    public int costRed;
    public int costGreen;
    public int costPurple;

    public int yieldBlue;
    public int yieldRed;
    public int yieldGreen;
    public int yieldPurple;

    public Image[] costPos;
    public Image[] yieldPos;

    int counterCost;
    int counterYield;

    void Start()
    {
        TierSelector.onTierSelected += EnableCard;

        EnableCard(1);
    }

    public void SetSymbols()
    {
        counterCost = 0;
        counterYield = 0;

        for (int i = 0; i < costBlue; i++)
            AddSymbol(0, true);

        for (int i = 0; i < costRed; i++)
            AddSymbol(1, true);

        for (int i = 0; i < costGreen; i++)
            AddSymbol(2, true);

        for (int i = 0; i < costPurple; i++)
            AddSymbol(3, true);

        for (int i = 0; i < yieldBlue; i++)
            AddSymbol(0, false);

        for (int i = 0; i < yieldRed; i++)
            AddSymbol(1, false);

        for (int i = 0; i < yieldGreen; i++)
            AddSymbol(2, false);

        for (int i = 0; i < yieldPurple; i++)
            AddSymbol(3, false);
    }

    // symbol color table: 0 Blue // 1 Red // 2 Green // 3 Purple
    void AddSymbol(int symbolColor, bool isCost)
    {
        Sprite symbol;

        if (symbolColor == 0)
            symbol = blue;
        else if (symbolColor == 1)
            symbol = red;
        else if (symbolColor == 2)
            symbol = green;
        else
            symbol = purple;

        if (isCost)
        {
            costPos[counterCost].sprite = symbol;
            costPos[counterCost].color = new Color(1,1,1,1);

            counterCost++;
        }
        else
        {
            yieldPos[counterYield].sprite = symbol;
            yieldPos[counterYield].color = new Color(1, 1, 1, 1);

            counterYield++;
        }
    }

    public void EnableCard(int _tier)
    {
        if (_tier == tier)
        {
            button.enabled = true;
            self.color = Color.white;
        }
        else
        {
            button.enabled = false;
            self.color = Color.grey;
        }
    }

    public void SelectCard()
    {
        if (CheckResources())
        {
            BoardManager.pass = false;
            BoardManager.win = false;

            SetCostsAndYields();

            if (BoardManager.selectedCard != null)
                BoardManager.selectedCard.ResetColor();

            BoardManager.selectedCard = this;

            self.color = Color.green;
        }
    }

    bool CheckResources()
    {
        int multiplier = tier == 3 ? 100 : tier == 2 ? 10 : 1;
        Player active = TurnManager.activePlayer;

        if (active.bTotals >= costBlue * multiplier &&
            active.bTotals >= costBlue * multiplier &&
            active.bTotals >= costBlue * multiplier &&
            active.bTotals >= costBlue * multiplier
            )
        {
            return true;
        }
        else
            return false;
    }

    void SetCostsAndYields()
    {
        int multiplier = tier == 3 ? 100 : tier == 2 ? 10 : 1;

        BoardManager.costs = new Vector4(costBlue, costRed, costGreen, costPurple) * multiplier;
        BoardManager.yields = new Vector4(yieldBlue, yieldRed, yieldGreen, yieldPurple) * multiplier;
    }

    public void ResetColor()
    {
        self.color = Color.white;
    }
}
