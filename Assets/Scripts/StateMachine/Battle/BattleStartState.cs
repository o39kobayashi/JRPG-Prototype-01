using UnityEngine;
using TMPro;
using System.Collections;
using System.Linq;

public class BattleStartState : BattleBaseState
{

    private const float WAIT_TIMER = 2.0f;

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

        // Ctx.PlayerObject = GameObject.Instantiate(Ctx.PlayerPrefab, Ctx.PlayerSpawnPoint);
        // Ctx.PlayerUnit = Ctx.PlayerObject.GetComponent<Unit>();
        
        Ctx.PlayerObject = GameObject.Instantiate(Ctx.PlayerCharacter.BattlePrefab, Ctx.PlayerSpawnPoint);
        Ctx.PlayerBattleUnit = Ctx.PlayerObject.GetComponent<BattleUnit>();
        Ctx.PlayerBattleUnit.Setup(Ctx.PlayerCharacter, true);

        // Ctx.EnemyObject = GameObject.Instantiate(Ctx.EnemyPrefab, Ctx.EnemySpawnPoint);
        // Ctx.EnemyUnit = Ctx.EnemyObject.GetComponent<Unit>();

        Ctx.EnemyObject = GameObject.Instantiate(Ctx.EnemyCharacter.BattlePrefab, Ctx.EnemySpawnPoint);
        Ctx.EnemyBattleUnit = Ctx.EnemyObject.GetComponent<BattleUnit>();
        Ctx.EnemyBattleUnit.Setup(Ctx.EnemyCharacter, false);


        // Ctx.DialogueText = Ctx.EnemyUnit.Name + " approaches, and this guy looks pissed!";
        
        Ctx.DialogueText = Ctx.EnemyBattleUnit.Name + " approaches, and this guy looks pissed!";

        // Ctx.PlayerHUD.SetHUD(Ctx.PlayerUnit);
        // Ctx.EnemyHUD.SetHUD(Ctx.EnemyUnit);
        
        Ctx.PlayerHUD.SetBattleHUD(Ctx.PlayerBattleUnit);
        Ctx.EnemyHUD.SetBattleHUD(Ctx.EnemyBattleUnit);

        yield return new WaitForSeconds(WAIT_TIMER);

        SwitchState(Factory.PlayerTurn());

    }

    private void SetupTurnOrder() {

        /*
        foreach (Character character in Ctx.BattleCharacters) {
        
            GameObject currentObject = GameObject.Instantiate(character.BattlePrefab, Ctx.PlayerSpawnPoint);
            BattleUnit currentUnit = currentObject.GetComponent<BattleUnit>();
            currentUnit.Setup(character, true);

            Ctx.BattleUnits.add(currentUnit);
            
        }

        foreach (Character enemy in Ctx.BattleEnemies) {
        
            GameObject currentObject = GameObject.Instantiate(enemy.BattlePrefab, Ctx.EnemySpawnPoint);
            BattleUnit currentUnit = currentObject.GetComponent<BattleUnit>();
            currentUnit.Setup(enemy, false);

            Ctx.BattleUnits.add(currentUnit);

        }

        List<BattleUnit> unitOrder = Ctx.BattleUnits.OrderByDescending(c => c.Speed).ToList();

        foreach (BattleUnit unit in unitOrder) {
        
            Ctx.UnitQueue.Enqueue(unit);
        
        }
         
         */


    }

}
