using UnityEngine;

public class Mover : MonoBehaviour
{
    private Transform _pointToGo;
    private Transform[] _points;
    private float _speed;
    private int _indexInArray;

    private void Start()
    {
        _points = new Transform[_pointToGo.childCount];

        for (int i = 0; i < _pointToGo.childCount; i++)
        {
            _points[i] = _pointToGo.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform pointToGo = _points[_indexInArray];
        transform.position = Vector3.MoveTowards(transform.position, pointToGo.position, _speed * Time.deltaTime);

        if (transform.position == pointToGo.position)
        {
            GetNextPoint();
        }
    }

    private Vector3 GetNextPoint()
    {
        _indexInArray++;

        if (_indexInArray == _points.Length)
        {
            _indexInArray = 0;
        }

        var newPoint = _points[_indexInArray].transform.position;
        transform.forward = newPoint - transform.position;

        return newPoint;
    }
}