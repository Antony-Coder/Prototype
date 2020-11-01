using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Homebrew;
using System.Reflection;

public class test1 : MonoBehaviour
{
    private Dictionary<Type, object> data = new Dictionary<Type, object>();


    void Start()
    {
        //print(typeof(User));
        // add is IAwake : true если наследуется от интрефейса, иначе false
        //add as IAwake приведение объекта к интерфесу, если не получилось вернет null
        // T универсальный параметр типа
        object t = new test2(777);
        test2 t2 = new test2(69);
        data.Add(t.GetType(), t);
       // data.Add(t2.GetType(), t2);

        object t3;

        data.TryGetValue(t.GetType(), out t3);
        test2 t4 = (test2)t3; //явное преобразование типа object в тип test2
        //typeof получает тип класса, gettype тип объекта
        print(t4.info);
        print(typeof(test2));



    }


}

public class test2
{
    public int info = 0;
    public test2(int i)
    {
        info = i;
    }
}

