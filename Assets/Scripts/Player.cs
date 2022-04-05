using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float A = 0f;
    public float B = 1f;

    [Range(0,1)]
    public float T = 0.5f;

    private Vector3 move = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float lerp = Mathf.Lerp(A, B, T);
        //Vector3 forward = this.transform.forward;
        //Vector3 move = forward * 0.1f;
        float angle = 0f;
        float speed = 0f;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed = -0.1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed= 0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle-= 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle+= 1f;
        }
        Vector3 move = this.transform.forward * speed;
        //this.transform.forward = forward;
        this.transform.Rotate(Vector3.up, angle);
        //this.transform.position += move;
        this.transform.Translate(move);
        //Debug.Log(T);
    }
}
