using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartPanel : MonoBehaviour
{
    public UIManager uiManager;

    public TMP_InputField inputField;
    public Button button;

    public Deck tierOne;
    public Deck tierTwo;
    public Deck tierThree;

    public HandUI p1;
    public HandUI p2;
    public HandUI p3;
    public HandUI p4;

    bool validSeed;

    void Update()
    {
        if (!StateMachine.gameStarted)
        {
            if (inputField.text.Length > 5)
            {
                validSeed = true;
                button.image.color = Color.green;
            }
            else
            {
                validSeed = false;
                button.image.color = Color.grey;
            }
        }
    }

    public void StartGame()
    {
        if (validSeed)
        {
            uiManager.SetPlayerNames();

            Shuffler.seed = inputField.text;

            tierOne.InitializeDeck();
            tierTwo.InitializeDeck();
            tierThree.InitializeDeck();

            StateMachine.gameStarted = true;
            TurnManager.NextTurn();

            p1.UpdateHandUI(true);
            p2.UpdateHandUI(true);
            p3.UpdateHandUI(true);
            p4.UpdateHandUI(true);

            gameObject.SetActive(false);
        }
    }
}
