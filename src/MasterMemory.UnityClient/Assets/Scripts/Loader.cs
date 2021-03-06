﻿using UnityEngine;
using System.Collections;
using RuntimeUnitTestToolkit;
using MasterMemory.Tests;
using MasterMemory;
using TesTes;
using System.Collections.Generic;
using System;
using MessagePack;
using MessagePack.Resolvers;

[assembly: MasterMemoryHintAttribute(typeof(Sample))] // dummy
[assembly: MasterMemoryHintAttribute(typeof(Sample), typeof(int), typeof(MemoryKey<string, string>), typeof(MemoryKey<string, string, int>), typeof(MemoryKey<int, int, string, string>), typeof(MemoryKey<string, int>))]
[assembly: MasterMemoryHintAttribute(typeof(Sample), typeof(MyDummyEnum1), typeof(MemoryKey<MyDummyEnum2, MyDummyEnum3>))]

public class TesTes_MyDummyEnum1_Comparer : IComparer<TesTes.MyDummyEnum1>
{
    public int Compare(MyDummyEnum1 x, MyDummyEnum1 y)
    {
        //MasterMemory.Memory<int, string>
        return ((byte)x).CompareTo((byte)y);
    }
}

namespace TesTes
{
    public enum MyDummyEnum1 : byte
    {
        A, B, C
    }
}

public enum MyDummyEnum2 : int
{
    A, B, C
}

public enum MyDummyEnum3 : uint
{
    A, B, C
}

public class Loader
{
    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Register()
    {
        UnitTest.RegisterAllMethods<BinarySearchTest>();
        UnitTest.RegisterAllMethods<DatabaseTest>();
        UnitTest.RegisterAllMethods<MemoryKeyMemoryTest>();
        UnitTest.RegisterAllMethods<MemoryTest>();
        UnitTest.RegisterAllMethods<RangeViewTest>();

        MessagePack.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
            MessagePack.Resolvers.GeneratedResolver.Instance,
            MasterMemoryResolver.Instance,
            DefaultResolver.Instance);
    }
}
