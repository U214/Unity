using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam05
{
    public class Exam05 : MonoBehaviour {

	void Start () {
        Cat cat = new Cat();
        cat.Cry();
	}
}

    public abstract class Animal
    {
        public abstract void Cry();
    }

    public class Cat : Animal
    {
        public override void Cry()
        {
            Debug.Log("야옹");
        }
    }
}
