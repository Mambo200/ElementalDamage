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

    /// <summary>Returns a Copy of all collectable items</summary>
    public List<Item> Collectables { get => new List<Item>(m_Collectables); }
    /// <summary>Returns a Copy of all Weapons</summary>
    public List<Elements.Weapon> Weapons { get => new List<Elements.Weapon>(m_Weapons); }

    private List<Item> m_Collectables = new List<Item>();
    private List<Elements.Weapon> m_Weapons = new List<Elements.Weapon>();

    private Dictionary<string, int> itemAmount = new Dictionary<string, int>();

    #region UI
    [SerializeField] private GraphicRaycaster raycaster;
    #endregion

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
        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Set up the new Pointer Event
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                pointerData.position = Input.mousePosition;
                this.raycaster.Raycast(pointerData, results);

                // go through every Item and check if Food was clicked
                foreach (RaycastResult res in results)
                {
                    // If UI Element does not has the tag EatAble continue
                    if (res.gameObject.tag != "EatAble") continue;

                    Item toUse = null;
                    bool gotItem = false;
                    int amount = -1;
                    TMPro.TMP_Text textBox = res.gameObject.GetComponent<TMPro.TMP_Text>();

                    if (textBox.text == "") continue; // no text content means no item available
                    // Trim Text content
                    string[] split = textBox.text.Split('-');
                    string firstSplit = split[0].TrimEnd(' ');

                    foreach (Item item in m_Collectables)
                    {
                        // check if clicked Item is equal 
                        if (firstSplit != item.m_ItemName) continue;

                        // if key is not present continue
                        if (!itemAmount.ContainsKey(firstSplit)) continue;

                        // Item found. save item
                        amount = int.Parse(split[1].TrimStart(' '));
                        toUse = item;
                        gotItem = true;
                        break;
                    }

                    // check if item was found
                    if (!gotItem)
                    {
                        // no item was found
                        Debug.LogWarning("No Item found");
                        return;
                    }
                    // item was found
                    string iName = toUse.m_ItemName;
                    toUse.Use();
                    amount--;

                    // Set Textbox string
                    if (amount > 0)
                    {
                        // Items available
                        textBox.text = toUse.m_ItemName + " " + amount.ToString();
                    }
                    else
                    {
                        // no items available
                        textBox.text = "";
                    }

                }
            }

        }

    }
}
