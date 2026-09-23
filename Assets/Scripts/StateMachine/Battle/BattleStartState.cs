using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BattleStartState : BattleBaseState
{

    private const float WAIT_TIMER = 2.0f;
    private const bool IS_PLAYER = true;

    public BattleStartState(BattleStateMachine currentContext, BattleStateFactory battleStateFactory)
    : base(currentContext, battleStateFactory) { }


    public override void EnterState() {

        Ctx.Player.SetActive(false);
        Ctx.ExploreCamera.SetActive(false);

        Ctx.BattleCamera.SetActive(true);

        Ctx.StartCoroutine(SetupBattle());

    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchStates() {

        

    }

    public override void InitializeSubState()
    {
        
    }

    private IEnumerator SetupBattle()
    {

        /*


        // Ctx.PlayerObject = GameObject.Instantiate(Ctx.PlayerPrefab, Ctx.PlayerSpawnPoint);
        // Ctx.PlayerUnit = Ctx.PlayerObject.GetComponent<Unit>();
        
        Ctx.PlayerObject = GameObject.Instantiate(Ctx.PlayerCharacter.BattlePrefab, Ctx.PlayerSpawnPoint);
        Ctx.PlayerBattleUnit = Ctx.PlayerObject.GetComponent<BattleUnit>();
        Ctx.PlayerBattleUnit.Setup(Ctx.PlayerCharacter, IS_PLAYER);

        // Ctx.EnemyObject = GameObject.Instantiate(Ctx.EnemyPrefab, Ctx.EnemySpawnPoint);
        // Ctx.EnemyUnit = Ctx.EnemyObject.GetComponent<Unit>();

        Ctx.EnemyObject = GameObject.Instantiate(Ctx.EnemyCharacter.BattlePrefab, Ctx.EnemySpawnPoint);
        Ctx.EnemyBattleUnit = Ctx.EnemyObject.GetComponent<BattleUnit>();
        Ctx.EnemyBattleUnit.Setup(Ctx.EnemyCharacter, !IS_PLAYER);


        */

        Ctx.PlayerObject = GameObject.Instantiate(Ctx.PlayerCharacter.BattlePrefab, Ctx.PlayerSpawnPoint);
        Ctx.PlayerBattleUnit = Ctx.PlayerObject.GetComponent<BattleUnit>();
        Ctx.PlayerBattleUnit.Setup(Ctx.PlayerCharacter, IS_PLAYER);

        Ctx.EnemyObject = GameObject.Instantiate(Ctx.EnemyCharacter.BattlePrefab, Ctx.EnemySpawnPoint);
        Ctx.EnemyBattleUnit = Ctx.EnemyObject.GetComponent<BattleUnit>();
        Ctx.EnemyBattleUnit.Setup(Ctx.EnemyCharacter, !IS_PLAYER);


        InstantiateUnitsAndSetupTurnOrder();

        
        // Ctx.DialogueText = Ctx.EnemyBattleUnit.Name + " approaches, and this guy looks pissed!";
        Ctx.DialogueText = Ctx.EncounterText;

        // Ctx.PlayerHUD.SetHUD(Ctx.PlayerUnit);
        // Ctx.EnemyHUD.SetHUD(Ctx.EnemyUnit);

        Ctx.PlayerHUD.SetBattleHUD(Ctx.PlayerBattleUnit);
        Ctx.EnemyHUD.SetBattleHUD(Ctx.EnemyBattleUnit);

        yield return new WaitForSeconds(WAIT_TIMER);

        // SwitchState(Factory.PlayerTurn());

    }

    private void InstantiateUnitsAndSetupTurnOrder() {

        int currentSpawnPoint = 0;

        foreach (Character character in Ctx.BattleCharacters) {
        
            GameObject currentObject = GameObject.Instantiate(character.BattlePrefab, Ctx.PlayerSpawnPoints[currentSpawnPoint]);
            BattleUnit currentUnit = currentObject.GetComponent<BattleUnit>();
            currentUnit.Setup(character, IS_PLAYER);

            Ctx.BattleUnits.Add(currentUnit);

            currentSpawnPoint++;
            
        }

        currentSpawnPoint = 0;

        foreach (Character enemy in Ctx.BattleEnemies) {
        
            GameObject currentObject = GameObject.Instantiate(enemy.BattlePrefab, Ctx.EnemySpawnPoints[currentSpawnPoint]);
            BattleUnit currentUnit = currentObject.GetComponent<BattleUnit>();
            currentUnit.Setup(enemy, !IS_PLAYER);

            Ctx.BattleUnits.Add(currentUnit);

            currentSpawnPoint++;

        }

        List<BattleUnit> unitOrder = Ctx.BattleUnits.OrderByDescending(c => c.Speed).ToList();

        foreach (BattleUnit unit in unitOrder)
        {

            Debug.Log("ORDER | UNIT NAME: " + unit.Name);

        }

        foreach (BattleUnit unit in unitOrder) {
        
            Ctx.UnitQueue.Enqueue(unit);
        
        }
         

    }

    private void DebugTurnOrder() {

        foreach (BattleUnit unit in Ctx.BattleUnits) {

            Debug.Log("UNIT NAME: " + unit.Name);
        
        }
    
    
    
    }

}
