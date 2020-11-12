using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Color color;
    public int cost;
    public int yield;

    public Card(Color _color, int _cost, int _yield)
    {
        color = _color;
        cost = _cost;
        yield = _yield;
    }
   


}
