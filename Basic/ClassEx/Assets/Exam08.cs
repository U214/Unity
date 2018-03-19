using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam08
{
    public class Exam08 : MonoBehaviour
    {

        void Start()
        {
            Super obj1 = new Super();
            obj1.Execute();
            // A 출력

            Sub obj2 = new Sub();
            obj2.Execute();
            // B 출력

            Super obj3 = new Sub();
            obj3.Execute();
            // 문제의 부분. B출력하고 싶은데 A가 나온다
        }
    }

    class Super
    {
        public void Execute()
        {
            Debug.Log("A");
        }
    }

    class Sub : Super
    {
        public void Execute()
        {
            Debug.Log("B");
        }
    }
}