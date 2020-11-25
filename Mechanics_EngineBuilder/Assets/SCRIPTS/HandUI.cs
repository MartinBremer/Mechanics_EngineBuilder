using UnityEngine;
using TMPro;

public class HandUI : MonoBehaviour
{
    public Player player;

    public GameObject tierOneYield;
    public GameObject tierTwoYield;
    public GameObject tierThreeYield;

    public TMP_Text bOrb;
    public TMP_Text rOrb;
    public TMP_Text gOrb;
    public TMP_Text pOrb;
    
    public TMP_Text bTalisman;
    public TMP_Text rTalisman;
    public TMP_Text gTalisman;
    public TMP_Text pTalisman;

    public TMP_Text bCharm;
    public TMP_Text rCharm;
    public TMP_Text gCharm;
    public TMP_Text pCharm;

    public TMP_Text bTotals;
    public TMP_Text rTotals;
    public TMP_Text gTotals;
    public TMP_Text pTotals;

    public TMP_Text bOrbYield;
    public TMP_Text rOrbYield;
    public TMP_Text gOrbYield;
    public TMP_Text pOrbYield;

    public TMP_Text bTalismanYield;
    public TMP_Text rTalismanYield;
    public TMP_Text gTalismanYield;
    public TMP_Text pTalismanYield;

    public TMP_Text bCharmYield;
    public TMP_Text rCharmYield;
    public TMP_Text gCharmYield;
    public TMP_Text pCharmYield;

    public void UpdateHandUI(bool resources)
    {
        if (resources)
        {
            bOrb.text = player.bOrb.x.ToString();
            rOrb.text = player.rOrb.x.ToString();
            gOrb.text = player.gOrb.x.ToString();
            pOrb.text = player.pOrb.x.ToString();

            bTalisman.text = player.bTalisman.x.ToString();
            rTalisman.text = player.rTalisman.x.ToString();
            gTalisman.text = player.gTalisman.x.ToString();
            pTalisman.text = player.pTalisman.x.ToString();

            bCharm.text = player.bCharm.x.ToString();
            rCharm.text = player.rCharm.x.ToString();
            gCharm.text = player.gCharm.x.ToString();
            pCharm.text = player.pCharm.x.ToString();

            bTotals.text = (player.bOrb.x + player.bTalisman.x * 5 + player.bCharm.x * 25).ToString();
            rTotals.text = (player.rOrb.x + player.rTalisman.x * 5 + player.rCharm.x * 25).ToString();
            gTotals.text = (player.gOrb.x + player.gTalisman.x * 5 + player.gCharm.x * 25).ToString();
            pTotals.text = (player.pOrb.x + player.pTalisman.x * 5 + player.pCharm.x * 25).ToString();
        }
        else
        {
            bOrbYield.text = player.bOrb.y.ToString();
            rOrbYield.text = player.rOrb.y.ToString();
            gOrbYield.text = player.gOrb.y.ToString();
            pOrbYield.text = player.pOrb.y.ToString();

            bTalismanYield.text = player.bTalisman.y.ToString();
            rTalismanYield.text = player.rTalisman.y.ToString();
            gTalismanYield.text = player.gTalisman.y.ToString();
            pTalismanYield.text = player.pTalisman.y.ToString();

            bCharmYield.text = player.bCharm.y.ToString();
            rCharmYield.text = player.rCharm.y.ToString();
            gCharmYield.text = player.gCharm.y.ToString();
            pCharmYield.text = player.pCharm.y.ToString();
        }
    }

    public void ToggleTierYields()
    {
        bool tierOne = player.activeTier == 1;
        bool tierTwo = player.activeTier == 2;
        bool tierThree = player.activeTier == 3;

        tierOneYield.SetActive(tierOne);
        tierTwoYield.SetActive(tierTwo);
        tierThreeYield.SetActive(tierThree);
    }
}
