using UnityEngine;

namespace Bonkers.Lobby
{
    using System.Collections.Generic;

    using Unity.Cinemachine;

    public sealed class CharacterSelectCursor : MonoBehaviour//,
                                                 //IInputAxisOwner
    {
        //[SerializeField] private 
        
        // [Header(header: "Input Axes")]
        // [Tooltip(tooltip: "X Axis movement.  Value is -1..1.  Controls the hor movement")]
        // public InputAxis PointX = InputAxis.DefaultMomentary;
        // [Tooltip(tooltip: "Y Axis movement.  Value is -1..1. Controls the ver movement")]
        // public InputAxis PointY = InputAxis.DefaultMomentary;
        //
        // /// Report the available input axes to the input axis controller.
        // /// We use the Input Axis Controller because it works with both the Input package
        // /// and the Legacy input system.
        // void IInputAxisOwner.GetInputAxes(List<IInputAxisOwner.AxisDescriptor> axes)
        // {
        //     axes.Add(item: new IInputAxisOwner.AxisDescriptor
        //     {
        //         DrivenAxis = () => ref PointX, 
        //         Name = "Point X", 
        //         Hint = IInputAxisOwner.AxisDescriptor.Hints.X,
        //     });
        //     axes.Add(item: new IInputAxisOwner.AxisDescriptor
        //     {
        //         DrivenAxis = () => ref PointX, 
        //         Name = "Point Y", 
        //         Hint = IInputAxisOwner.AxisDescriptor.Hints.Y,
        //     });
        // }
        //
        //
        // public void GetInputAxes(List<IInputAxisOwner.AxisDescriptor> axes)
        // {
        //     
        // }
    }
}
