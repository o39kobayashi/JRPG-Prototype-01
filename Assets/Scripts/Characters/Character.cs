using UnityEngine;

public class Character
{

    private CharacterData _characterData;

    private string _name;
    private string _description;
    private int _level;
    private float _exp;
    private float _currentHP;
    private float _maxHP;

    public string Name { get { return _characterData.Name; } }
    public string Description { get { return _characterData.Description; } }

    public float CurrentHP { get { return _currentHP; } set { _currentHP = value; } }
    public float MaxHP { get { return _maxHP; } }

    public int Level { get { return _level; } }

    public float Attack { get { return (_characterData.BaseAttack * (1 + ((float)_level / 10))); } } // experimental equation with cast int to float
    public float Defense { get { return (_characterData.BaseDefense * _level); } } // probably very broken formula but just temporary until start testing
    public float Speed { get { return (_characterData.BaseSpeed * _level); } }
    public GameObject BattlePrefab { get { return _characterData.BattlePrefab; } } // battle prefab for specific character
    
    public float EXP { get { return _exp; } set { _exp = value; } }

    public Character(CharacterData characterData, int level) {

        _characterData = characterData;
        _level = level;

        _currentHP = characterData.BaseMaxHP;


    }

    public void UpdateEXP(float exp) {

        _exp += exp;
    
    }


}
