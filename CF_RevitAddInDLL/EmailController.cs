﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace SolidworksAddin
{
    public class EmailController
    {
        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        public static extern int MAPISendMail(IntPtr lhSession, IntPtr ulUIParam,
            MapiMessage lpMessage, int flFlags, int ulReserved);
        public const int MAPI_LOGON_UI = 0x00000001;
        private const int MAPI_DIALOG = 0x00000008;

        public static int SendMail(string[] strAttachmentFileNames, string strSubject, string to)
        {

            IntPtr session = new IntPtr(0);
            IntPtr winhandle = new IntPtr(0);

            MapiMessage msg = new MapiMessage();
            msg.subject = strSubject;
            msg.noteText = "Write here your own descrition...";
            //List<MapiFileDesc> attachmentList = new List<MapiFileDesc>();
            int sizeofMapiDesc = Marshal.SizeOf(typeof(MapiFileDesc));
            IntPtr pMapiDesc = Marshal.AllocHGlobal(sizeofMapiDesc * strAttachmentFileNames.Count());
            //IntPtr pMapiDescs = Marshal.AllocHGlobal(2 * sizeofMapiDesc);
            int ptr = (int)pMapiDesc;
            for (int i = 0; i < strAttachmentFileNames.Count(); i++)
            {
                MapiFileDesc fileDesc = new MapiFileDesc();

                fileDesc.position = -1;
               

                string path = strAttachmentFileNames[i];

                fileDesc.name = Path.GetFileName(path);
                fileDesc.path = path;
                Marshal.StructureToPtr(fileDesc, (IntPtr)ptr+sizeofMapiDesc*i, false);
            }
            msg.files = pMapiDesc;
            
            msg.fileCount = 2;
            

            List<MapiRecipDesc> recipsList = new List<MapiRecipDesc>();
            MapiRecipDesc recipient = new MapiRecipDesc();

            recipient.recipClass = 1;
            recipient.name = to;
            recipsList.Add(recipient);

            int size = Marshal.SizeOf(typeof(MapiRecipDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(recipsList.Count * size);

            int recipPtr = (int)intPtr;
            foreach (MapiRecipDesc mapiDesc in recipsList)
            {
                Marshal.StructureToPtr(mapiDesc, (IntPtr)recipPtr, false);
                recipPtr += size;
            }

            msg.recips = intPtr;
            msg.recipCount = 1;
            int result = MAPISendMail(session, winhandle, msg, MAPI_LOGON_UI | MAPI_DIALOG, 0);

            return result;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiMessage
    {
        public int reserved;
        public string subject;
        public string noteText;
        public string messageType;
        public string dateReceived;
        public string conversationID;
        public int flags;
        public IntPtr originator;
        public int recipCount;
        public IntPtr recips;
        public int fileCount;
        public IntPtr files;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiFileDesc
    {
        public int reserved;
        public int flags;
        public int position;
        public string path;
        public string name;
        public IntPtr type;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiRecipDesc
    {
        public int reserved;
        public int recipClass;
        public string name;
        public string address;
        public int eIDSize;
        public IntPtr entryID;

    }
}