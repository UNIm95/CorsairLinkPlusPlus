﻿using CorsairLinkPlusPlus.Common;
using CorsairLinkPlusPlus.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsairLinkPlusPlus.RESTAPI.Methods
{
    public abstract class BaseMethod
    {
        public IDevice Device;
        public Dictionary<string, object> Arguments;

        public static void Execute(string name, IDevice device, Dictionary<string, object> arguments)
        {
            Methods.BaseMethod method;
            switch (name)
            {
                case "Refresh":
                    method = new Methods.Refresh();
                    break;
                case "SetController":
                    method = new Methods.SetController();
                    break;
                default:
                    throw new ArgumentException("Invalid method");
            }
            method.Arguments = arguments;
            method.Device = device;
            if (!method.IsDeviceValid())
                throw new ArgumentException("Invalid method for device");
            method.Call();
        }

        public abstract void Call();

        public virtual bool IsDeviceValid()
        {
            return true;
        }

        protected T GetOptionalArgument<T>(string name, T defaultValue = default(T))
        {
            return GetArgument<T>(name, true, defaultValue);
        }

        protected T GetRequiredArgument<T>(string name)
        {
            return GetArgument<T>(name);
        }

        protected T GetArgument<T>(string name, bool optional = true, T defaultValue = default(T))
        {
            if (!Arguments.ContainsKey(name))
            {
                if (!optional)
                    throw new ArgumentNullException("Argument " + name + " is required");
                return defaultValue;
            }
            return (T)Arguments[name];
        }
    }
}
