using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{

    public Cylinder cylinder;
    public Transform cubePositon;
    //public GameObject cylinder;
    private Cylinder _gameObjectIntern;
    private Cylinder _gameObjectLast;
    List<Cylinder> cubesList = new List<Cylinder>();
    public int Lenght = 10;
    public bool needConfiguration = true;
   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Lenght; i++)
        {
            var position = cubePositon.position;
            position =
                new Vector3(position.x + 1.35f, position.y, position.z);
            cubePositon.position = position;
            _gameObjectIntern = Instantiate(cylinder, cubePositon);
            cubesList.Add(_gameObjectIntern);
        }
    }

    public void Movements()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x, cubesList[0].transform.position.y + 1f, cubesList[0].transform.position.z);
            ///cubesList[cubesList.Count - 1].GetComponent<Rigidbody>().isKinematic = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x, cubesList[0].transform.position.y - 1f, cubesList[0].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x + 1f, cubesList[0].transform.position.y, cubesList[0].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cubesList[0].transform.position = new Vector3(cubesList[0].transform.position.x - 1f, cubesList[0].transform.position.y, cubesList[0].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            cubesList[cubesList.Count - 1].transform.position = new Vector3(cubesList[cubesList.Count - 1].transform.position.x, cubesList[cubesList.Count - 1].transform.position.y + 1f, cubesList[cubesList.Count - 1].transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            cubesList[cubesList.Count - 1].transform.position = new Vector3(cubesList[cubesList.Count - 1].transform.position.x, cubesList[cubesList.Count - 1].transform.position.y - 1f, cubesList[cubesList.Count - 1].transform.position.z);
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if (needConfiguration)
        {
            cubesList[0].GetComponent<Rigidbody>().isKinematic = true;
            cubesList[cubesList.Count - 1].GetComponent<Rigidbody>().isKinematic = true;
            for (int i = 0; i < Lenght; i++)
            {
                if (i < Lenght - 1)
                {
                    cubesList[i + 1].GetComponent<FixedJoint>().connectedBody = cubesList[i].GetComponent<Rigidbody>();
                }
            }
            needConfiguration = false;
        }

        //OnMouseDown();
        //Config(List<Cylinder> cubesList);
        Movements();

        if (Input.GetKeyDown(KeyCode.R))
        {
            cubesList[0].transform.rotation = Quaternion.Euler(cubesList[0].transform.rotation.x, cubesList[0].transform.rotation.y, cubesList[0].transform.rotation.z + 15f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            cubesList[0].transform.rotation = Quaternion.Euler(cubesList[0].transform.rotation.x, cubesList[0].transform.rotation.y, cubesList[0].transform.rotation.z - 15f);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            cubesList[cubesList.Count - 1].transform.rotation = Quaternion.Euler(cubesList[cubesList.Count - 1].transform.rotation.x, cubesList[cubesList.Count - 1].transform.rotation.y, cubesList[cubesList.Count - 1].transform.rotation.z + 15f);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            cubesList[cubesList.Count - 1].transform.rotation = Quaternion.Euler(cubesList[cubesList.Count - 1].transform.rotation.x, cubesList[cubesList.Count - 1].transform.rotation.y, cubesList[cubesList.Count - 1].transform.rotation.z - 15f);
        }
    }
}

