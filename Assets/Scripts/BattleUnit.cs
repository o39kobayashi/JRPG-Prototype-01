using UnityEngine;

public class BattleUnit : MonoBehaviour
{

    private Character _character;
    private bool _isPlayer;

    public string Name { get { return _character.Name; } }
    public int Level { get { return _character.Level; } }
    public float Speed { get { return _character.Speed; } }
    public float CurrentHP { get { return _character.CurrentHP; } }

    public float AttackDamage { get { return _character.Attack; } }

    public void Setup(Character character, bool isPlayer) {

        _character = character;
        _isPlayer = isPlayer;
    
    }

    public bool TakeDamage(float damage) {

        _character.CurrentHP -= damage;

        if (_character.CurrentHP <= 0) {

            _character.CurrentHP = 0;
            return true;
        
        }

        return false;
    
    
    }


}
