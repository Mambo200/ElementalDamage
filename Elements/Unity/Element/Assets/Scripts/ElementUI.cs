using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ElementUI : MonoBehaviour
{
    //public Color m_Zero;
    //public Color m_Resistance;
    //public Color m_Weakness;
    public static Color Zero { get { return Color.white; } }
    public static Color Resistance { get { return new Color(0.2235293f, 1, 0.07843132f); } }
    public static Color Weakness { get { return new Color(1, 0.02745098f, 0.2274509f); } }
    [Header("Name Textbox")]
    [SerializeField] Text NameText;
    [Header("Element Textboxes")]
    [SerializeField] Text FireText;
    [SerializeField] Text WaterText;
    [SerializeField] Text ElectricityText;
    [SerializeField] Text IceText;
    [SerializeField] Text WindText;
    [SerializeField] Text StoneText;

    [Header("Element Images")]
    [SerializeField] Image FireImage;
    [SerializeField] Image WaterImage;
    [SerializeField] Image ElectricityImage;
    [SerializeField] Image IceImage;
    [SerializeField] Image WindImage;
    [SerializeField] Image StoneImage;

    private Text[] AllText;
    private Image[] AllImage;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (NameText == null) Debug.LogWarning("NameText is null", this.gameObject);
        if (FireText == null) Debug.LogWarning("FireText is null", this.gameObject);
        if (WaterText == null) Debug.LogWarning("WaterText is null", this.gameObject);
        if (ElectricityText == null) Debug.LogWarning("ElectricityText is null", this.gameObject);
        if (IceText == null) Debug.LogWarning("IceText is null", this.gameObject);
        if (WindText == null) Debug.LogWarning("WindText is null", this.gameObject);
        if (StoneText == null) Debug.LogWarning("StoneText is null", this.gameObject);

        if (FireImage == null) Debug.LogWarning("FireImage is null", this.gameObject);
        if (WaterImage == null) Debug.LogWarning("WaterImage is null", this.gameObject);
        if (ElectricityImage == null) Debug.LogWarning("ElectricityImage is null", this.gameObject);
        if (IceImage == null) Debug.LogWarning("IceImage is null", this.gameObject);
        if (WindImage == null) Debug.LogWarning("WindImage is null", this.gameObject);
        if (StoneImage == null) Debug.LogWarning("StoneImage is null", this.gameObject);

        AllText = new Text[]
        {
            NameText,
            FireText,
            WaterText,
            ElectricityText,
            IceText,
            WindText,
            StoneText
        };

        AllImage = new Image[]
        {
            FireImage,
            WaterImage,
            ElectricityImage,
            IceImage,
            WindImage,
            StoneImage
        };

        yield return new WaitForEndOfFrame();
    }

    public void SetNameText(string _name)
    {
        NameText.text = _name;
    }
    public void SetFireText(int _percentage)
    {
        if(_percentage > 0) FireText.text = "+" + _percentage.ToString();
        else FireText.text = _percentage.ToString();
        SetColor(_percentage, FireText);
    }
    public void SetWaterText(int _percentage)
    {
        if (_percentage > 0) WaterText.text = "+" + _percentage.ToString();
        else WaterText.text = _percentage.ToString();
        SetColor(_percentage, WaterText);
    }
    public void SetElectricityText(int _percentage)
    {
        if (_percentage > 0) ElectricityText.text = "+" + _percentage.ToString();
        else ElectricityText.text = _percentage.ToString();
        SetColor(_percentage, ElectricityText);
    }
    public void SetIceText(int _percentage)
    {
        if (_percentage > 0) IceText.text = "+" + _percentage.ToString();
        else IceText.text = _percentage.ToString();
        SetColor(_percentage, IceText);
    }
    public void SetWindText(int _percentage)
    {
        if (_percentage > 0) WindText.text = "+" + _percentage.ToString();
        else WindText.text = _percentage.ToString();
        SetColor(_percentage, WindText);
    }
    public void SetStoneText(int _percentage)
    {
        if (_percentage > 0) StoneText.text = "+" + _percentage.ToString();
        else StoneText.text = _percentage.ToString();
        SetColor(_percentage, StoneText);
    }

    public void SetAllText(string _name, params Elements.ElementalMix[] _resistance)
    {
        SetNameText(_name);
        foreach (Elements.ElementalMix mix in _resistance)
        {
            switch (mix.ElementalType)
            {
                case Elements.EElementalTypes.NONE:
                    break;
                case Elements.EElementalTypes.NORMAL:
                    break;
                case Elements.EElementalTypes.FIRE:
                    SetFireText((int)(mix.Percentage * 100));
                    break;
                case Elements.EElementalTypes.WATER:
                    SetWaterText((int)(mix.Percentage * 100));
                    break;
                case Elements.EElementalTypes.ICE:
                    SetIceText((int)(mix.Percentage * 100));
                    break;
                case Elements.EElementalTypes.ELECTRICITY:
                    SetElectricityText((int)(mix.Percentage * 100));
                    break;
                case Elements.EElementalTypes.WIND:
                    SetWindText((int)(mix.Percentage * 100));
                    break;
                case Elements.EElementalTypes.STONE:
                    SetStoneText((int)(mix.Percentage * 100));
                    break;
                default:
                    Debug.LogWarning(mix.ElementalType + " is not implemented yet", this.gameObject);
                    break;
            }
        }
    }

    public void SetAllText(string _name, Dictionary<Elements.EElementalTypes, float> _resistance)
    {
        SetNameText(_name);
        foreach (KeyValuePair<Elements.EElementalTypes, float> kv in _resistance)
        {
            switch (kv.Key)
            {
                case Elements.EElementalTypes.NONE:
                    break;
                case Elements.EElementalTypes.NORMAL:
                    break;
                case Elements.EElementalTypes.FIRE:
                    SetFireText((int)(kv.Value * 100));
                    break;
                case Elements.EElementalTypes.WATER:
                    SetWaterText((int)(kv.Value * 100));
                    break;
                case Elements.EElementalTypes.ICE:
                    SetIceText((int)(kv.Value * 100));
                    break;
                case Elements.EElementalTypes.ELECTRICITY:
                    SetElectricityText((int)(kv.Value * 100));
                    break;
                case Elements.EElementalTypes.WIND:
                    SetWindText((int)(kv.Value * 100));
                    break;
                case Elements.EElementalTypes.STONE:
                    SetStoneText((int)(kv.Value * 100));
                    break;
                default:
                    Debug.LogWarning(kv.Key + " is not implemented yet", this.gameObject);
                    break;
            }

        }
    }

    private void SetColor(int _percentage, Text _text)
    {
        if (_percentage == 0) _text.color = Zero;
        else if (_percentage < 0) _text.color = Weakness;
        else if (_percentage > 0) _text.color = Resistance;
        else Debug.LogError(_percentage + " is nether equal 0, higher or less than 0", this.gameObject);
    }

    public void ResetAllText()
    {
        SetNameText("No Enemy");
        SetFireText(0);
        SetWaterText(0);
        SetElectricityText(0);
        SetIceText(0);
        SetWindText(0);
        SetStoneText(0);
    }

    private void OnDisable()
    {
        ResetAllText();
    }

    
}
