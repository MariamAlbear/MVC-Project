using Project.Models;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UnitOfWork
{
    interface IUnitOfWork
    {
        RepositoryCategory<Category> Category { get; }
        RepositoryClinic<Clinic> Clinic { get; }
        RepositoryDoctor<Doctor> Doctor { get; }
        RepositoryProduct<Product> Product { get; }
        RepositoryShop<Shop> Shop { get; }
        RepositorySalesPerson<SalesPerson> SalesPerson { get; }
        RepositoryMother<Mother> Mother { get; }
        RepositoryQuestion<Question> Question { get; }
        RepositoryAnswer<Answer> Answer { get; }
        RepositoryDoctorAnswer<DoctorAnswer> DoctorAnswer { get; }
        RepositoryShopProducts<ShopProducts> ShopProducts { get; }
        RepositoryProductType<ProductType> ProductTypes { get; }
        int SaveChange();
    }
}
