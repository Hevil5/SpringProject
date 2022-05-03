using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private int numberFactor;
    private NeighboursCount nb;
    // Start is called before the first frame update
    void Start()
    {
        
        nb = this.transform.parent.GetComponentInChildren<NeighboursCount>();
    }

    // Update is called once per frame
    void Update()
    {
        numberFactor = nb.numberOfNeighbours;
        if (numberFactor<=2&& numberFactor >1)
        {
            this.transform.GetChild(3).GetChild(0).GetComponent<Renderer>().enabled=false;
            this.transform.GetChild(3).GetChild(1).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(2).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(3).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(4).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(5).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(6).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(7).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(8).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(9).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(10).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(11).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(12).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(3).GetChild(13).GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (numberFactor > 2)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
        }

    }
}
