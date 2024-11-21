using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SaveXml : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 决定可以存储在哪个文件夹下

        //注意:存储xml文件 在unity中一定是使用各个平台都可读可写的路径
        // 1.Resources 可读 不可写 打包后找不到 x
        // 2.Application.streamingAssetsPath 可读 PC可写 打包后找不到 x
        // 3.Application.dataPath 打包后找不到 x
        // 4.Application.persistentDataPath 可读可写 打包后找得到 √

        string path = Application.persistentDataPath + "/PlayerInfo2.xml";
        print(Application.persistentDataPath);

        #endregion

        #region 存储xml文件

        //关键类 XmlDocument 用于创造节点 存储文件
        //关键类 XmlDeclaration 用于声明xml文件的版本和编码
        //关键类 XmlElement 用于创建节点

        //存储有五步
        //1.创建文本对象
        XmlDocument xml = new XmlDocument();
        //2.添加固定版本信息
        XmlDeclaration xmlDec = xml.CreateXmlDeclaration("1.0", "utf-8", "");
        //创建完成过后 添加到xml文档中
        xml.AppendChild(xmlDec);

        //3.添加根节点
        XmlElement root = xml.CreateElement("Root");
        xml.AppendChild(root);

        //4.为根节点添加子节点
        XmlElement name = xml.CreateElement("name");
        name.InnerText = "XC";
        root.AppendChild(name);

        XmlElement atk = xml.CreateElement("atk");
        atk.InnerText = "10";
        root.AppendChild(atk);

        XmlElement def = xml.CreateElement("def");
        def.InnerText = "5";
        root.AppendChild(def);

        XmlElement listInt = xml.CreateElement("listInt");
        for (int i = 1; i <= 3; i++)
        {
            XmlElement childNode = xml.CreateElement("int");
            childNode.InnerText = i.ToString();
            listInt.AppendChild(childNode);
        }
        root.AppendChild(listInt);

        XmlElement itemList = xml.CreateElement("itemlist");
        for (int i = 1; i <= 3; i++)
        {
            XmlElement childNode = xml.CreateElement("Item");
            //添加属性
            childNode.SetAttribute("id", i.ToString());
            childNode.SetAttribute("num", (i * 10).ToString());
            itemList.AppendChild(childNode);
        }
        root.AppendChild(itemList);

        //5.保存
        xml.Save(path);

        #endregion

        #region 修改xml文件

        //1先判断是否存在文件
        if (File.Exists(path))
        {
            //2.加载xml文件 直接添加节点 移除节点即可
            XmlDocument newXml = new XmlDocument();
            newXml.Load(path);
            //得到根节点
            XmlNode root2 = newXml.SelectSingleNode("Root");

            //修改就是在原有文件的基础上 去移除 或者添加
            //移除

            //简便写法 通过/区分父子关系
            XmlNode node = newXml.SelectSingleNode("Root/atk");;// = newXml.SelectSingleNode("Root").SelectSingleNode("atk");
            //移除子节点
            root2.RemoveChild(node);

            //添加节点
            XmlElement speed = newXml.CreateElement("moveSpeed");
            speed.InnerText = "5";
            root2.AppendChild(speed);

            //改了记得保存
            newXml.Save(path);

        }

        #endregion

        #region

        // 路径选取
        // Application.persistentDataPath + "/PlayerInfo2.xml"

        // 储存xml关键类
        // 创建文件XmlDocument
        //      创建节点CreateElement
        //      创建版本编码信息CreateXmlDeclaration
        //      添加节点AppendChild
        //      保存Save
        // 添加版本编码信息XmlDeclaration
        // 创建元素节点XmlElement
        //      设置属性SetAttribute

        // 修改xml文件
        // RemoveChild 移除节点

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
