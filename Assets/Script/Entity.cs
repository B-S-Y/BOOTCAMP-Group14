using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody rb { get; private set; }
    public CapsuleCollider cc { get; private set; }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
    }
}
