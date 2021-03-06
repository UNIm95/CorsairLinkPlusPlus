﻿#region LICENSE
/**
 * CorsairLinkPlusPlus
 * Copyright (c) 2014, Mark Dietzer & Simon Schick, All rights reserved.
 *
 * CorsairLinkPlusPlus is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 *
 * CorsairLinkPlusPlus is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with CorsairLinkPlusPlus.
 */
 #endregion

using CorsairLinkPlusPlus.Common.Registry;
using CorsairLinkPlusPlus.Driver.CorsairLink.Controller.LED;
using CorsairLinkPlusPlus.Driver.CorsairLink.Sensor;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CorsairLinkPlusPlus.Driver.CorsairLink.Registry
{
    public class LEDControllerRegistry : RegistryBase<ILEDController>
    {
        private static Dictionary<byte, ConstructorInfo> ledControllers;

        internal static void Initialize()
        {
            ledControllers = new Dictionary<byte, ConstructorInfo>();
            foreach (Type type in GetSubtypesInNamespace(Assembly.GetExecutingAssembly(), "CorsairLinkPlusPlus.Driver.CorsairLink.Controller.LED"))
            {
                ILEDController tempInstance = ConstructObjectForInspection(type);
                ledControllers.Add(tempInstance.GetLEDModernControllerID(), type.GetConstructor(new Type[0]));
                ControllerRegistry.Get(tempInstance.Name, type);
            }
        }

        public static ILEDController Get(LED led, byte modernTypeID)
        {
            if (!ledControllers.ContainsKey(modernTypeID))
                return null;
            ILEDController ledController = (ILEDController)ledControllers[modernTypeID].Invoke(new object[0]);
            ledController.AssignFrom(led);
            return ledController;
        }
    }
}
