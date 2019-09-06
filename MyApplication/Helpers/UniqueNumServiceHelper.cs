using System;

namespace MyApplication.Helpers
{
    public class UniqueNumServiceHelper
    {      
        public string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString("N");
        }       
    }
}