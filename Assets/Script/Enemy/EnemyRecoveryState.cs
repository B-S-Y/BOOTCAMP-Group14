using UnityEngine;

public class EnemyRecoveryState : EnemyState
{
    Enemy_Lvl1 enemy;
    public EnemyRecoveryState(Enemy enemyBase, EnemyStateMachine stateMachine) : base(enemyBase, stateMachine)
    {
        enemy = enemyBase as Enemy_Lvl1;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.isStopped = true;

        stateTimer = 1.2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.FaceTarget(enemy.player.position);

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.chaseState);
        }
    }


}
