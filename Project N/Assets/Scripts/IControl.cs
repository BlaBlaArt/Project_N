using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControl
{
    int Health { set; get; }

    float Speed_horizontal { get; set; }

    void Move();

    void Death();
   
}
