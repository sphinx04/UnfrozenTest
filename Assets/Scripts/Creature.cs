using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class Creature
{
    public enum Army
    {
        Red,
        Blue
    }
    public Army army;
    public int cell;
    public string name;
    public int initiative;
    public int speed;
}
