using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public Cylinder cylinder;
    public Transform cubePositon;
    //public GameObject cylinder;
    private Cylinder _gameObjectIntern;
    private Cylinder _gameObjectLast;
    List<Cylinder> cubesList = new List<Cylinder>();
    public Boolean needConfiguration = true;
    private int numbersOfCubes = 15;
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < numbersOfCubes; i++)
        {
            var position = cubePositon.position;
            position =
                new Vector3(position.x + 5, position.y, position.z);
            cubePositon.position = position;
            _gameObjectIntern = Instantiate(cylinder, cubePositon);
            cubesList.Add(_gameObjectIntern);
        }
    }

    void Update()
    {
        if (needConfiguration)
        {
            for (int i = 0; i < numbersOfCubes; i++)
            {
                if (i < numbersOfCubes - 1)
                {
                    cubesList[i + 1].GetComponent<FixedJoint>().connectedBody = cubesList[i].GetComponent<Rigidbody>();
                }
            }
            needConfiguration = false;
        }
    }
}
