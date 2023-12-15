using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

    [SerializeField] private ThrowMechanics throwMechanics;

    public void CreateGrenade()
    {
        throwMechanics.CreateGrenade();
    }

}
