using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagnetCheckUnit : MonoBehaviour
{
    public Transform nearestUnit;
    [SerializeField]
    //private GameObject tPosition;
    private GameObject[] legions;//���еļ��е�Ԫ
    private GetCaught getCaught;
    private MagnetCheckUnit magnetCheckUnit;
    private SelfMove selfMove;
    private SelfRotate selfRotate;
    private bool isCaught = false;//�����Ƿ������ڱ�����״̬


    // Start is called before the first frame update
    void Start()
    {
        /*GameObject subParent = this.transform.GetChild(0).gameObject;
        measures = subParent.transform.GetChild;*/
        legions = GameObject.FindGameObjectsWithTag("Unit");
        getCaught = this.GetComponent<GetCaught>();
        magnetCheckUnit=this.GetComponent<MagnetCheckUnit>();
        selfMove = this.GetComponent<SelfMove>();
        selfRotate = this.transform.Find("Unit").GetComponent<SelfRotate>();
        //Debug.Log(legions.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * 1 * Time.deltaTime);
        /*//��������е�Ԫ��Ư�������
        for (int i = 0; i < legions.Length; i++)
        {
            Vector3 disV1 = legions[i].transform.position - this.transform.position;
            float disM1 = disV1.magnitude;
            Debug.Log(disM1);
            list.Add(disM1);
        }

        //�ҵ������Ԫ���ж���������Ƿ�ﵽ������Χ
        float minDis1 = list.Min();
        int indexM1 = list.IndexOf(minDis1);
        //legions[indexM];*/

        nearestUnit=GetNearestGameObject(this.gameObject.transform, legions);
        Vector3 minDisV1 = this.transform.position - nearestUnit.position;
        float minDisM1 = minDisV1.magnitude;
        if (minDisM1 <= 4f)
        {
            isCaught = true;
        }

        //����ﵽ������Χ����Ư���￪ʼ������
        if (isCaught)
        {
            getCaught.enabled = true;
            getCaught.targetObj = nearestUnit.gameObject;
            //Instantiate(tPosition, nearestUnit.position, Quaternion.identity);
            magnetCheckUnit.enabled = false;
            selfMove.enabled = false;
            selfRotate.enabled = false;
        }


        //Debug.Log(minDisM1);

    }

    Transform GetNearestGameObject(Transform currentFlotage, GameObject[] objects)
    {
        Transform nearestObject = objects[0].transform;
        float firstLength = Vector3.Distance(currentFlotage.position, objects[0].transform.position);
        
        for (int i = 1; i < objects.Length; i++)
        { 
            float length = Vector3.Distance(currentFlotage.position, objects[i].transform.position);
            if (firstLength > length)
            {
                firstLength = length;
                nearestObject = objects[i].transform;
            }
        }
 
        return nearestObject;
    }

}
