using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayList : MonoBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject roundLabel;

    private List<GameObject> items;

    public static DisplayList Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        items = new List<GameObject>();
    }

    public void ShowItem(Creature creature)
    {
        GameObject go = Instantiate(item, holder);
        items.Add(go);
        go.GetComponent<ItemDisplay>()
            .SetData(items.Count, creature.name, creature.initiative, creature.speed, creature.army);
    }

    public void ShowRoundLabel(int round)
    {
        GameObject go = Instantiate(roundLabel, holder);
        go.GetComponent<ItemDisplay>().SetRoundLabel(round);
    }

    public void DeleteItem(int index)
    {
        if(items.Count == 0)
            return;
        Destroy(items[index]);
        items.RemoveAt(index);
    }
    public void UpdateItemIndexes()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].GetComponent<ItemDisplay>().UpdateIndex(i + 1);
        }
    }

    public int GetItemCount => items.Count;

    public void ClearAll()
    {
        for (int i = 0; i < holder.childCount; i++)
        {
            Destroy(holder.GetChild(i).gameObject);
        }
        items.Clear();
    }
}
