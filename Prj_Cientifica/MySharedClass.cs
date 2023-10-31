﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Cientifica
{
    public static class MySharedClass
    {
        public static void Raise<TEventArgs>(this object source, string eventName, TEventArgs eventArgs) where TEventArgs : EventArgs
        {
            var eventDelegate = (MulticastDelegate)source.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(source);
            if (eventDelegate != null)
            {
                foreach (var handler in eventDelegate.GetInvocationList())
                {
                    handler.Method.Invoke(handler.Target, new object[] { source, eventArgs });
                }
            }
        }
    }
}
