using UnityEngine;

public class Character
{
    private CharacterBase _base;
    private int _level;

    public Character(CharacterBase characterBase, int level) {

        _base = characterBase;
        _level = level;

    }

    // make sure to create formula that modifies attack, defense, and speed based on base level or other attributes

    public float Attack { get { return _base.AttackValue; } }

    public float Defense { get { return _base.DefenseValue; } }

    public float Speed { get { return _base.SpeedValue; } }

    public float MaxHP { get { return _base.MaxHP; } }


}
