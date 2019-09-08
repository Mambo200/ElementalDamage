using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodListManager : MonoBehaviour
{
    public float m_TransformLenght;
    public float m_TransformHeight;
    public float m_Space;

    private RectTransform m_Rect;


    private GameObject[] Children { get; set; }
    [SerializeField]
    private GameObject m_ToInstantiate;

    private void OnEnable()
    {
        if(m_Rect == null) m_Rect = GetComponent<RectTransform>();

        // save Inventory copy
        var col = Inventory.Get.Collectables;

        // check every item if its multiple times there
        Dictionary<string, int> ItemAmount = new Dictionary<string, int>();
        foreach (Item item in col)
        {
            if(ItemAmount.ContainsKey(item.m_ItemName))
            {
                // Item is already in dictionary
                ItemAmount[item.m_ItemName]++;
            }
            else
            {
                // Item is not in dictionary
                ItemAmount.Add(item.m_ItemName, 1);
            }

        }

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
        ClickOnTextBox();
    }

    private void ClickOnTextBox()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        Ray ray = MyCamOverworld.m_MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            if (info.collider.gameObject.tag == "EatAble")
            {
                // Food was clicked
                string text = info.collider.gameObject.GetComponent<TMPro.TMP_Text>().text;
                string[] split = text.Split('-');
            }
        }


    }
}
