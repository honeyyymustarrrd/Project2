using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Player : MonoBehaviour
{
    public Rigidbody rd;

    public int score = 0;

    public Text scoreText;

    //public TMP_Text;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Game Start");
       //rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Game During");
        //Vector(Forward,Back,Left,Right)
        //rd.AddForce(new  Vector3(1,0,0) );

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(h);
        rd.AddForce(new Vector3(h, 0, v));
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Cracked");


        if  (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);

            score++;

            scoreText.text = "Score : " + score ;
        }
    }*/

    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Baam");
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("Safe");
    // }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.tag);

        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);

            score++;
            scoreText.text = "Score : " + score;
        }
    }

}
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("OnTriggerExit" + other.tag);
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("OnTriggerStay" + other.tag);
    //}

