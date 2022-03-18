using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BugSearch
{
    public class BugStatusFormat
    {
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public static BugStatusFormat Unknown { get { return new BugStatusFormat() { BackColor = Color.White, ForeColor = Color.Black }; } }
        public static BugStatusFormat New { get { return new BugStatusFormat() { BackColor = Color.White, ForeColor = Color.Black }; } }
        public static BugStatusFormat Reopen { get { return new BugStatusFormat() { BackColor = Color.White, ForeColor = Color.Red }; } }
        public static BugStatusFormat Resolve { get { return new BugStatusFormat() { BackColor = Color.FromArgb(0, 176, 240), ForeColor = Color.Black }; } }
        public static BugStatusFormat Verified { get { return new BugStatusFormat() { BackColor = Color.FromArgb(0, 176, 80), ForeColor = Color.Black }; } }
        public static BugStatusFormat NotFixed { get { return new BugStatusFormat() { BackColor = Color.FromArgb(255, 192, 0), ForeColor = Color.Black }; } }
        public static BugStatusFormat ByDesign { get { return new BugStatusFormat() { BackColor = Color.FromArgb(248, 203, 173), ForeColor = Color.Black }; } }
        public static BugStatusFormat InProcess { get { return new BugStatusFormat() { BackColor = Color.FromArgb(102, 153, 255), ForeColor = Color.Black }; } }
    }

    public enum AccountRight : int
    {
        AddSprint = 1,
        DeleteSprint = 2,
        AddTask = 4,
        DeleteTask = 8,
        AddBug = 16,
        DeleteBug = 32,
        AssignBug = 64,
        Reopen = 128,
        Verify = 256,
        SetPriority = 512,
        Resolve = 1024,
        NotFix = 2048,
        ByDesign = 4096,
        AddAccount = 8192,
        DeleteAccount = 16384,
        MoveBug = 32768,
        AssignToMe = 65536,
        Fixed = 131072,
        PleaseWait = 262144
    }
}
