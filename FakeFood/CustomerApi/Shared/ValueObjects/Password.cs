using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeFood.CustomerApi.Shared.ValueObjects
{
    public class Password
    {
        public Password(string secret)
        {
            Secret = secret;
        }

        public string Secret { get; private set; }

        public void ChangePassword(string secret)
        {
            Secret = secret;
        }

        public void GenerateSecret()
        {
            Secret = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
        }
    }
}
