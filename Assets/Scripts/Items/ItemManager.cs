using UnityEngine;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    
    public int coins;


    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins = 0;
        
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
    }
}
