using UnityEngine;

public class Mover : MonoBehaviour
{
    private int _indexInPoints;
    private float _speed;
    private Transform _pointToGo;
    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[_pointToGo.childCount];

        for (int i = 0; i < _pointToGo.childCount; i++)
        {
            _points[i] = _pointToGo.GetChild(i);
        }
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        Transform pointToGo = _points[_indexInPoints];
        transform.position = Vector3.MoveTowards(transform.position, pointToGo.position, _speed * Time.deltaTime);

        if (transform.position == pointToGo.position)
        {
            ChooseNextPoint();
        }
    }

    private Vector3 ChooseNextPoint()
    {
        _indexInPoints++;

        if (_indexInPoints == _points.Length)
        {
            _indexInPoints = 0;
        }

        var newPoint = _points[_indexInPoints].transform.position;
        transform.forward = newPoint - transform.position;

        return newPoint;
    }
}