using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFloatage : MonoBehaviour
{
    private float coordX;
    private float coordY;
    private float coordZ;
    [SerializeField]
    private float MakeRate;
    private float _lastMake = 0f;
    private int _makeCount;

    [SerializeField]
    private GameObject flotage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _lastMake += Time.deltaTime; 
        if (_lastMake > MakeRate)
        {
            coordY = Random.Range(-this.transform.localScale.y / 2, this.transform.localScale.y / 2);
            coordZ= Random.Range(-this.transform.localScale.z / 2, this.transform.localScale.z / 2);
            _lastMake = 0f; 
            _makeCount++; 
            //Debug.Log("Make");
            GameObject go = Instantiate(flotage, new Vector3(this.transform.localScale.x / 2, coordY, coordZ), Quaternion.identity);
            /*Bus mu = go.GetComponent<Bus>();
            mu.Target = Target1;*/
            /*if (_makeCount>=1)
            {
                this.enabled = false;
            }*/
        }
        
    }
}
