using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCaught : MonoBehaviour
{
    public GameObject targetObj;
    private Transform unit;
    private float scale;
    private Vector3 rayD;
    private float rayM;
    private RaycastHit hit;
    private Vector3 pos;
    private TrailRenderer trail;
    private SetUnit su;
    private MagnetCheckUnit mcu;

    private void Start()
    {
        unit = this.transform.GetChild(3);
        //��Ư��������������������ķ���һ������������ཻ���Ӷ�ȷ�������ķ���
        rayD = targetObj.transform.position- this.transform.position;
        rayM = rayD.magnitude;
        trail = this.GetComponent<TrailRenderer>();
        mcu = this.GetComponent<MagnetCheckUnit>();
        su = this.GetComponent<SetUnit>();
        //Debug.DrawRay(this.transform.position, rayD.normalized*rayM, Color.blue);
        if (Physics.Raycast(this.transform.position, rayD.normalized, out hit, rayM))
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.name.Contains("Square"))
            {
                scale = 0.58f;
            }
            if (hit.transform.gameObject.name.Contains("Hexagon"))
            {
                scale = 0.5023f;
            }
            pos = hit.transform.position + hit.normal * scale;
        }
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime*4);
        unit.rotation = Quaternion.Lerp(unit.rotation, Quaternion.identity, Time.deltaTime*5f);
        Vector3 checkD = hit.transform.position - this.transform.position;
        float checkM = checkD.magnitude;
        //Debug.Log(checkM);
        if (checkM <= 0.6f)
        {
            mcu.su.isBusy = false;
            this.transform.position = pos;
            unit.rotation = Quaternion.identity;
            unit.gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.gameObject.tag = "Unit";
            targetObj.tag = "Unit";
            su.enabled = true;
            this.enabled = false;
            //trail.enabled = true;
        }

    }

}
