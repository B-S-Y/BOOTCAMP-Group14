using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Idle Data")]
    public float idleTime;
    public float agressionRange;

    [Header("Move Data")]
    public float moveSpeed;
    public float chaseSpeed;
    public float turnSpeed;

    [SerializeField] private Transform[] patrolPoints;
    private Vector3[] patrolPointsPositions;
    private int currentPatrolIndex;

    public bool inBattleMode { get; private set; }

    public Transform player { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public EnemyStateMachine stateMachine { get; private set; }


    protected virtual void Awake()
    {
        stateMachine = new EnemyStateMachine();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected virtual void Start()
    {
        InitializePatrolPoints();
    }

    protected virtual void Update()
    {
        if (ShouldEnterBattleMode())
            EnterBattleMode();
    }


    protected bool ShouldEnterBattleMode()
    {
        bool isAgressionRange = Vector3.Distance(transform.position, player.position) < agressionRange;

        if (isAgressionRange && !inBattleMode)
        {
            EnterBattleMode();
            return true;
        }
        else if (!isAgressionRange && inBattleMode)
        {
            inBattleMode = false;
            return false;
        }

        return false;
    }

    public virtual void EnterBattleMode()
    {
        inBattleMode = true;
    }

    public bool IsInBattleMode() => inBattleMode;

    public void FaceTarget(Vector3 target)
    {
        Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

        Vector3 currentEularAngles = transform.rotation.eulerAngles;

        float yRotation = Mathf.LerpAngle(currentEularAngles.y, targetRotation.eulerAngles.y, turnSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(currentEularAngles.x, yRotation, currentEularAngles.z);
    }



    public Vector3 GetPatrolDestination()
    {
        Vector3 destination = patrolPointsPositions[currentPatrolIndex];

        currentPatrolIndex++;

        if (currentPatrolIndex >= patrolPoints.Length)
            currentPatrolIndex = 0;

        return destination;
    }

    private void InitializePatrolPoints()
    {
        patrolPointsPositions = new Vector3[patrolPoints.Length];

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            patrolPointsPositions[i] = patrolPoints[i].position;
            patrolPoints[i].gameObject.SetActive(false);
        }
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, agressionRange);
    }
}
