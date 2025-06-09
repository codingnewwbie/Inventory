using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string _name;
    private int _level;
    private int _exp;
    private int _gold;
    private int _attack;
    private int _defense;
    private int _hp;
    private int _critical;
    
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Exp { get; private set; }
    public int Gold { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Hp { get; private set; }
    public int Critical { get; private set; }
    
    public void IncreaseExp(int exp)
    {
        Exp += exp;
    }
    
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
    
    
}
