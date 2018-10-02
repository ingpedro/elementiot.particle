using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Operational.Error
{
    public enum ErrorPolicyTypeEnum : int
    {
        Unknown = 0,
        Api = 1,
        Handler = 2,
    }

    public enum ErrorReasonTypeEnum : int
    {
        Unknown = 0,
        Authentication = 1,
        Authorization = 2,
        Validation = 3,
        Configuration = 4,
    }
}
