using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <citing>
/// reference from exercise 2, from dr. McKoy
/// </citing>
namespace CameraMovement
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(LineRenderer))]
    public abstract class AbstractCamera : MonoBehaviour
    {
        [SerializeField]
        protected bool DrawLogic;
        [SerializeField]
        protected GameObject Target1;
        [SerializeField]
        protected GameObject Target2;
        [SerializeField]
        protected GameObject Target3;

        public abstract void DrawCameraLogic();
    }

}