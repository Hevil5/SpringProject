using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private int numberFactor;
    private NeighboursCount nb;
    private DetectClearFace dcf;
    [SerializeField]
    private Material[] lcMat;

    private MeshRenderer[] core;
    // Start is called before the first frame update
    void Start()
    {
        
        nb = this.transform.parent.GetComponentInChildren<NeighboursCount>();
        dcf = this.transform.parent.GetComponentInChildren<DetectClearFace>();
        core = this.transform.GetChild(2).GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        numberFactor = nb.numberOfNeighbours;
        if (dcf.clearFace)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }


        if (numberFactor >=0 && numberFactor < 3)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[0];
            }
        }
        else if (numberFactor >= 3 && numberFactor < 6)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[1];
            }
        }
        else if (numberFactor >= 6 && numberFactor < 9)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[2];
            }
        }
        else if (numberFactor >= 9 && numberFactor < 12)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[3];
            }
        }
        else if (numberFactor >= 12 && numberFactor < 15)
        {
            for (int i = 0; i < core.Length; i++)
            {
                core[i].material = lcMat[4];
            }
        }

    }
}
