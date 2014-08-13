﻿/*
* Virtual Router v1.0 - http://virtualrouter.codeplex.com
* Wifi Hot Spot for Windows 7 and 2008 R2
* Copyright (c) 2011 Chris Pietschmann (http://pietschsoft.com)
* Licensed under the Microsoft Public License (Ms-PL)
* http://virtualrouter.codeplex.com/license
*/

// Modified work copyright (c) 2013 Runxia Electronics Co. Ltd

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace WiFiHost
{
    public static class WlanUtils
    {
        [DebuggerStepThrough]
        public static void Throw_On_Win32_Error(uint retCode)
        {
            if (retCode != 0) // 0 = ERROR_SUCCESS
            {
                throw new Win32Exception((int)retCode);
            }
        }

        public static string ConvertToString(this DOT11_MAC_ADDRESS mac)
        {
            var sb = new StringBuilder();

            sb.Append(mac.one.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.two.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.three.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.four.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.five.ConvertToHexString());
            sb.Append(":");
            sb.Append(mac.six.ConvertToHexString());

            return sb.ToString();
        }

        public static string ConvertToString(this DOT11_SSID ssid)
        {
            return ssid.ucSSID;
        }

        public static string ConvertToHexString(this byte value)
        {
            return Convert.ToString(value, 0x10).PadLeft(2, '0');
        }

        public static DOT11_SSID ConvertStringToDOT11_SSID(string ssid)
        {
            return new DOT11_SSID()
            {
                 ucSSID = ssid,
                uSSIDLength = ssid.Length
            };
        }
    }
}
