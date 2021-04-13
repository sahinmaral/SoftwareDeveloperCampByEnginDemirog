using GameProject.Abstract;
using GameProject.Entities;

using MernisReference;

using System;

using static MernisReference.KPSPublicSoapClient;

namespace GameProject.Adapter
{
    class MernisServiceAdapter : ICustomerCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(new TCKimlikNoDogrulaRequest(new TCKimlikNoDogrulaRequestBody(Convert.ToInt64(customer.NationalityId), customer.Name.ToUpper(), customer.Surname.ToUpper(), customer.DateOfBirth.Year))).Result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
