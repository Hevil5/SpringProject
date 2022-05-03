using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagnetCheckSurface : MonoBehaviour
{
    private GameObject[] faces;//���еļ�����
    private Transform[] tempFaces;//�����Ԫ������������
    private List<Transform> faceList;//�����Ԫ��������
    private List<float> list;//Ư����������е�Ԫ�ľ���
    private List<float> tempDis;//Ư�����������Ԫ����ľ���
    private int _indexM;//�����Ԫ�ı��
    private float scale = 0.5f;
    private bool IBC = false;//�����Ƿ������ڱ�����״̬

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject subParent = this.transform.GetChild(0).gameObject;
        measures = subParent.transform.GetChild;*/
        faces = GameObject.FindGameObjectsWithTag("UnitFace");
    }

    // Update is called once per frame
    void Update()
    {

        //�������������Ư�������
        for (int i = 0; i < faces.Length; i++)
        {
            Vector3 disV1 = faces[i].transform.position - this.transform.position;
            float disM1 = disV1.magnitude;
            list.Add(disM1);
        }

        //�ҵ�����沢�ж���������Ƿ�ﵽ������Χ
        float minDis1 = list.Min();
        int indexM1 = list.IndexOf(minDis1);
        //theFace = faces[indexM1];
        
        if (minDis1 <= 5f)
        {
            IBC = true;
        }

        //����ﵽ������Χ����Ư���￪ʼ������
        if (IBC)
        {
            _indexM = indexM1;
            GetCaught();
        }


    }

    void GetCaught()
    {
        //����漰�����ڵ�Ԫ
        GameObject theFace = faces[_indexM];
        GameObject targetObj = faces[_indexM].transform.root.gameObject;
        
        //��Ư��������������������ķ���һ������������ཻ���Ӷ�ȷ�������ķ���
        Vector3 rayD = this.transform.position - theFace.transform.position;
        float rayM = rayD.magnitude;
        //int magLayerMask = 1;
        RaycastHit hit;
        Vector3 pos = Vector3.zero;
        if (Physics.Raycast(this.transform.position, rayD.normalized, out hit, rayM))
        {
            pos = hit.transform.position + hit.normal * scale;
        }
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.identity, Time.deltaTime);
    }
}
