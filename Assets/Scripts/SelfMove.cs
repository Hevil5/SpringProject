using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public GameObject boundaryBox;
    // Start is called before the first frame update
    void Start()
    {
        boundaryBox = GameObject.FindGameObjectWithTag("BoundaryBox");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //Debug.Log(this.transform.position.x);
        if (this.transform.position.x<=(-boundaryBox.transform.localScale.x/2f))
        {
            Destroy(this.gameObject);
        }
    }
}
