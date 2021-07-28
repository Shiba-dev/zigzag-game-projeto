using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform _targetTransform;
    [SerializeField]
    private Vector3 _dif;
    [SerializeField]
    private float _smooth;
    [SerializeField]
    private Vector3 _camPos, _targetPos;

    void Start()
    {
        if (_targetTransform == null)
        {
            _targetTransform = GameObject.Find("Ball").GetComponent<Transform>();
        }

        _dif = _targetTransform.position - transform.position;
    }

    private void LateUpdate()
    {
        if (!BallController._isGameOver)
        {
            SmoothFunction();
        }
    }

    void SmoothFunction()
    {
        _targetPos = _targetTransform.position - _dif;
        _camPos = Vector3.Lerp(transform.position, _targetPos, _smooth);
        transform.position = _camPos;
    }
}
