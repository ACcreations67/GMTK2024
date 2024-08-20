using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TransformScript : MonoBehaviour
{
    abstract public void Grow(float ammount);
    abstract public void Shrink(float ammount);
}
