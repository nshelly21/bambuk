using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    void OnMouseDown()
    {
        cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x  - 1f, cubesList[0].transform.position.y, cubesList[0].transform.position.z);
    }
    
    public Cylinder cylinder;
    public Transform cubePositon;
    //public GameObject cylinder;
    private Cylinder _gameObjectIntern;
    private Cylinder _gameObjectLast;
    List<Cylinder> cubesList = new List<Cylinder>();
    public Boolean needConfiguration = true;
    private int numbersOfCubes = 10;
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < numbersOfCubes; i++)
        {
            var position = cubePositon.position;
            position =
                new Vector3(position.x + 1.35f , position.y, position.z);
            cubePositon.position = position;
            _gameObjectIntern = Instantiate(cylinder, cubePositon);
            cubesList.Add(_gameObjectIntern);
        }
    }

    public void Movements()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x , cubesList[0].transform.position.y + 1f, cubesList[0].transform.position.z);
            ///cubesList[cubesList.Count - 1].GetComponent<Rigidbody>().isKinematic = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x , cubesList[0].transform.position.y - 1f, cubesList[0].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x  + 1f , cubesList[0].transform.position.y, cubesList[0].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x  - 1f, cubesList[0].transform.position.y, cubesList[0].transform.position.z);
        }
    }

    void Update()
    {
        if (needConfiguration)
        {
            cubesList[0].GetComponent<Rigidbody>().isKinematic = true;
            cubesList[cubesList.Count - 1].GetComponent<Rigidbody>().isKinematic = true;
            for (int i = 0; i < numbersOfCubes; i++)
            {
                if (i < numbersOfCubes)
                {
                    if (i > 0)
                        cubesList[i].GetComponent<HingeJoint>().connectedBody = cubesList[i- 1].GetComponent<Rigidbody>();
                    //cubesList[i].GetComponent<HingeJoint>().breakForce = 20f;
                    if (i % 3 != 0)
                    {
                        Debug.Log("Destroy");
                        cubesList[i].GetComponent<Rigidbody>().useGravity = false;
                        Destroy(cubesList[i].GetComponent<FixedJoint>());
                    }
                    else
                    {
                        if (i != 0)
                        {
                            cubesList[i].GetComponent<FixedJoint>().connectedBody = cubesList[i - 3].GetComponent<Rigidbody>();
                            cubesList[i].GetComponent<FixedJoint>().breakForce = 20f;
                        }
                    }
                }
            }
            needConfiguration = false;
        }

        //OnMouseDown();
        //Config(List<Cylinder> cubesList);
        Movements();
    }
}
