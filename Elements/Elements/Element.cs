using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public class Element
    {
        #region Constructor
        public Element()
        {
            Water = 0;
            Earth = 0;
            Fire = 0;
            Wind = 0;
            Poison = 0;
            Electricity = 0;
            Holy = 0;
            Dark = 0;
        }

        /// <summary>
        /// Add Element Values (1 is 100%, 0 is 0%, -1 is -100%)
        /// </summary>
        /// <param name="_water">Value for Water</param>
        /// <param name="_earth">Value for Earth</param>
        /// <param name="_fire">Value for Fire</param>
        /// <param name="_wind">Value for Wind</param>
        /// <param name="_poison">Value for Poison</param>
        /// <param name="_electricity">Value for Electricity</param>
        /// <param name="_holy">Value for Holy</param>
        /// <param name="_dark">Value for Dark</param>
        public Element(float _water, float _earth, float _fire, float _wind, float _poison, float _electricity, float _holy, float _dark)
        {
            Water = _water;
            Earth = _earth;
            Fire = _fire;
            Wind = _wind;
            Poison = _poison;
            Electricity = _electricity;
            Holy = _holy;
            Dark = _dark;
        }
        #endregion

        #region Variables
        public float Water { get; private set; }
        public float Earth { get; private set; }
        public float Fire { get; private set; }
        public float Wind { get; private set; }
        public float Poison { get; private set; }
        public float Electricity { get; private set; }
        public float Holy { get; private set; }
        public float Dark { get; private set; }
        #endregion

        #region public Methods
        public void ChangeWater(float _newValue) => Water = _newValue;
        public void ChangeEarth(float _newValue) => Earth = _newValue;
        public void ChangeFire(float _newValue) => Fire = _newValue;
        public void ChangeWind(float _newValue) => Wind = _newValue;
        public void ChangePoison(float _newValue) => Poison = _newValue;
        public void ChangeElectricity(float _newValue) => Electricity = _newValue;
        public void ChangeHoly(float _newValue) => Holy = _newValue;
        public void ChangeDark(float _newValue) => Dark = _newValue;
        #endregion

        #region Static Methods
        public static ELEMENTTYPE GetFirstElement(Element _element)
        {
            if (_element.Water > 0) return ELEMENTTYPE.WATER;
            if (_element.Earth > 0) return ELEMENTTYPE.EARTH;
            if (_element.Fire > 0) return ELEMENTTYPE.FIRE;
            if (_element.Wind > 0) return ELEMENTTYPE.WIND;
            if (_element.Poison > 0) return ELEMENTTYPE.POISON;
            if (_element.Electricity > 0) return ELEMENTTYPE.ELECTRICITY;
            if (_element.Holy > 0) return ELEMENTTYPE.HOLY;
            if (_element.Dark > 0) return ELEMENTTYPE.DARK;

            return ELEMENTTYPE.NONE;
        }
        #endregion

        #region Operator
        public static Element operator  +(Element _left, Element _right)
        {
            Element toReturn = new Element();
            toReturn.Water = _left.Water + _right.Water;
            toReturn.Earth = _left.Earth + _right.Earth;
            toReturn.Fire = _left.Fire + _right.Fire;
            toReturn.Wind = _left.Wind + _right.Wind;
            toReturn.Poison = _left.Poison + _right.Poison;
            toReturn.Electricity = _left.Electricity + _right.Electricity;
            toReturn.Holy = _left.Holy + _right.Holy;
            toReturn.Dark = _left.Dark + _right.Dark;

            return toReturn;
        }
        public static Element operator -(Element _left, Element _right)
        {
            Element toReturn = new Element();
            toReturn.Water = _left.Water - _right.Water;
            toReturn.Earth = _left.Earth - _right.Earth;
            toReturn.Fire = _left.Fire - _right.Fire;
            toReturn.Wind = _left.Wind - _right.Wind;
            toReturn.Poison = _left.Poison - _right.Poison;
            toReturn.Electricity = _left.Electricity - _right.Electricity;
            toReturn.Holy = _left.Holy - _right.Holy;
            toReturn.Dark = _left.Dark - _right.Dark;

            return toReturn;
        }
        #endregion
    }

    public class Resistance
    {
        #region Constructor
        public Resistance()
        {
            Resistances = new Element();
        }
        public Resistance(Element _element) { Resistances = _element; }
        public Resistance(float _water, float _earth, float _fire, float _wind, float _poison, float _electricity, float _holy, float _dark)
        {
            Resistances = new Element(_water, _earth, _fire, _wind, _poison, _electricity, _holy, _dark);
        }
        #endregion

        public Element Resistances { get; private set; }

        #region operator
        public static Resistance operator +(Resistance _left, Resistance _right)
        {
            Resistance res = new Resistance();
            res.Resistances = _left.Resistances + _right.Resistances;

            return res;
        }
        public static Resistance operator -(Resistance _left, Resistance _right)
        {
            Resistance res = new Resistance();
            res.Resistances = _left.Resistances - _right.Resistances;

            return res;
        }
        #endregion
    }

    public class Damage
    {
        #region Constructor
        public Damage()
        {
            Damages = new Element();
        }
        public Damage(Element _element) { Damages = _element; }
        public Damage(float _water, float _earth, float _fire, float _wind, float _poison, float _electricity, float _holy, float _dark)
        {
            Damages = new Element(_water, _earth, _fire, _wind, _poison, _electricity, _holy, _dark);
        }
        #endregion

        public Element Damages { get; private set; }

        #region operator
        public static Damage operator +(Damage _left, Damage _right)
        {
            Damage dam = new Damage();
            dam.Damages = _left.Damages + _right.Damages;

            return dam;
        }
        public static Damage operator -(Damage _left, Damage _right)
        {
            Damage dam = new Damage();
            dam.Damages = _left.Damages - _right.Damages;

            return dam;
        }
        #endregion

    }

    public class Weapon
    {
        public static Random rnd;
        private Weapon() { }

        public ELEMENTTYPE WeaponElement
        {
            get
            {
                return Element.GetFirstElement(Damage.Damages);
            }
        }

        public Weapon(Resistance _resistance, Damage _damage, int _minDamage, int _maxDamage)
        {
            Resistance = _resistance;
            Damage = _damage;

            if (_minDamage > _maxDamage) throw new Exception("Min Damage was higher than Max Damage. This is not allowed.");
            minDamage = _minDamage;
            maxDamage = _maxDamage;
        }

        private int minDamage;
        private int maxDamage;

        public Resistance Resistance { get; private set; }
        public Damage Damage { get; private set; }

        public int GetDamage()
        {
            return rnd.Next(minDamage, maxDamage + 1);
        }
    }

    public enum ELEMENTTYPE
    {
        NONE,
        WATER,  
        EARTH,
        FIRE,
        WIND,
        POISON,
        ELECTRICITY,
        HOLY,
        DARK
    }
}
