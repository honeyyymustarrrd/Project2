using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //private Vector3 camRot;
    //private Transform camTransform;

    private Transform m_transform;
    public float moveSpeed = 5;
    // Start is called before the first frame update

    void Start()
    {
        m_transform = GetComponent<Transform>();
        //camTransform = Camera.main.transform;
    }

    // Update is called once per frame

    private void Update()
    {
        Control();
    }
    void Control()
    {
        //if (Input.GetMouseButton(0))
        {
            //float rh = Input.GetAxis("Mouse X");
            //float rv = Input.GetAxis("Mouse Y");
        }
        float xm = 0, ym = 0, zm = 0;
        if (Input.GetKey(KeyCode.W))
        {
            zm += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zm -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xm += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xm -= moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.Space) && m_transform. position. y <= 10)
        {
            ym += moveSpeed * Time.deltaTime;
        }
        m_transform. Translate (new Vector3(xm, ym, zm), Space. Self);
    }
}
