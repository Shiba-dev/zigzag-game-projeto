using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreatorController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _lastPos;
    [SerializeField]
    private float _tam;
    [SerializeField]
    private GameObject _ground;

    private GroundController _groundControllerScript;

    void Start()
    {
        int k = 0;

        _ground = GameObject.Find("Ground");

        _groundControllerScript = GameObject.FindObjectOfType(typeof(GroundController)) as GroundController;

        _lastPos = _ground.transform.position;
        _tam = _ground.transform.localScale.x;

        StartCoroutine(CheckToCreateGround());
    }

    void Update()
    {
        print(_groundControllerScript.GroundTrigger);
    }

    void CreateGround(int i)
    {
        Vector3 m_tempPos = _lastPos;
        if (i == 1)
        {
            m_tempPos.x += _tam;
        }
        else
        {
            m_tempPos.z += _tam;
        }
        _lastPos = m_tempPos;
        Instantiate(_ground, m_tempPos, Quaternion.identity);
    }

    void RandomizeGroundCreation()
    {
        int t = Random.Range(0, 2);

        CreateGround(t);
    }

    IEnumerator CheckToCreateGround()
    {
        while (!BallController._isGameOver)
        {
            yield return new WaitForSeconds(0.5f);
            RandomizeGroundCreation();

        }
    }
}
