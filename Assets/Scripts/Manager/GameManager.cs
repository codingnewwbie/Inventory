using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Character player;
    public ItemData itemData;

    protected override void Awake()
    {
        base.Awake();
        
        player = FindObjectOfType<Character>();
        SetData();
    }


    private void SetData()
    {
        player.SetName("Chad");
        player.SetRank("Giga");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
