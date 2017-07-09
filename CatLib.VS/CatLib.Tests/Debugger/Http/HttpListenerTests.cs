﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using System;
using System.Net;
using System.Threading;
using HttpListener = CatLib.Debugger.WebConsole.HttpListener;
#if UNITY_EDITOR || NUNIT
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Category = Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute;
#endif

namespace CatLib.Tests.Debugger.Http
{
    [TestClass]
    public class HttpListenerTests
    {
        private AutoResetEvent wait = new AutoResetEvent(false);

        [TestMethod]
        public void TestHttpListener()
        {
            var listener = new HttpListener("localhost",5200);
            listener.OnRequest += OnRequest;

            string ret;
            var statu = HttpHelper.Get("http://localhost:5200", out ret);
            wait.WaitOne();

            Assert.AreEqual(HttpStatusCode.OK, statu);
        }

        private void OnRequest(HttpListenerContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.OutputStream.Close();
            Console.WriteLine(context.Request.Url.AbsolutePath);
            wait.Set();
        }
    }
}
