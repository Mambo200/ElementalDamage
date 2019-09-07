using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory Get
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Inventory>();
                if (instance == null) Debug.LogWarning("No instance of Inventory could be found!");
            }
            return instance;
        }
    }

    /// <summary>Returns a Copy of all collectable items</summary>
    public List<Item> Collectables { get => new List<Item>(m_Collectables); }
    /// <summary>Returns a Copy of all Weapons</summary>
    public List<Elements.Weapon> Weapons { get => new List<Elements.Weapon>(m_Weapons); }

    private List<Item> m_Collectables = new List<Item>();
    private List<Elements.Weapon> m_Weapons = new List<Elements.Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
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
                m_Collectables.Add(_item);
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
                m_Collectables.Remove(_item);
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
