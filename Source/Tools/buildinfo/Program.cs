﻿/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2014 Dmitriy Khmaladze, IT Adapter Inc / 2015-2016 Aum Code LLC
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/
using System;
using System.IO;

namespace buildinfo
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("BuildSeed={0}",Environment.TickCount);
      Console.WriteLine("Computer={0}", Environment.MachineName);
      Console.WriteLine("User={0}",     Environment.UserName);
      Console.WriteLine("OS={0}",       Environment.OSVersion.Platform);
      Console.WriteLine("OSVer={0}",    Environment.OSVersion.VersionString);
      Console.WriteLine("UTCTime={0}",  EncodeDateTime(DateTime.UtcNow));

      Environment.ExitCode = 0;
    }

    public static string EncodeDateTime(DateTime data)
    {
      using(var wri = new StringWriter())
      {
        var year = data.Year;
        if (year>999) wri.Write(year);
        else if (year>99) { wri.Write('0'); wri.Write(year); }
        else if (year>9) { wri.Write("00"); wri.Write(year); }
        else if (year>0) { wri.Write("000"); wri.Write(year); }

        wri.Write('-');

        var month = data.Month;
        if (month>9) wri.Write(month);
        else { wri.Write('0'); wri.Write(month); }

        wri.Write('-');

        var day = data.Day;
        if (day>9) wri.Write(day);
        else { wri.Write('0'); wri.Write(day); }

        wri.Write('T');

        var hour = data.Hour;
        if (hour>9) wri.Write(hour);
        else { wri.Write('0'); wri.Write(hour); }

        wri.Write(':');

        var minute = data.Minute;
        if (minute>9) wri.Write(minute);
        else { wri.Write('0'); wri.Write(minute); }

        wri.Write(':');

        var second = data.Second;
        if (second>9) wri.Write(second);
        else { wri.Write('0'); wri.Write(second); }

        var ms = data.Millisecond;
        if (ms>0)
        {
            wri.Write('.');

            if (ms>99) wri.Write(ms);
            else if (ms>9) { wri.Write('0'); wri.Write(ms); }
            else { wri.Write("00"); wri.Write(ms); }
        }


        wri.Write('Z');//UTC

        wri.Flush();

        return wri.ToString();
      }
    }


  }
}
