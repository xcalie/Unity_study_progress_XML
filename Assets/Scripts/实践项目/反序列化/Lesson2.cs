using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 判断文件是否存在

        string path = Application.persistentDataPath + "/Lesson1Test.xml";
        print(path);
        if (File.Exists(path))
        {
            #region 反序列化

            //关键
            //1.using 和 StreamReader
            //2.XmlSerializer 和 Deserialize反序列化方法
            using (StreamReader stream = new StreamReader(path))
            {
                //产生了一个反序列化机器
                XmlSerializer s = new XmlSerializer(typeof(Lesson1Test));
                Lesson1Test lt1 = (s.Deserialize(stream)) as Lesson1Test;
                //读取数据时List类型会直接加载后面，最好不要在申明的时候初始化
                //应该在构造函数中初始化
                print(lt1.testPublic);
            }


            #endregion

            #region 总结
            //1.判读文件是否存在 File.Exists(path)
            //2.文件流获取StreamReader reader = new StreamReader(path)
            //3.根据文件流XmlSerializer 和 Deserialize反序列化方法

            //注意：反序列化时，List类型会直接加载后面，最好不要在申明的时候初始化
            #endregion
        }

        #endregion
    }
}
