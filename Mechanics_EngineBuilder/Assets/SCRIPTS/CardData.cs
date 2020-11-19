using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardData : ScriptableObject
{
    public int costBlue;
    public int costRed;
    public int costGreen;
    public int costPurple;
    
    public int yieldBlue;
    public int yieldRed;
    public int yieldGreen;
    public int yieldPurple;
}
