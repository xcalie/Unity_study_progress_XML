using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class TestLesson3 : IXmlSerializable
{
    public int test1;
    public string test2 = "";


    //返回结构
    public XmlSchema GetSchema()
    {
        return null;
    }

    //反序列化的时候会自动调用
    public void ReadXml(XmlReader reader)
    {
        //在里面可以自定义反序列化的规则
        //1.读属性
        //test1 = int.Parse(reader["test1"]);
        //test2 = reader["test2"];

        //2.读节点
        //方式一
        //reader.Read();//这是读到teat1节点
        //reader.Read();//这是读到teat1包裹的内容
        //this.test1 = int.Parse(reader.Value);//得到当前的内容的值
        //reader.Read();//这是读到尾部节点
        //reader.Read();//这是读到teat2节点
        //reader.Read();//这是读到teat2包裹的内容
        //this.test2 = reader.Value;//得到当前的内容的值

        //方式二
        //while (reader.Read())
        //{
        //    if (reader.NodeType == XmlNodeType.Element)
        //    {
        //        switch (reader.Name)
        //        {
        //            case "test1":
        //                reader.Read();
        //                this.test1 = int.Parse(reader.Value);
        //                break;
        //            case "test2":
        //                reader.Read();
        //                this.test2 = reader.Value;
        //                break;
        //        }
        //    }
        //}


        //3.读包裹节点
        XmlSerializer s = new XmlSerializer(typeof(int));
        XmlSerializer s2 =new XmlSerializer(typeof(string));
        //跳过根节点
        reader.Read();
        reader.ReadStartElement("test1");
        test1 = (int)s.Deserialize(reader);
        reader.ReadEndElement();

        reader.ReadStartElement("test2");
        test2 = s2.Deserialize(reader).ToString();
        reader.ReadEndElement();
    }

    //序列化的时候会自动调用
    public void WriteXml(XmlWriter writer)
    {
        //在里面可以自定义序列化的规则

        //如果要自定义 序列化规则 一定会用到 XmlWriter中的一些方法 来进行序列化
        //1.写属性
        //writer.WriteAttributeString("test1", test1.ToString());
        //writer.WriteAttributeString("test2", test2);

        //2.写节点
        //writer.WriteElementString("test1", test1.ToString());
        //writer.WriteElementString("test2", test2);

        //2.写包裹节点
        XmlSerializer s = new XmlSerializer(typeof(int));
        writer.WriteStartElement("test1");
        s.Serialize(writer, test1);
        writer.WriteEndElement();

        XmlSerializer s2 = new XmlSerializer(typeof(string));
        writer.WriteStartElement("test2");
        s2.Serialize(writer, test2);
        writer.WriteEndElement();
    }
}


public class IXmlSerializableLesson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region IXmlSerializable能做什么

        //C#中的XmlSerializer提供了可扩展的内容
        //可以让一些不能被序列化和反序列化的类也能够被特殊处理
        //让特殊类继承IXmlSerializable接口 实现方法即可

        #endregion

        #region 自定义类实践

        TestLesson3 test = new TestLesson3();
        test.test2 = "Hello World";

        string path = Application.persistentDataPath + "/TestLesson3.xml";
        print(path);

        using (StreamWriter writer = new StreamWriter(path))
        {
            XmlSerializer s = new XmlSerializer(typeof(TestLesson3));
            s.Serialize(writer, test);
        }

        TestLesson3 testR;

        using (StreamReader reader = new StreamReader(path))
        {
            XmlSerializer s = new XmlSerializer(typeof(TestLesson3));
            testR = s.Deserialize(reader) as TestLesson3;
        }

        #endregion
    }
}
