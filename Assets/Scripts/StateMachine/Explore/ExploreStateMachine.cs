using UnityEngine;
using System.Collections.Generic;

public class ExploreStateMachine : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerStateMachine _playerStateMachine;

    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private GameObject _party;

    private GameObject _activeCharacter;

    private const int REVOLVER_INDEX = 0;
    private const int BLK_MAGE_INDEX = 1;
    private const int SAMURAI_INDEX = 2;
    private const int NO_FACE_INDEX = 3;

    private int _currentCharacterIndex = 0;
    private int _activeCharacterIndex;

    public GameObject ActiveCharacter { get { return _activeCharacter; } }
    public GameObject Revolver { get { return _characters[REVOLVER_INDEX]; } }
    public GameObject BlkMage { get { return _characters[BLK_MAGE_INDEX]; } }
    public GameObject Samurai { get { return _characters[SAMURAI_INDEX]; } }
    public GameObject NoFace { get { return _characters[NO_FACE_INDEX]; } }
    public int ActiveCharacterIndex { get { return _activeCharacterIndex; } }
    public int CurrentCharacterIndex { get { return _currentCharacterIndex; } set { _currentCharacterIndex = value; } }

    private void Awake() {

        _activeCharacterIndex = _currentCharacterIndex;

        _activeCharacter = _characters[0];
    
    }
    

}
