using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _level;
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;

    public string Name { get { return _name; } set { _name = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public int Damage { get { return _damage; } set { _damage = value; } }
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }
    public int CurrentHP { get { return _currentHP; } set { _currentHP = value; } }

    public bool TakeDamage(int dmg) {

        _currentHP -= dmg;

        if (_currentHP <= 0)
        {

            return true;

        }

        return false;
    
    }


}
