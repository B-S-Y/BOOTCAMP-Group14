using UnityEngine;

public class EnemyMoveState : EnemyState
{
    Enemy_Lvl1 enemy;
    Vector3 destination;
    public EnemyMoveState(Enemy enemyBase, EnemyStateMachine stateMachine) : base(enemyBase, stateMachine)
    {
        enemy = enemyBase as Enemy_Lvl1;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.speed = enemy.moveSpeed;

        destination = enemy.GetPatrolDestination();
        enemy.agent.SetDestination(destination);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.FaceTarget(GetNextPathPoint());

        if (enemy.agent.remainingDistance <= enemy.agent.stoppingDistance + .05f)
            stateMachine.ChangeState(enemy.idleState);
    }


}
