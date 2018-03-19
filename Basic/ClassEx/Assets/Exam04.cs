using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam04
{
    public class Exam04 : MonoBehaviour
    {

        void Start()
        {
            //Animal animal = new Animal(); // 에러 발생
            //animal.Run();
        }
    }

    public abstract class Animal
    {
        public abstract void Run();
    }
}