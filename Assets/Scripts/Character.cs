using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string _name;
    private string _rank;
    private int _level;
    private int _exp;
    private int _maxExp;
    private int _gold;
    private int _attack;
    private int _defense;
    private int _hp;
    private int _critical;
    
    public string Name { get; private set; }
    public string Rank { get; private set; }
    public int Level { get; private set; }
    public int MaxExp { get; private set; }
    public int Exp { get; private set; }
    public int Gold { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Hp { get; private set; }
    public int Critical { get; private set; }
    
    public void IncreaseGold(int gold)
    {
        Gold += gold;
    }

    public void IncreaseAttack(int attack)
    {
        Attack += attack;
    }
    
    public void IncreaseDefense(int defense)
    {
        Defense += defense;
    }
    
    public void IncreaseHp(int hp)
    {
        Hp += hp;
    }
    public void IncreaseCritical(int critical)
    {
        Critical += critical;
    }
    public void DecreaseHp(int hp)
    {
        Hp -= hp;
    }
    public void DecreaseCritical(int critical)
    {
        Critical -= critical;
    }

    public void DecreaseAttack(int attack)
    {
        Attack -= attack;
    }
    
    public void DecreaseDefense(int defense)
    {
        Defense -= defense;
    }

    public void DecreaseGold(int gold)
    {
        Gold -= gold;
    }
    
    public void IncreaseExp(int exp)
    {
        Exp += exp;

        if (Exp >= MaxExp) LevelUp();
    }
    
    private void LevelUp()
    {
        Level++;
        Exp -= MaxExp;
        MaxExp = (Level * 1) + 2;
    }

    private void Awake()
    {
        Level = 1;
        Exp = 0;
        Gold = 100000;
        MaxExp = (Level * 1) + 2;
        Attack = 10;
        Defense = 10;
        Hp = 100;
        Critical = 10;
    }
    
    public void SetName(string name)
    {
        Name = name;
    }
    
    public void SetRank(string rank)
    {
        Rank = rank;
    }
}
