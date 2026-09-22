using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BattleHUD : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _currentHP;
    [SerializeField] private TextMeshProUGUI _lvl;

    public TextMeshProUGUI Name { get { return _name; } set { _name = value; } }
    public TextMeshProUGUI CurrentHP { get { return _currentHP; } set { _currentHP = value; } }
    public TextMeshProUGUI Level { get { return _lvl; } set { _lvl = value; } }

    public void SetHUD(Unit unit) {

        _name.text = unit.Name;
        _currentHP.text = "HP: " + unit.CurrentHP.ToString();
        _lvl.text = "LVL: "+ unit.Level.ToString();
    
    }

    public void SetBattleHUD(BattleUnit battleUnit) {

        _name.text = battleUnit.Name;
        _currentHP.text = "HP: " + battleUnit.CurrentHP.ToString();
        _lvl.text = "LVL: " + battleUnit.Level.ToString();
    
    }

    public void SetHP(float currentHP) {

        if (currentHP < 0) {

            _currentHP.text = "HP: 0";

        }
        else {

            _currentHP.text = "HP: " + currentHP.ToString();

        }
    
    
    }

}
