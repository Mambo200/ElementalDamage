using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Linq;

[CustomPropertyDrawer(typeof(ElementTag))]
public class ElementPlayerGUI : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        label = new GUIContent("Mix");
        position = EditorGUI.PrefixLabel(position, label);

        var rect = new Rect(position.position, Vector2.one * 20); 

        if(EditorGUI.DropdownButton(rect, new GUIContent(GetTexture()), FocusType.Keyboard, new GUIStyle() { fixedWidth = 50f, border = new RectOffset(1,1,1,1)}))
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Constant"), true, () => GetTexture());
            menu.AddItem(new GUIContent("Variaable"), false, () => GetTexture());
            menu.AddItem(new GUIContent("Another"), true, () => GetTexture());

            menu.ShowAsContext();
        }

        SerializedProperty nameProperty = property.FindPropertyRelative("Name");
        EditorGUI.PropertyField(position, nameProperty);
        SerializedProperty maxHealptProperty = property.FindPropertyRelative("MaxHealth");
        EditorGUI.PropertyField(new Rect(position.x, position.y - 5, position.width, position.height), maxHealptProperty);
        SerializedProperty descriptionProperty = property.FindPropertyRelative("Description");
        EditorGUI.PropertyField(new Rect(position.x, position.y - 10, position.width, position.height), descriptionProperty);
        EditorGUI.EndProperty();
    }

    //public override VisualElement CreatePropertyGUI(SerializedProperty property)
    //{
    //    // Create property container element.
    //    var container = new VisualElement();
    //
    //    // Create property fields.
    //    var Name = new PropertyField(property.FindPropertyRelative("Name"));
    //    var MaxHealth = new PropertyField(property.FindPropertyRelative("MaxHealth"));
    //    var Description = new PropertyField(property.FindPropertyRelative("Description"), "Fancy Name");
    //
    //    // Add fields to the container.
    //    container.Add(Name);
    //    container.Add(MaxHealth);
    //    container.Add(Description);
    //
    //    return container;
    //}

    private Texture GetTexture()
    {
        var textures = Resources.FindObjectsOfTypeAll(typeof(Texture))
            .Where(t => t.name.ToLower().Contains("animationdopessheetkeyframe"))
            .Cast<Texture>().ToList();

        return textures[0];
    }
}
