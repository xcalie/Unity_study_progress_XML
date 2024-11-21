using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSmall
{
    public int testint;
    public string teststring;
}


public class Test99
{
    public int testint;
    public string teststring;

    public int[] ints;

    public List<int> intList = new List<int>();

    public SerializerDictionary<int, string> dic = new SerializerDictionary<int, string>();
}

public class TestNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Test99 test = new Test99();
        //test.testint = 1;
        //test.teststring = "test";
        //test.ints = new int[] { 1, 2, 3, 4, 5 };
        //test.intList.Add(1);
        //test.intList.Add(2);
        //test.intList.Add(3);
        //test.intList.Add(4);
        //test.dic.Add(1, "1");
        //test.dic.Add(2, "2");
        //test.dic.Add(3, "3");

        //XmlDataManager.Instance.SaveData(test, "test");

        Test99 test = XmlDataManager.Instance.LoadData(typeof(Test99), "test") as Test99;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
