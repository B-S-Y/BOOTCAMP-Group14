using UnityEngine;

public class EnemyIdleState : EnemyState
{
    Enemy_Lvl1 enemy;
    public EnemyIdleState(Enemy enemyBase, EnemyStateMachine stateMachine) : base(enemyBase, stateMachine)
    {
        enemy = enemyBase as Enemy_Lvl1;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemyBase.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);

    }


}
