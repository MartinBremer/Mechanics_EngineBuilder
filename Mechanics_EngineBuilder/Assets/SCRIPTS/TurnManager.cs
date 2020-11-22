using UnityEngine;

public enum Turns { P1, P2, P3, P4}
public class TurnManager : MonoBehaviour
{
    // must start at P4
    public static Turns turn = Turns.P4;

    public Player p1;
    public Player p2;
    public Player p3;
    public Player p4;

    public static Player activePlayer;

    public delegate void OnNewTurn();
    public static OnNewTurn onNewTurn;

    public UIManager uiManager;

    void Start()
    {
        activePlayer = p1;

        onNewTurn += SetActivePlayer;
    }

    public static void NextTurn()
    {
        if (turn != Turns.P4)
        {
            turn++;
            onNewTurn();
        }
        else
        {
            turn = Turns.P1;
            onNewTurn();
        }
    }

    void SetActivePlayer()
    {
        switch (turn)
        {
            default:
                break;
            case Turns.P1:
                activePlayer = p1;
                break;
            case Turns.P2:
                activePlayer = p2;
                break;
            case Turns.P3:
                activePlayer = p3;
                break;
            case Turns.P4:
                activePlayer = p4;
                break;
        }

        uiManager.SetActivePlayerIcon();
    }
}
