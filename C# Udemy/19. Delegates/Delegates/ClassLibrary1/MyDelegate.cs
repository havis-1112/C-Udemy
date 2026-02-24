using System;

namespace ClassLibrary1
{
    // Single-cast delegate
    public delegate int MyDelegateType(int a, int b);

    // Multi-cast delegate
    public delegate void MyDelegateType2(double a, double b);

    // Event delegate
    public delegate void MyDelegateType3(int a, int b);
}
