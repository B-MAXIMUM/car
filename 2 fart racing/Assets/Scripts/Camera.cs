using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Following;
    public float Offset = 6.15f;
    private Car _carscript;
    void Start()
    {
        _carscript = GameObject.Find("car").GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_carscript.Done())
        {
            transform.position = new Vector3(0f, Following.transform.position.y + Offset, -10f);
        }
    }
}
