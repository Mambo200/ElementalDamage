using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodListManager : MonoBehaviour
{
    public float m_TransformLenght;
    public float m_TransformHeight;
    public float m_Space;

    private RectTransform m_Rect;

    private GameObject[] Children { get; set; }
    [SerializeField]
    private GameObject m_ToInstantiate;


    [SerializeField] private GraphicRaycaster raycaster;

    private void OnEnable()
    {
        if (m_Rect == null) m_Rect = GetComponent<RectTransform>();

        // save Inventory copy
        var col = Inventory.Get.Collectables;

        // check every item if its multiple times there
        Dictionary<string, int> ItemAmount = Inventory.Get.ItemAmount;

        Children = new GameObject[ItemAmount.Count];

        int index = -1;
        foreach (KeyValuePair<string, int> kv in ItemAmount.OrderBy(key => key.Key))
        {
            // rise index
            index++;

            // Instantiate UI Object
            Children[index] = Instantiate(m_ToInstantiate, this.gameObject.transform);

            // Set Position of Object
            RectTransform rect = Children[index].GetComponent<RectTransform>();
            rect.position = new Vector3(rect.position.x, rect.position.y + (index * m_Space * -rect.rect.height / 2), 0);
            Children[index].GetComponent<TMPro.TMP_Text>().text = kv.Key + " - " + kv.Value.ToString();
        }
    }

    private void OnDisable()
    {
        // Destroy all children
        for (int i = 0; i < Children.Length; i++)
            Destroy(Children[i].gameObject);

        Children = null;
    }

    private void Update()
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

                    foreach (Item item in Inventory.Get.Collectables)
                    {
                        // check if clicked Item is equal 
                        if (firstSplit != item.m_ItemName) continue;

                        // if key is not present continue
                        if (!Inventory.Get.ItemAmount.ContainsKey(firstSplit)) continue;

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
                    Inventory.Get.SetItemUsed(true);

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
