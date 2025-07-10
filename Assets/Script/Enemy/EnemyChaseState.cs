using UnityEngine;

public class EnemyChaseState : EnemyState
{
    Enemy_Lvl1 enemy;
    private float lastTimeUpdatedDestination;
    public EnemyChaseState(Enemy enemyBase, EnemyStateMachine stateMachine) : base(enemyBase, stateMachine)
    {
        enemy = enemyBase as Enemy_Lvl1;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.speed = enemy.chaseSpeed;

        enemy.agent.isStopped = false;
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();

        enemy.FaceTarget(GetNextPathPoint());

        if (CanUpdateDestination())
        {
            enemy.agent.destination = enemy.player.position;
        }
    }

    private bool CanUpdateDestination()
    {
        if (Time.time > lastTimeUpdatedDestination + .25f)
        {
            lastTimeUpdatedDestination = Time.time;
            return true;
        }
        return false;
    }
}
