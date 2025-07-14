using UnityEngine;
using UnityEngine.AI;

public class EnemyState
{
    protected Enemy enemyBase;
    protected EnemyStateMachine stateMachine;


    protected float stateTimer;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {

    }

    protected Vector3 GetNextPathPoint()
    {
        NavMeshAgent agent = enemyBase.agent;
        NavMeshPath path = agent.path;

        if (path.corners.Length < 2)
            return agent.destination;

        for (int i = 0; i < path.corners.Length; i++)
        {
            if (Vector3.Distance(agent.transform.position, path.corners[i]) < 1)
                return path.corners[i + 1];
        }

        return agent.destination;
    }
}
