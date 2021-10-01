using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Round : MonoBehaviour
{
    public List<Creature> redArmy;
    public List<Creature> blueArmy;
    public int round = 0;

    public List<Creature> creaturesPool;
    public List<Creature> currentCreatures;


    private List<Creature> baseRedArmy;
    private List<Creature> baseBlueArmy;

    private void Start()
    {
        currentCreatures = new List<Creature>();
        baseRedArmy = new List<Creature>(redArmy);
        baseBlueArmy = new List<Creature>(blueArmy);
    }

    public void PlayMoves(int moves = 1)
    {
        for (int i = 0; i < moves; i++)
        {
            if (creaturesPool.Count == 0)
            {
                InitAllCreatures();
            }
            DisplayList.Instance.ShowItem(creaturesPool[0]);
            currentCreatures.Add(creaturesPool[0]);
            creaturesPool.RemoveAt(0);
        }
    }

    private void InitAllCreatures()
    {
        round++;
        DisplayList.Instance.ShowRoundLabel(round);
        SortCreatures();
    }

    public void SkipMove(int index = 0)
    {
        currentCreatures.RemoveAt(index);
        DisplayList.Instance.DeleteItem(index);
        DisplayList.Instance.UpdateItemIndexes();
        PlayMoves();
    }

    public void KillCreature(int index = 1)
    {
        if(currentCreatures.Count == 0)
            return;
        
        round = 0;
        int moves = DisplayList.Instance.GetItemCount;
        
        redArmy.Remove(currentCreatures[index]);
        blueArmy.Remove(currentCreatures[index]);
        
        currentCreatures.Clear();
        DisplayList.Instance.ClearAll();
        InitAllCreatures();
        if(creaturesPool.Count > 0)
            PlayMoves(moves);
        else
        {
            Restart();
        }
    }

    public void Restart()
    {
        round = 0;
        DisplayList.Instance.ClearAll();
        creaturesPool.Clear();
        ResetArmies();
    }

    private void SortCreatures()
    {
        creaturesPool = new List<Creature>();
        UniteList();
        SortList();
    }

    private void SortList()
    {
        creaturesPool = new List<Creature>(creaturesPool.OrderByDescending(x => x.initiative)
            .ThenByDescending(x => x.speed)
            .ToList());
    }

    private void UniteList()
    {
        if (round % 2 == 1) 
            creaturesPool = new List<Creature>(redArmy.Concat(blueArmy));
        else 
            creaturesPool = new List<Creature>(blueArmy.Concat(redArmy));
    }

    public void ResetArmies()
    {
        redArmy = new List<Creature>(baseRedArmy);
        blueArmy = new List<Creature>(baseBlueArmy);
    }
}
