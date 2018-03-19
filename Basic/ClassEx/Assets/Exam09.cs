using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam09
{
    public class Exam09 : MonoBehaviour
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
            // 이제 B가 나온다
        }
    }

    class Super
    {
        public virtual void Execute()
        {
            Debug.Log("A");
        }
    }

    class Sub : Super
    {
        public override void Execute()
        {
            Debug.Log("B");
        }
    }
}