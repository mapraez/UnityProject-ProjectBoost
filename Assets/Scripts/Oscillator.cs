using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(-1, 1)] float movementFactor;
    [SerializeField] float frequency = 8f;

    public bool fullOrHalf = true;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        // Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (frequency <= Mathf.Epsilon) { return; }
        float cycles = Time.time / frequency; // continuously grows over time
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        if (fullOrHalf)
        {
            movementFactor = rawSinWave; //starting position is center
        }
        else
        {
            movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go 0 to 1
        }

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
