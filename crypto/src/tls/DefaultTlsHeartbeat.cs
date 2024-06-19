﻿using System;

using Mirror.BouncyCastle.Crypto.Utilities;

namespace Mirror.BouncyCastle.Tls
{
    public class DefaultTlsHeartbeat
        : TlsHeartbeat
    {
        private readonly int idleMillis, timeoutMillis;

        private uint counter = 0U;

        public DefaultTlsHeartbeat(int idleMillis, int timeoutMillis)
        {
            if (idleMillis <= 0)
                throw new ArgumentException("must be > 0", "idleMillis");
            if (timeoutMillis <= 0)
                throw new ArgumentException("must be > 0", "timeoutMillis");

            this.idleMillis = idleMillis;
            this.timeoutMillis = timeoutMillis;
        }

        public virtual byte[] GeneratePayload()
        {
            lock (this)
            {
                // NOTE: The counter naturally wraps back to 0
                return Pack.UInt32_To_BE(++counter);
            }
        }

        public virtual int IdleMillis
        {
            get { return idleMillis; }
        }

        public virtual int TimeoutMillis
        {
            get { return timeoutMillis; }
        }
    }
}
