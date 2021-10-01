using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _index;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _characteristics;
    [SerializeField] private Image background;
    
    [SerializeField] private Color[] colors;

    public void SetData(int index, string creatureName, int initiative, int speed, Creature.Army army)
    {
        _index.text = index.ToString();
        _name.text = $"Существо {creatureName}:";
        _characteristics.text = $"Инициатива - {initiative} Скорость - {speed}";
        if (army == Creature.Army.Red)
        {
            background.color = colors[0];
        }
        else
        {
            background.color = colors[1];
        }
    }

    public void UpdateIndex(int index)
    {
        _index.text = index.ToString();
    }

    public void SetRoundLabel(int round)
    {
        _name.text = $"Раунд №{round}";
    }
}
