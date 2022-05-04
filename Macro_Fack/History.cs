using System;
using System.Collections.Generic;
using System.Text;

namespace Macro_Fack
{
    public class History
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Lock_Unlock { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class Details
    {
        public string Id { get; set; }
        public string LockUnlock_Id { get; set; }
        public string Division { get; set; }
        public string ProfileName { get; set; }
        public string LockUnlock_Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
