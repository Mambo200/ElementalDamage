using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Element
{
    public abstract class ElementDictionary
    {
        private Dictionary<EElement, float> elementValues = new Dictionary<EElement, float>();
        public Dictionary<EElement, float> ElementValues { get; }

        #region Add
        public void AddElement(ElementMix _mix)
        {
            if (!ElementValues.ContainsKey(_mix.Element))
                ElementValues.Add(_mix.Element, _mix.Multiplier);
        }
        public void AddElement(EElement _element, float _elementValue)
        {
            if (!ElementValues.ContainsKey(_element))
                ElementValues.Add(_element, _elementValue);
        }
        #endregion

        #region Change Element Value
        public void ChangeElementValue(EElement _element, float _newValue)
        {
            if (ElementValues.ContainsKey(_element))
                ElementValues[_element] = _newValue;
        }
        public void ChangeElementValue(ElementMix _mix) => ChangeElementValue(_mix.Element, _mix.Multiplier);
        #endregion

        #region Remove
        public void RemoveElement(EElement _element)
        {
            if (ElementValues.ContainsKey(_element))
                ElementValues.Remove(_element);
        }
        public void RemoveElement(ElementMix _mix) => RemoveElement(_mix.Element);
        #endregion

        public void Reset() => ElementValues.Clear();
    }
}
