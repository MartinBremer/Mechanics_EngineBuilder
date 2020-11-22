using UnityEngine;

public enum Turns { P1, P2, P3, P4}
public class TurnManager : MonoBehaviour
{
    // must start at P4
    public static Turns turn = Turns.P4;

    public delegate void OnNewTurn();
    public static OnNewTurn onNewTurn;

    public static void NextTurn()
    {
        if (turn != Turns.P4)
            turn++;
        else
        {
            turn = Turns.P1;
            onNewTurn();
        }
    }
}
