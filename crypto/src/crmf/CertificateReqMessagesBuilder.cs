using System;
using System.Collections.Generic;

using Mirror.BouncyCastle.Asn1.Crmf;

namespace Mirror.BouncyCastle.Crmf
{
    public class CertificateReqMessagesBuilder
    {
        private readonly List<CertReqMsg> m_requests = new List<CertReqMsg>();

        public CertificateReqMessagesBuilder()
        {
        }

        public virtual void AddRequest(CertificateRequestMessage request) => m_requests.Add(request.ToAsn1Structure());

        public virtual CertificateReqMessages Build()
        {
            CertificateReqMessages certificateReqMessages = new CertificateReqMessages(
                new CertReqMessages(m_requests.ToArray()));

            m_requests.Clear();

            return certificateReqMessages;
        }
    }
}
