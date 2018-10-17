using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Operational.Caching
{
    public interface ICachePolicy
    {
        void CreateScope(string scope);

        T Set<T>(string scope, string key, T value) where T : class;

        T Get<T>(string scope, string key) where T : class;
    }
}
