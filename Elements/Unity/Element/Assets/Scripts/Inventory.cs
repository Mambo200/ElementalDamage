using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory Get
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventory>();
                if (instance == null) Debug.LogWarning("No instance of Inventory could be found!");
            }
            return instance;
        }
    }

    public bool ItemUsed { get; private set; }
    /// <summary>Returns a Copy of all collectable items</summary>
    public List<Item> Collectables { get => new List<Item>(m_Collectables); }
    /// <summary>Returns a Copy of all Weapons</summary>
    public List<Elements.Weapon> Weapons { get => new List<Elements.Weapon>(m_Weapons); }

    private List<Item> m_Collectables = new List<Item>();
    private List<Elements.Weapon> m_Weapons = new List<Elements.Weapon>();

    private Dictionary<string, int> itemAmount = new Dictionary<string, int>();
    public Dictionary<string, int> ItemAmount { get => new Dictionary<string, int>(itemAmount); }


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.Log("There is already an instance of Inventory. Destroy this");
            Destroy(this.gameObject);
            return;
        }

        instance = FindObjectOfType<Inventory>();
    }

    public void AddItem(Item _item)
    {
        switch (_item.m_Type)
        {
            case ItemType.FOOD:
                // Add to List
                m_Collectables.Add(_item);

                // Add to Dictionary
                if (itemAmount.ContainsKey(_item.m_ItemName)) itemAmount[_item.m_ItemName]++;
                else itemAmount.Add(_item.m_ItemName, 1);

                break;
            default:
                break;
        }
    }

    public void RemoveItem(Item _item)
    {
        switch (_item.m_Type)
        {
            case ItemType.FOOD:
                // Remove from List
                m_Collectables.Remove(_item);

                // Remove from Dictionary
                itemAmount[_item.m_ItemName]--;
                if (itemAmount[_item.m_ItemName] <= 0) itemAmount.Remove(_item.m_ItemName);
                break;
            default:
                break;
        }
    }

    public void RemoveItem(string _key)
    {
        int index = -1;

        for (int i = 0; i < m_Collectables.Count; i++)
        {
            if (m_Collectables[i].m_ItemName == _key)
            {
                index = i;
                break;
            }
        }

        if (index < 0) Debug.LogWarning("No item found to remove");
        else
        {
            m_Collectables.RemoveAt(index);
            itemAmount.Remove(_key);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetItemUsed(bool _value) => ItemUsed = _value;
}
