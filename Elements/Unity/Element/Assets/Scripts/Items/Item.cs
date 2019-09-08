using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Item : MonoBehaviour
{
    public string m_ItemName;
    public ItemType m_Type;
    [TextArea(1,3)]
    public string m_Description;

    /// <summary>
    /// Use this item and remove it from Inventory
    /// </summary>
    public void Use()
    {
        Effect();
        RemoveFromInventory();
    }

    /// <summary>
    /// Effect of Item
    /// </summary>
    protected abstract void Effect();

    private void OnTriggerEnter(Collider other)
    {
        Inventory.Get.AddItem(this);
        Destroy(this.gameObject);
    }

    private void RemoveFromInventory()
    {
        Inventory.Get.RemoveItem(this);
    }
}

public enum ItemType
{
    FOOD
}
