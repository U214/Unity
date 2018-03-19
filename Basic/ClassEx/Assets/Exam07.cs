using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam07
{
    public class Exam07 : MonoBehaviour
    {

        void Start()
        {
            // 추상 클래스를 상속 받은 Cat1 클래스의 객체 생성
            Cat1 cat = new Cat1();
            cat.Cry();

            // 일반 클래스의 객체 생성
            Dog1 dog1 = new Dog1();
            dog1.Walk();

            // 일반클래스를 상속받은 Dog2 클래스의 객체 생성
            Dog2 dog2 = new Dog2();
            dog2.Eat(); // 상속 받은 메서드 호출
            dog2.Run();
        }
    }

    public abstract class Animal
    {
        // 추상메서드
        public abstract void Cry();
    }

    public class Dog1
    {
        // 일반 메서드
        public void Eat()
        {
            Debug.Log("강아지 먹기");
        }

        // 가상메서드 : 빈 내용의 메서드
        public virtual void Run() { }
        // 가상메서드 : 구체적 동작을 정의한 메서드
        public virtual void Walk()
        {
            Debug.Log("강아지 걷기");
        }
    }

    public class Cat1 : Animal
    {
        public override void Cry()
        {
            Debug.Log("고양이 야옹");
        }
    }

    public class Dog2 : Dog1
    {
        public override void Run()
        {
            Debug.Log("강아지 멍멍"); // 메서드 오버라이드
        }
    }
}