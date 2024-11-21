using UnityEngine;
using UnityEngine.Events;

public class AccelerationClickable : MonoBehaviour
{
    [SerializeField]
    private Clickable _clickable;

    [SerializeField]
    private float _shakeThreshold = 1.5f;

    [Min(0.0001f)]
    [SerializeField]
    private float _shakeCooldown = 0.5f;

    private float _lastShakeTime;

    private Vector3 _previousAcceleration;

    private float _lastFrameTime;

    public UnityEvent<int> OnShaked;

    private void Start()
    {
        _previousAcceleration = Input.acceleration;

        _lastFrameTime = Time.time;
    }

    private void Update()
    {
        Vector3 currentAcceleration = Input.acceleration;

        Vector3 accelerationChange = currentAcceleration - _previousAcceleration;

        float shakeForce = Mathf.Abs(accelerationChange.x) + Mathf.Abs(accelerationChange.y);

        if (shakeForce > _shakeThreshold)
        {
            if (Time.time - _lastShakeTime > _shakeCooldown)
            {
                _lastShakeTime = Time.time;

                OnShaked?.Invoke(_clickable.BaseClick);
            }
        }

        _previousAcceleration = currentAcceleration;

        _lastFrameTime = Time.time;
    }
}