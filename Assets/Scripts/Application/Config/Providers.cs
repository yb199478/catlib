﻿using System;
using CatLib.Event;
using CatLib.Lua;
using CatLib.Network;
using CatLib.NetPackage;
using CatLib.UpdateSystem;
using CatLib.ResourcesSystem;
using CatLib.Buffer;
using CatLib.Thread;
using CatLib.Time;
using CatLib.IO;

public class Providers{

    /// <summary>
    /// 服务提供者
    /// </summary>
	public static Type[] ServiceProviders
    {
        get
        {
            return new Type[] {

                typeof(NetPackageProvider),
                typeof(AutoUpdateProvider),
                typeof(ResourcesProvider),
                typeof(DispatcherProvider),
                typeof(NetworkProvider),
                typeof(LuaProvider),
                typeof(IOProvider),
                typeof(BufferProvider),
                typeof(ThreadProvider),
                typeof(TimeProvider),
                typeof(Bootstrap),

            };
        }
    }
}
