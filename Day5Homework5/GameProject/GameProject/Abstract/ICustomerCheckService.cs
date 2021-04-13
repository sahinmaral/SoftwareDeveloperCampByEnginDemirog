using GameProject.Entities;

namespace GameProject.Abstract
{
    interface ICustomerCheckService
    {
        bool CheckIfRealPerson(Customer customer);
    }
}
