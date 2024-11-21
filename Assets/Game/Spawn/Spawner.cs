using UnityEngine;
using NTC.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform _root;

    [SerializeField]
    private Vector3 _maxOffset;

    [SerializeField]
    private AnimatedText _animatedText;

    private Camera _camera;

    private int _lastValue = 0;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void SetLastValue(int value)
    {
        _lastValue = value;
    }

    public void Spawn()
    {
        AnimatedText animatedText = Instantiate(_animatedText, _root);

        Vector3 position = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x, _camera.ScreenToWorldPoint(Input.mousePosition).y, 0);//берется позиция мыши

        animatedText.gameObject.transform.position = position;

        animatedText.Init(_lastValue);
    }

    public void SpawnAcceleration()
    {
        AnimatedText animatedText = Instantiate(_animatedText, _root);

        animatedText.gameObject.transform.position = Vector3.zero;//при тряске телефона позиция нулевая

        animatedText.Init(_lastValue);
    }
}