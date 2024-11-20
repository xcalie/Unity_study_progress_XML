using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadXml : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //C#��ȡXML�ķ����м���
        //1.XmlDocument     (�����ݼ��ص��ڴ��У������ȡ)
        //2.XmlTextReader   (��ʽ���أ��ڴ�ռ�ø��٣����ǵ���ֻ����ʹ�ò����㣬һ�㲻ʹ��)
        //3.Linq            (��Linqר��д��)

        //XmlDocument������������ײ����Ķ���
        #region ��ȡxml�ļ�

        XmlDocument xml = new XmlDocument();
        //ͨ��xmlDocument�������xml�ļ�������API
        //�����Resources�ļ����µ�xml�ļ�
        TextAsset asset = Resources.Load<TextAsset>("TestXML");
        print(asset.text);
        //1ͨ�����API����xml�ļ�
        xml.LoadXml(asset.text);

        //2ͨ��·������xml�ļ�
        //xml.Load(Application.streamingAssetsPath + "/TestXML.xml");

        #endregion

        #region ��ȡԪ�غ�������Ϣ

        //�ڵ���Ϣ��
        //xmlNode �����ڵ���Ϣ��
        //�ڵ��б���Ϣ��
        //xmlNodeList ����ڵ���Ϣ��

        //��ȡRoot���ڵ�
        XmlNode root = xml.SelectSingleNode("Root");

        //�ٻ�ȡ���ڵ��µ������ӽڵ�
        XmlNode nodeName = root.SelectSingleNode("name");
        print(nodeName.InnerText);

        XmlNode nodeAge = root.SelectSingleNode("age");
        print(nodeAge.InnerText);

        XmlNode nodeItem = root.SelectSingleNode("Item");
        //��һ�ַ���ֱ��ͨ��[]��ȡ��Ϣ(��ʹ��)
        print(nodeItem.Attributes["id"].Value);
        print(nodeItem.Attributes["num"].Value);
        //�ڶ��ַ���ͨ��getAttributes��ȡ��Ϣ
        print(nodeItem.Attributes.GetNamedItem("id").Value);
        print(nodeItem.Attributes.GetNamedItem("num").Value);

        //��ȡList�ڵ�
        XmlNodeList friendList = root.SelectNodes("Friend");

        //������ʽһ
        foreach (XmlNode item in friendList)
        {
            print(item.SelectSingleNode("name").InnerText);
            print(item.SelectSingleNode("age").InnerText);
        }

        //������ʽ��
        for (int i = 0; i < friendList.Count; i++)
        {
            print(friendList[i].SelectSingleNode("name").InnerText);
            print(friendList[i].SelectSingleNode("age").InnerText);
        }

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
