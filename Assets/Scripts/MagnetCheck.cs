using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagnetCheck : MonoBehaviour
{
    private GameObject[] legions;//���еļ��е�Ԫ
    private Transform[] tempFaces;//�����Ԫ������������
    private List<Transform> faceList;//�����Ԫ��������
    private List<float> list;//Ư����������е�Ԫ�ľ���
    private List<float> tempDis;//Ư�����������Ԫ����ľ���
    private int _indexM;//�����Ԫ�ı��
    private float scale=0.5f;
    private bool isCaught = false;//�����Ƿ������ڱ�����״̬

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject subParent = this.transform.GetChild(0).gameObject;
        measures = subParent.transform.GetChild;*/
    }

    // Update is called once per frame
    void Update()
    {
        legions = GameObject.FindGameObjectsWithTag("Unit");

        //��������е�Ԫ��Ư�������
        for (int i = 0; i < legions.Length; i++)
        {
            Vector3 disV1 = legions[i].transform.position - this.transform.position;
            float disM1 = disV1.magnitude;
            list.Add(disM1);
        }

        //�ҵ������Ԫ���ж���������Ƿ�ﵽ������Χ
        float minDis1 = list.Min();
        int indexM1 = list.IndexOf(minDis1);
        //legions[indexM];
        if (minDis1 <= 5f)
        {
            isCaught = true;
        }

        //����ﵽ������Χ����Ư���￪ʼ������
        if (isCaught)
        {
            _indexM = indexM1;
            GetCaught();
        }


    }
    
    void GetCaught()
    {
        //�ҵ������Ԫ��������
        GameObject targetObj = legions[_indexM];
        Transform sub = targetObj.transform.GetChild(0);
        tempFaces = sub.GetComponentsInChildren<Transform>();
        foreach (Transform item1 in tempFaces)
        {
            if (item1.tag=="Unit")
            {
                faceList.Add(item1);
            }
        }
        foreach (Transform item2 in faceList)
        {
            Vector3 disV2 = item2.transform.position - this.transform.position;
            float disM2 = disV2.magnitude;
            tempDis.Add(disM2);
        }

        //�ҵ������theFace
        float minDis2 = tempDis.Min();
        int indexM2 = tempDis.IndexOf(minDis2);
        Transform theFace = faceList[indexM2];

        //��Ư��������������������ķ���һ������������ཻ���Ӷ�ȷ�������ķ���
        Vector3 rayD = this.transform.position - targetObj.transform.position;
        float rayM = rayD.magnitude;
        int magLayerMask = 1;
        RaycastHit hit;
        Vector3 pos = Vector3.zero;
        if (Physics.Raycast(this.transform.position,rayD.normalized,out hit,rayM, magLayerMask))
        {
            pos = hit.transform.position + hit.normal * scale;
        }
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.identity, Time.deltaTime);
    }
}
