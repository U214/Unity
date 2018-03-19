using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam06
{
    public class Exam06 : MonoBehaviour
    {
        void Start()
        {
            Dog dog = new Dog();
            dog.Cry();
        }
    }

    public interface IAnimal
    {
        void Cry();
    }

    public class Dog : IAnimal
    {
        public void Cry()
        {
            Debug.Log("강아지 멍멍");
        }
    }
}
