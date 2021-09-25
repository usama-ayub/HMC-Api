using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Shared
{
    public class CloudinarySetting : ICloudinarySetting
    {
        public string CloudName { get; set; }
        public string APIKey { get; set; }
        public string APISecret { get; set; }
    }

    public interface ICloudinarySetting
    {
        string CloudName { get; set; }

        string APIKey { get; set; }
        string APISecret { get; set; }
    }
}