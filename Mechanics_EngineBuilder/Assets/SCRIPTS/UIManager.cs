using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField playerNameInput1;
    public TMP_InputField playerNameInput2;
    public TMP_InputField playerNameInput3;
    public TMP_InputField playerNameInput4;

    public TMP_Text playerName1;
    public TMP_Text playerName2;
    public TMP_Text playerName3;
    public TMP_Text playerName4;

    public void SetPlayerNames()
    {
        playerName1.text = playerNameInput1.text != ""? "P1 " + playerNameInput1.text : "P1";
        playerName2.text = playerNameInput2.text != ""? "P2 " + playerNameInput2.text : "P2";
        playerName3.text = playerNameInput3.text != ""? "P3 " + playerNameInput3.text : "P3";
        playerName4.text = playerNameInput4.text != ""? "P4 " + playerNameInput4.text : "P4";
    }
}
