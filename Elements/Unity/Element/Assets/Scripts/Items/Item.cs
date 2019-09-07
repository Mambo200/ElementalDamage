using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnMouseDown()
    {
        Ray ray = MyCamBattle.GetCurrent.m_BattleCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            Debug.Log(info.collider.gameObject.name, info.collider.gameObject);
            if (info.collider.gameObject.tag == "EatAble")
            {
                // Food was clicked
                string text = info.collider.gameObject.GetComponent<TMPro.TMP_Text>().text;
                string[] split = text.Split('-');
            }
        }
        else
        {
            Debug.Log(info.collider.gameObject.name, info.collider.gameObject);
        }
    }

}

public enum ItemType
{
    FOOD
}
