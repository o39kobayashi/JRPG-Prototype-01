using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    [SerializeField] private CharacterData _revolverData;
    [SerializeField] private CharacterData _blackMageData;
    [SerializeField] private CharacterData _samuraiData;
    [SerializeField] private CharacterData _noFaceData;


    private List<Character> _activeParty;

    private const int REVOLVER_INDEX = 0;
    private const int BLACK_MAGE_INDEX = 1;
    private const int SAMURAI_INDEX = 2;
    private const int NO_FACE_INDEX = 3;

    private Character _revolver;
    private Character _blackMage;
    private Character _samurai;
    private Character _noFace;

    private const int REVOLVER_STARTING_LEVEL = 1;
    private const int BLACK_MAGE_STARTING_LEVEL = 1;


    public Character Revolver { get { return _revolver; } }
    public Character BlackMage { get { return _blackMage; } }
    public Character Samurai { get { return _samurai; } } 
    public Character NoFace { get { return _noFace; } }
    public List<Character> ActiveParty => _activeParty; // makes activeparty read only ==> read only for ui elements / battle unit setup

    //remove from this file later
    [SerializeField] private CharacterData _enemyData;
    private Character _enemy;
    public Character Enemy { get { return _enemy; } }

    

    private void Awake() {

        _activeParty = new List<Character>();

        _revolver = new Character(_revolverData, REVOLVER_STARTING_LEVEL);

        _blackMage = new Character(_blackMageData, BLACK_MAGE_STARTING_LEVEL);

        // remove later
        _enemy = new Character(_enemyData, 1);
        //


        _activeParty.Add(_revolver);
        _activeParty.Add(_blackMage);
    
    }
    


}
