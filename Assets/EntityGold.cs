using System;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    public int Gold { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }
    
    public int RemoveGold(int amount)
    {
        if (amount > Gold)
        {
            amount = Gold;
        }
        Gold -= amount;
        return amount;
    }
}
