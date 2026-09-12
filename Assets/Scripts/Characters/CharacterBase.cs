using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBase", menuName = "Scriptable Objects/CharacterBase")]
public class CharacterBase : ScriptableObject
{

    [SerializeField] private string _name;
    [TextArea][SerializeField] private string _description;
    [SerializeField] private GameObject _model;
    [SerializeField] private CharacterJob _job;

    //-------------------------------------------------------------------
    // Base Stats
    //-------------------------------------------------------------------
    [SerializeField] private float _maxHP;
    [SerializeField] private float _attackValue;
    [SerializeField] private float _defenseValue;
    [SerializeField] private float _speedValue;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public GameObject Model { get { return _model; } }
    public CharacterJob Job { get { return _job; } }
    public float MaxHP { get { return _maxHP; } }
    public float AttackValue { get { return _attackValue; } }
    public float DefenseValue { get { return _defenseValue; } }
    public float SpeedValue { get { return _speedValue; } }
}

public enum CharacterJob { 

    None,
    Revolver,
    BlackMage,
    Samurai,
    Skull


}