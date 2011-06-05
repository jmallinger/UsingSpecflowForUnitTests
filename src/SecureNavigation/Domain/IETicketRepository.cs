using System.Collections.Generic;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public interface IETicketRepository
    {
        IEnumerable<ETicket> GetAllETickets();
    }
}