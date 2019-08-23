using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTag : PropertyAttribute
{
    private System.Type type;
    public System.Type Type { get { return type; } }
    public void SerializeInterfaceAttribute(System.Type type)
    {
        this.type = type;
    }
}

