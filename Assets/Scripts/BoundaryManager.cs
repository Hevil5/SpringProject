using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoundaryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        int unitsCount = units.Length;
        float scaleX = Mathf.Pow(unitsCount, (1f / 3f));
        int scaleFactor = (int)scaleX;
        if (scaleFactor >= 2)
        {
            transform.localScale = new Vector3(10, 10, 10) * scaleFactor;
        }
        /*int scaleFactor = unitsCount / 15;
        if (scaleFactor>=2)
        {
            transform.localScale= new Vector3(10, 10, 10) * scaleFactor;
        }*/
    }
}
