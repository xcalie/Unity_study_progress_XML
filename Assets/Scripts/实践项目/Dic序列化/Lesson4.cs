using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Lesson4Test
{
    public int test1;
    
    public SerializerDictionary<int, string> dic;
}

public class Lesson4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 如何让Dictionary支持xml的序列化

        //1.没有办法修改C#自带的类
        //2.可以重写一个类，继承Dictionary，然后实现ISerializable接口
        //3.使用XmlSerializer序列化和反序列化

        #endregion

        #region 让Dictionary支持xml的序列化和反序列化

        //Lesson4Test test = new Lesson4Test();
        //test.test1 = 100;
        //test.dic = new SerializerDictionary<int, string>();
        //test.dic.Add(1, "111");
        //test.dic.Add(2, "222");
        //test.dic.Add(3, "333");

        string path = Application.persistentDataPath + "/Lesson4Test.xml";

        //using (StreamWriter writer = new StreamWriter(path))
        //{
        //    XmlSerializer x = new XmlSerializer(typeof(Lesson4Test));
        //    x.Serialize(writer, test);
        //}

        Lesson4Test test;

        using (StreamReader reader = new StreamReader(path))
        {
            XmlSerializer x = new XmlSerializer(typeof(Lesson4Test));
            test = x.Deserialize(reader) as Lesson4Test;
        }

        #endregion
    }

}
