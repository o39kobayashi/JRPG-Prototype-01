using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{

    [SerializeField] private string _name;
    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _battlePrefab;
    [SerializeField] private Job _job;
    [SerializeField] private string _description;

    [SerializeField] private float _baseMaxHP;
    [SerializeField] private float _baseAttack;
    [SerializeField] private float _baseDefense;
    [SerializeField] private float _baseSpeed;

    [SerializeField] private float _hpGrowthMultiplier;
    [SerializeField] private float _damageGrowthMultiplier;


    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public float BaseMaxHP { get { return _baseMaxHP; } }
    public float BaseAttack { get { return _baseAttack; } }
    public float BaseDefense { get { return _baseDefense; } }
    public float BaseSpeed { get { return _baseSpeed; } }
    public float HPGrowthMultiplier { get { return _hpGrowthMultiplier; } }
    public float DamageGrowthMultiplier { get { return _damageGrowthMultiplier; } }
    public GameObject BattlePrefab { get { return _battlePrefab; } }

}

public enum Job { 

    None,
    Revolver,
    BlackMage,
    Samurai,
    NoFace


}
