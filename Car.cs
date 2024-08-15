using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] WheelCollider
    colliderFL, colliderFR, colliderRL, colliderRR;
    [SerializeField] Transform
    meshFL, meshFR, meshRL, meshRR;
    [SerializeField] Transform cemterOfMass;
    [SerializeField] float motorTorque;
    [SerializeField] float maxSteer;

    private Rigidbody rb;
    private AudioSource audioSource;

    private int steerInput;
    private int torqueInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = cemterOfMass.localPosition;

        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        colliderRL.motorTorque = torqueInput * motorTorque;
        colliderRR.motorTorque = torqueInput * motorTorque;
        colliderFL.steerAngle = steerInput * maxSteer;
        colliderFR.steerAngle = steerInput * maxSteer;
    }

    private void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        colliderFL.GetWorldPose(out pos, out rot);
        meshFL.position = pos;
        meshFL.rotation = rot;

        colliderFR.GetWorldPose(out pos, out rot);
        meshFR.position = pos;
        meshFR.rotation = rot;

        colliderRL.GetWorldPose(out pos, out rot);
        meshRL.position = pos;
        meshRL.rotation = rot;

        colliderRR.GetWorldPose(out pos, out rot);
        meshRR.position = pos;
        meshRR.rotation = rot;
    }

    public void Tourque(int value)
    {
        torqueInput = value;
    }

    public void Steer(int value)
    {
        steerInput = value;
    }
}