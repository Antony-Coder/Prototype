using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace testing
{
    public class testt2 : MonoBehaviour
    {
        public Dictionary<Type, object> dic = new Dictionary<Type, object>();

        private void Start()
        {
            Set(typeof(Te));
            Set(typeof(Te2));
            print(dic.Count);
            Te2 a = (Te2)dic[typeof(Te2)];
            print(a.Name);
            
        }


        void Set(Type a){


            var b = Activator.CreateInstance(a);

            dic.Add(a, b);
        }
    }


    public class Te
    {
        public string Name { get; private set; }
       
        public Te()
        {
            Name = "Te";
        }
    }

    public class Te2
    {
        public string Name { get; private set; }

        public Te2()
        {
            Name = "Te2";
        }
    }

}
