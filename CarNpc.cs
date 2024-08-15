using UnityEngine;

public class CarNpc : MonoBehaviour
{
    [SerializeField] Transform[] turnPoint;

    private int speed = 10, turnPointIndex;
    private float distance;

    void Start()
    {
        turnPointIndex = 0;
        transform.LookAt(turnPoint[turnPointIndex].position);
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance
        (transform.position, turnPoint[turnPointIndex].position);
        if (distance < 1)
        {
            IncreaseIndex();
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        turnPointIndex++;
        if (turnPointIndex >= turnPoint.Length)
        {
            turnPointIndex = 0;
        }
        transform.LookAt(turnPoint[turnPointIndex].position);
    }
}