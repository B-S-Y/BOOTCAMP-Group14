using UnityEngine;

public class Enemy_Lvl1 : Enemy
{

    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemyChaseState chaseState { get; private set; }
    public EnemyRecoveryState recoveryState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new EnemyIdleState(this, stateMachine);
        moveState = new EnemyMoveState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        recoveryState = new EnemyRecoveryState(this, stateMachine);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }


    public override void EnterBattleMode()
    {
        base.EnterBattleMode();

        stateMachine.ChangeState(recoveryState);
    }
}
