using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlizzardApiReader.Core.RateLimiter
{
    public class ApiQuotaLimiter : IRateLimiter
    {
        private int quotaAllotted;
        private int currentRateCounter;

        public ApiQuotaLimiter()
        {
            quotaAllotted = 5000;
            currentRateCounter = 0;

        }

        public bool IsAtRateLimit()
        {
            return currentRateCounter >= quotaAllotted;
        }

        public void OnHttpRequest(ApiReader reader, ApiResponse response)
        {
            IEnumerable<string> values;
            if (response.Headers.TryGetValues("X-Apikey-Quota-Allotted", out values))
            {
                if (Int32.TryParse(values.First(), out quotaAllotted)) {
                    //it worked
                }
            }

            if (response.Headers.TryGetValues("X-Apikey-Quota-Current", out values))
            {
                if (Int32.TryParse(values.First(), out currentRateCounter))
                {
                    //it worked
                }
            }

        }

        public void OnHttpRequest(ApiReader reader, IApiResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
