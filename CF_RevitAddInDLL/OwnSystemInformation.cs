using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SolidworksAddin
{
    public class OwnSystemInformation
    {
        public struct MemoryStatus //tee oman näköinen tästä niin ei tuu yhtä hirveä tämä
        {
            public uint Length;
            public uint MemoryLoad;
            public uint TotalPhysical;
            public uint AvailablePhysical;
            public uint TotalPageFile;
            public uint AvailablePageFile;
            public uint TotalVirtual;
            public uint AvailableVirtual;
        } 

        
        [DllImport("kernel32.dll")]
        public static extern void GlobalMemoryStatus(out MemoryStatus stat);

        public string OSVersion;
        public string OSversionNumber;
        public int ProcessorCount;
        public string ProcessorType;
        public string WorkingDir;
        MemoryStatus memStat = new MemoryStatus();
        //percent in memory use too;
        


        public void GatherSystemInformation()
        {
            this.OSVersion = System.Environment.OSVersion.ToString();
            this.OSversionNumber = System.Environment.Version.ToString();
            this.ProcessorCount = System.Environment.ProcessorCount;
            this.WorkingDir = System.Environment.CurrentDirectory;
            GlobalMemoryStatus(out memStat);
            
           
        }

        public override string ToString()
        {
            String productName=AddinUtils.GetAssemblyProduct();

            string temp="";
           // temp += "Error report from module: CadFaster|Translator for Solidworks 2010 R0 beta version 1.0.0.0\r\n";
            temp += "Error report from module: " + productName +" "+ Assembly.GetExecutingAssembly().GetName().Version.ToString()+"\r\n"; // toi ei varmaan toimi
            temp += "OS Version "+this.OSVersion+"\r\n";
            temp += "Os Version number " + this.OSversionNumber + "\r\n";
            temp += "Error occured at " + DateTime.Now.ToUniversalTime().ToString() +"\r\n";
            temp += "Working directory " + this.WorkingDir + "\r\n";
            temp += "Processor count " + this.ProcessorCount + " " + "Type " + this.ProcessorType+ "\r\n";
            temp += "Memory Status:\r\n";
            temp += "Memory load: " + this.memStat.MemoryLoad +"%\r\n";
            temp += "Total physical memory: " + this.memStat.TotalPhysical/1000000 +"MB\r\n";
            temp += "Avaible physical memory: " + this.memStat.AvailablePhysical / 1000000 + "MB\r\n";
            temp += "Total pagefile: " + this.memStat.TotalPageFile / 1000000 + "MB\r\n";
            temp += "Avaible pagefile: " + this.memStat.AvailablePageFile / 1000000 + "MB\r\n";
            temp += "Total virtual memory: " + this.memStat.TotalVirtual / 1000000 + "MB\r\n";
            temp += "Avaible virtual memory: " + this.memStat.AvailableVirtual / 1000000 + "MB\r\n";
            return temp;

        }



        
    }
}
