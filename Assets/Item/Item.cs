using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected int _amount; 

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact(other);
        }
    }

    protected abstract void Interact(Collider other);

}
