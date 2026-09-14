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
    private int _partySize;

    private void Awake() {

        _activeCharacterIndex = _currentCharacterIndex;

        _activeCharacter = _characters[0];

        _partySize = _characters.Count;
    
    }
    

}
