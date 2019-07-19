using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements.Element
{
    public abstract class ElementDictionary
    {
        private Dictionary<EElement, float> elementValueAttack = new Dictionary<EElement, float>();
        /// <summary>Element Attack</summary>
        public Dictionary<EElement, float> ElementValueAttack { get { return elementValueAttack; } }

        private Dictionary<EElement, float> elementValueDefence = new Dictionary<EElement, float>();
        /// <summary>Element Defence</summary>
        public Dictionary<EElement, float> ElementValueDefence { get { return elementValueDefence; } }


        #region Attack Element
        #region Add Attack
        /// <summary>
        /// Add Element to <see cref="ElementValueAttack"/>
        /// </summary>
        /// <param name="_mix">Elementmix</param>
        public void AddElementAttack(ElementMix _mix)
        {
            if (!ElementValueAttack.ContainsKey(_mix.Element))
                ElementValueAttack.Add(_mix.Element, _mix.Multiplier);
        }
        /// <summary>
        /// Add Element to <see cref="ElementValueAttack"/>
        /// </summary>
        /// <param name="_element">Element to add</param>
        /// <param name="_elementValue">value (in percent) to add</param>
        public void AddElementAttack(EElement _element, float _elementValue)
        {
            if (!ElementValueAttack.ContainsKey(_element))
                ElementValueAttack.Add(_element, _elementValue);
        }
        #endregion

        #region Change Element Value Attack
        /// <summary>
        /// Change existing element value in <see cref="ElementValueAttack"/>
        /// </summary>
        /// <param name="_element">Element to look for</param>
        /// <param name="_newValue">new attack value</param>
        public void ChangeElementValueAttack(EElement _element, float _newValue)
        {
            if (ElementValueAttack.ContainsKey(_element))
                ElementValueAttack[_element] = _newValue;
        }
        /// <summary>
        /// Change existing element value in <see cref="ElementValueAttack"/>
        /// </summary>
        /// <param name="_mix">Elementmix</param>
        public void ChangeElementValueAttack(ElementMix _mix) => ChangeElementValueAttack(_mix.Element, _mix.Multiplier);
        #endregion

        #region Remove Attack
        /// <summary>
        /// Remove element from Dictionary in <see cref="ElementValueAttack"/>
        /// </summary>
        /// <param name="_element">Element to remove</param>
        public void RemoveElementAttack(EElement _element)
        {
            if (ElementValueAttack.ContainsKey(_element))
                ElementValueAttack.Remove(_element);
        }
        /// <summary>
        /// Remove element from Dictionary in <see cref="ElementValueAttack"/>
        /// </summary>
        /// <param name="_mix">Elementmix</param>
        public void RemoveElementAttack(ElementMix _mix) => RemoveElementAttack(_mix.Element);
        #endregion
        #endregion

        #region Defence Element
        #region Add Defence
        /// <summary>
        /// Add Element to <see cref="ElementValueDefence"/>
        /// </summary>
        /// <param name="_mix">Elementmix</param>
        public void AddElementDefence(ElementMix _mix)
        {
            if (!ElementValueDefence.ContainsKey(_mix.Element))
                ElementValueDefence.Add(_mix.Element, _mix.Multiplier);
        }
        /// <summary>
        /// Add Element to <see cref="ElementValueDefence"/>
        /// </summary>
        /// <param name="_mix">Elementmix</param>
        public void AddElementDefence(EElement _element, float _elementValue)
        {
            if (!ElementValueDefence.ContainsKey(_element))
                ElementValueDefence.Add(_element, _elementValue);
        }
        #endregion

        #region Change Element Value Defence
        /// <summary>
        /// Change existing element value in <see cref="ElementValueDefence"/>
        /// </summary>
        /// <param name="_element">Element to look for</param>
        /// <param name="_newValue">new attack value</param>
        public void ChangeElementValueDefence(EElement _element, float _newValue)
        {
            if (ElementValueDefence.ContainsKey(_element))
                ElementValueDefence[_element] = _newValue;
        }
        /// <summary>
        /// Change existing element value in <see cref="ElementValueDefence"/>
        /// </summary>
        /// <param name="_mix">Elementmix</param>
        public void ChangeElementValueDefence(ElementMix _mix) => ChangeElementValueDefence(_mix.Element, _mix.Multiplier);
        #endregion

        #region Remove Defence
        /// <summary>
        /// Remove element from Dictionary in <see cref="ElementValueDefence"/>
        /// </summary>
        /// <param name="_element">Element to remove</param>
        public void RemoveElementDefence(EElement _element)
        {
            if (ElementValueDefence.ContainsKey(_element))
                ElementValueDefence.Remove(_element);
        }
        /// <summary>
        /// Remove element from Dictionary in <see cref="ElementValueDefence"/>
        /// </summary>
        /// <param name="_element">Elementmix</param>
        public void RemoveElementDefence(ElementMix _mix) => RemoveElementDefence(_mix.Element);
        #endregion
        #endregion

        /// <summary>Clear Attack Dictionary</summary>
        public void ResetAttack() => ElementValueAttack.Clear();
        /// <summary>Clear Defence Dictionary</summary>
        public void ResetDefence() => ElementValueDefence.Clear();
    }
}
