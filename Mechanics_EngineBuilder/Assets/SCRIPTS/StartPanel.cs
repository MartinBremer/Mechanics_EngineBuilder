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

            gameObject.SetActive(false);
        }
    }
}
