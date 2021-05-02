// OnInspectorDisposeExamplesComponent.cs
using Sirenix.OdinInspector;
using UnityEngine;

public class OnInspectorDisposeExamplesComponent : MonoBehaviour
{
    //[OnInspectorDispose("@UnityEngine.Debug.Log(\"Dispose event invoked!\")")]
    [ShowInInspector]
    public BaseClass PolymorphicField;
    
    public abstract class BaseClass { public override string ToString() { return this.GetType().Name; } }
    public class A : BaseClass { }
    public class B : BaseClass { }
    public class C : BaseClass { }
}