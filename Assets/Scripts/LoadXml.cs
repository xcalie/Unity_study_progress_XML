using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadXml : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //C#读取XML的方法有几种
        //1.XmlDocument     (把数据加载到内存中，方便读取)
        //2.XmlTextReader   (流式加载，内存占用更少，但是单向只读，使用不方便，一般不使用)
        //3.Linq            (用Linq专用写法)

        //XmlDocument是最方便且最容易操作的读法
        #region 读取xml文件

        XmlDocument xml = new XmlDocument();
        //通过xmlDocument对象加载xml文件有两个API
        //存放在Resources文件夹下的xml文件
        TextAsset asset = Resources.Load<TextAsset>("TestXML");
        print(asset.text);
        //1通过这个API翻译xml文件
        xml.LoadXml(asset.text);

        //2通过路径加载xml文件
        //xml.Load(Application.streamingAssetsPath + "/TestXML.xml");

        #endregion

        #region 读取元素和属性信息

        //节点信息类
        //xmlNode 单个节点信息类
        //节点列表信息类
        //xmlNodeList 多个节点信息类

        //获取Root根节点
        XmlNode root = xml.SelectSingleNode("Root");

        //再获取根节点下的所有子节点
        XmlNode nodeName = root.SelectSingleNode("name");
        print(nodeName.InnerText);

        XmlNode nodeAge = root.SelectSingleNode("age");
        print(nodeAge.InnerText);

        XmlNode nodeItem = root.SelectSingleNode("Item");
        //第一种方向直接通过[]获取信息(主使用)
        print(nodeItem.Attributes["id"].Value);
        print(nodeItem.Attributes["num"].Value);
        //第二种方向通过getAttributes获取信息
        print(nodeItem.Attributes.GetNamedItem("id").Value);
        print(nodeItem.Attributes.GetNamedItem("num").Value);

        //获取List节点
        XmlNodeList friendList = root.SelectNodes("Friend");

        //遍历方式一
        foreach (XmlNode item in friendList)
        {
            print(item.SelectSingleNode("name").InnerText);
            print(item.SelectSingleNode("age").InnerText);
        }

        //遍历方式二
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
