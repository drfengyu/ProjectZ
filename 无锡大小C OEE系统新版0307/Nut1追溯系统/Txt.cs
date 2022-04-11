﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 卓汇数据追溯系统
{
    public class Txt
    {
        public static bool FixtureTimeOut(string Fixture)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "PIS超时保养治具\\" + "超时保养治具" + ".txt";
            StreamReader sR = new StreamReader(path);
            string nextLine;
            while ((nextLine = sR.ReadLine()) != null)
            {
                if (nextLine.Contains(Fixture))
                {
                    return false;
                }
            }
            sR.Close();
            return true;
        }

        public static bool IQCFixtrue(string Fixture)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "PIS超时保养治具\\" + "IQC治具" + ".txt";
            using (StreamReader sR = new StreamReader(path))
            {
                string nextLine;
                while ((nextLine = sR.ReadLine()) != null)
                {
                    if (nextLine.Contains(Fixture))
                    {
                        return true;
                    }
                }
                sR.Close();
            }
            return false;
        }

        public static void WriteLine(string[] FixtureID)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "PIS超时保养治具\\";
            string PathTxt = path + "超时保养治具" + ".txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            System.IO.File.Delete(PathTxt);
            using (StreamWriter sW = new StreamWriter(PathTxt, true, Encoding.Default))
            {
                for (int i = 0; i < FixtureID.Length; i++)
                {
                    sW.WriteLine(FixtureID[i]);
                }
            }
        }

        public static void WriteLine1(string[] FixtureID)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "PIS超时保养治具\\";
            string PathTxt = path + "IQC治具" + ".txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            System.IO.File.Delete(PathTxt);
            using (StreamWriter sW = new StreamWriter(PathTxt, true, Encoding.Default))
            {
                for (int i = 0; i < FixtureID.Length; i++)
                {
                    sW.WriteLine(FixtureID[i]);
                }
            }
        }

        public static void WriteLine2(List<string> FixtureNG)
        {
            string path = @"D:\ZHH\" + "本地小保养治具\\";
            string PathTxt = path + "待保养治具" + ".txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            System.IO.File.Delete(PathTxt);
            using (StreamWriter sW = new StreamWriter(PathTxt, true, Encoding.Default))
            {
                for (int i = 0; i < FixtureNG.Count; i++)
                {
                    sW.WriteLine(FixtureNG[i]);
                }
            }
        }
        public static void WriteLine3(List<string> FixtureNG)
        {
            string path = @"D:\ZHH\" + "本地维修治具\\";
            string PathTxt = path + "待维修治具" + ".txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            System.IO.File.Delete(PathTxt);
            using (StreamWriter sW = new StreamWriter(PathTxt, true, Encoding.Default))
            {
                for (int i = 0; i < FixtureNG.Count; i++)
                {
                    sW.WriteLine(FixtureNG[i]);
                }
            }
        }

        public static List<string> AddFixture_ng()
        {
            List<string> list = new List<string>();
            try
            {
                string filePath = @"D:\ZHH\本地小保养治具\待保养治具.txt";
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(@"D:\ZHH\本地小保养治具\");
                }
                using (StreamReader sR = new StreamReader(filePath, Encoding.Default))
                {
                    string textLine = null;
                    if (File.Exists(filePath))
                    {
                        while ((textLine = sR.ReadLine()) != null)
                        {
                            list.Add(textLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入小保养治具异常" + ex.ToString());
            }
            return list;
        }
        public static List<string> AddFixture_ng1()
        {
            List<string> list = new List<string>();
            try
            {
                string filePath = @"D:\ZHH\本地维修治具\待维修治具.txt";
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(@"D:\ZHH\本地维修治具\");
                }
                using (StreamReader sR = new StreamReader(filePath, Encoding.Default))
                {
                    string textLine = null;
                    if (File.Exists(filePath))
                    {
                        while ((textLine = sR.ReadLine()) != null)
                        {
                            list.Add(textLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入待维修治具异常" + ex.ToString());
            }
            return list;
        }
    }
}
