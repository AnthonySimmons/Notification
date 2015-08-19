using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.IO;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;

namespace Notification.Diagnostics
{
    public static class Diagnostics
    {
        public static ulong MbSize = 1024 * 1024;

        static object sync = new object();

        public static float CpuUsage;

        public delegate void ProgressBarCallBack(float val);
        public static event ProgressBarCallBack progressBarCallBack;

        public static Dictionary<string, float> ProcCpuUsage = new Dictionary<string, float>();


        public static float GetCpuUsage()
        {
            try
            {
                PerformanceCounter performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                performanceCounter.NextValue();
                var counters = GetPerformanceCounters();

                Thread.Sleep(1000);
                CpuUsage = performanceCounter.NextValue();
                SetProcsCpuUsage(counters);
            }
            catch
            { 
            
            }
            return CpuUsage;
        }

        private static List<PerformanceCounter> GetPerformanceCounters()
        {
            List<PerformanceCounter> counters = new List<PerformanceCounter>();
            var procs = Process.GetProcesses();
            foreach (var p in procs)
            {
                PerformanceCounter counter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }
            return counters;
        }

        public static void SetProcsCpuUsage(List<PerformanceCounter> counters)
        {
                ProcCpuUsage.Clear();
                var procs = Process.GetProcesses();
                int i = 0;
                foreach (var p in procs)
                {
                    float usage = counters[i++].NextValue();
                    lock (sync)
                    {
                            if (ProcCpuUsage.ContainsKey(p.ProcessName.ToLower()))
                            {
                                ProcCpuUsage[p.ProcessName] += usage;
                            }
                            else
                            {
                                ProcCpuUsage.Add(p.ProcessName, usage);
                            }
                        
                    }
                }
         
        }

        public static float CachedCpuUsageByProc(string name)
        {
            float usage = 0;

            if (ProcCpuUsage.ContainsKey(name.ToLower()))
            {
                usage = ProcCpuUsage[name.ToLower()];
            }
            return usage;
        }

        public static ulong GetAvailableRam()
        {
            ComputerInfo info = new ComputerInfo();
            return info.AvailablePhysicalMemory / MbSize;
        }

        public static ulong GetRamUsage()
        {
            return GetTotalRam() - GetAvailableRam();
        }

        public static ulong GetTotalRam()
        {
            ComputerInfo info = new ComputerInfo();
            return info.TotalPhysicalMemory / MbSize;
        }

        public static ulong GetRamUsageByProc(string procName)
        {
            PerformanceCounter performanceCounter = new PerformanceCounter("Process", "Working Set - Private", procName);
            
            return (ulong)(performanceCounter.NextValue() / (MbSize));
        }

        public static float GetCpuUsageByProc(string procName)
        {
            PerformanceCounter performanceCounter = new PerformanceCounter("Process", "% Processor Time", procName);
            return performanceCounter.NextValue();
        }

        public static bool KillProcByName(string name)
        {
            bool success = false;

            var procs = Process.GetProcesses();
            foreach (var p in procs)
            {
                if (p.ProcessName.ToLower().Contains(name.ToLower()))
                {
                    p.Kill();
                    success = true;
                    break;
                }
            }
            
            return success;
        }

    }
}
