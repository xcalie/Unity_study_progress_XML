using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;


public class Lesson1Test
{
    public int testPublic;
    //private int testPrivate;
    protected int testProtected;
    [XmlAttribute()]
    internal int testInternal;


    public string testPublicString;

    public int tesPro { get; set; }

    public Lesson1Test2 lesson2Test = new Lesson1Test2();

    //注意！！！该序列化不支持字典！！！
    //public Dictionary<int, string> testDic = new Dictionary<int, string>()
    //{
    //    {1,"a"},
    //    {2,"b"},
    //    {3,"c"}
    //};
}

public class Lesson1Test2
{
    public int test1 = 1;
    public float test2 = 2.0f;
    public bool test3 = true;   

}


public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 什么是序列化和反序列化

        // 序列化：把对象转化为可传输的字节的序列化过程称为序列化
        // 反序列化：把字节序列还原为对象的过程称为反序列化

        // 说人话
        //序列化就是把想要存储的内容转换为字节序列用于存储和传递
        //反序列化就是把储存好收到的字节信息解析读取出来使用

        #endregion

        #region xml序列化

        //1第一步：准备一个数据结构类
        Lesson1Test lt = new Lesson1Test();
        //2进行序列化
        // 关键知识点
        // XmlSerializer 用于序列化对象为xml的关键类
        // StreamWriter 用于存储文件
        // using 用于方便流对象的释放和销毁

        //第一步：确定存储路径
        string path = Application.persistentDataPath + "/Lesson1Test.xml";
        print(path);
        //第二部：结合 using知识点 和 StreamWriter这个流对象 来写入文件
        // 括号内的代码：写入一个文件流 如果有该文件 直接打开并修改 如果没有该文件 直接新建一个文件
        // using 的新用法 括号当中包裹申明的对象 会在大括号语句块结束后 自动释放该对象
        // 当语句块结束 会自动帮我们调用对象的 Dispose() 方法 会让其销毁
        // using一般都是配合 内存占用比较大 或者 有读写操作时 进行使用的
        using (StreamWriter stream = new StreamWriter(path))
        {
            //第三步：进行xml序列化
            XmlSerializer s = new XmlSerializer(typeof(Lesson1Test));
            //这句代码的含义时 就是通过序列化对象 对我类对象进行翻译 将其翻译成我们的xml文件
            //第一个参数：文件流对象
            //第二个参数：想要被翻译 的对象
            //注意：翻译机器的类型 一定要和插入的对象类型一致
            s.Serialize(stream, lt);
        }
        //注意！！！该序列化不支持字典！！！


        #endregion


        #region 总结

        //序列化流程
        //1.准备一个数据结构类
        //2.用XmlSerializer进行序列化
        //3.通过StreamWriter 配合 Using将数据存储写入文件
        //注意
        //1.只能序列化public的属性
        //2.不支持字典
        //3.可以通过特性修改节点信息
        //4.Stream相关要配合using使用

        #endregion

    }

}
