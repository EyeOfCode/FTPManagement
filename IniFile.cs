﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FTPManagement
{
    class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, int nSize, string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(20000);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 20000, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }

        public List<string> GetAllSections()
        {
            List<string> sections = new List<string>();
            const int MAX_BUFFER = 32767; // Maximum buffer size for section names
            IntPtr pReturnedString = Marshal.AllocCoTaskMem(MAX_BUFFER * sizeof(char));
            try
            {
                int bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, Path);
                if (bytesReturned != 0)
                {
                    // Convert the returned byte array to a string
                    string local = Marshal.PtrToStringAuto(pReturnedString, bytesReturned - 1);
                    // Split the string into sections
                    sections.AddRange(local.Split('\0'));
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(pReturnedString);
            }
            return sections;
        }
    }
}
