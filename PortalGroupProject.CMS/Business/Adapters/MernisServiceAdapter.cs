using PortalGroupProject.CMS.Business.Abstract;
using PortalGroupProject.CMS.Entities.Concrete;
using MernisServiceReference;
using System;
using System.Threading.Tasks;
using static MernisServiceReference.KPSPublicSoapClient;

namespace PortalGroupProject.CMS.Business.Adapters
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        public async Task<bool> CheckIfRealPerson(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);

            var result = await client.TCKimlikNoDogrulaAsync(long.Parse(customer.NationalityId), customer.FirstName, customer.LastName, customer.DateOfBirth.Year);

            if (result != null)
                return result.Body.TCKimlikNoDogrulaResult;

            return false;            
        }
    }
}
