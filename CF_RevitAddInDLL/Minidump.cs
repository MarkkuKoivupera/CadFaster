using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Utility
{
    public static class MiniDump
    {
        private static int mDumpError;
        private static MakeDumpArgs mArgs;
        private static MinidumpExceptionInfo mMei;

        public static bool TryDump(String dmpPath, MiniDumpType dmpType)
        {
            mArgs.path = dmpPath;
            mArgs.type = dmpType;
            mMei.ThreadId = GetCurrentThreadId();
            mMei.ExceptionPointers = Marshal.GetExceptionPointers();
            mMei.ClientPointers = false;
           // mMei.ClientPointers = true;
            //Thread t = new Thread(new ThreadStart(MakeDump));
            //t.Start();
            //t.Join();
            MakeDump();
            return mDumpError == 0;
        }

        private static void MakeDump()
        {
            using (FileStream stream = new FileStream(mArgs.path, FileMode.Create))
            {
                Process process = Process.GetCurrentProcess();

                IntPtr mem = Marshal.AllocHGlobal(Marshal.SizeOf(mMei));
                Marshal.StructureToPtr(mMei, mem, false);

                Boolean res = MiniDumpWriteDump(
                                    process.Handle,
                                    process.Id,
                                    stream.SafeFileHandle.DangerousGetHandle(),
                                    mArgs.type,
                                    mMei.ClientPointers ? mem : IntPtr.Zero,
                                    IntPtr.Zero,
                                    IntPtr.Zero);

                mDumpError = res ? 0 : Marshal.GetLastWin32Error();
                Marshal.FreeHGlobal(mem);
            }
        }

        private struct MakeDumpArgs
        {
            public string path;
            public MiniDumpType type;
        }

        [DllImport("DbgHelp.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        private static extern Boolean MiniDumpWriteDump(
                                    IntPtr hProcess,
                                    Int32 processId,
                                    IntPtr fileHandle,
                                    MiniDumpType dumpType,
                                    IntPtr excepInfo,
                                    IntPtr userInfo,
                                    IntPtr extInfo);

        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        [StructLayout(LayoutKind.Sequential)]
        struct MinidumpExceptionInfo
        {
            public Int32 ThreadId;
            public IntPtr ExceptionPointers;
            public bool ClientPointers;
        }
        //omat lisäykset
        


    }

    public enum MiniDumpType
    {
        Normal = 0x00000000,
        WithDataSegs = 0x00000001,
        WithFullMemory = 0x00000002,
        WithHandleData = 0x00000004,
        FilterMemory = 0x00000008,
        ScanMemory = 0x00000010,
        WithUnloadedModules = 0x00000020,
        WithIndirectlyReferencedMemory = 0x00000040,
        FilterModulePaths = 0x00000080,
        WithProcessThreadData = 0x00000100,
        WithPrivateReadWriteMemory = 0x00000200,
        WithoutOptionalData = 0x00000400,
        WithFullMemoryInfo = 0x00000800,
        WithThreadInfo = 0x00001000,
        WithCodeSegs = 0x00002000,
        WithoutAuxiliaryState = 0x00004000,
        WithFullAuxiliaryState = 0x00008000
    }

}