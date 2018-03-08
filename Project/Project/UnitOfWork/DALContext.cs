using Project.Models;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UnitOfWork
{
     class DALContext : IUnitOfWork
    {
        DataContext dbContext = new DataContext();

        private RepositoryCategory<Category> category;
        private RepositoryClinic<Clinic> clinic;
        private RepositoryProduct<Product> product;
        private RepositoryDoctor<Doctor> doctor;
        private RepositoryShop<Shop> shop;
        private RepositorySalesPerson<SalesPerson> salesperson;
        private RepositoryMother<Mother> mother;
        private RepositoryQuestion<Question> question;
        private RepositoryAnswer<Answer> answer;
        private RepositoryDoctorAnswer<DoctorAnswer> doctorAnswer;
        private RepositoryShopProducts<ShopProducts> shopProducts;
        private RepositoryProductType<ProductType> productTypes;

        public RepositoryCategory<Category> Category
        {
            get
            {

                category = new RepositoryCategory<Category>(dbContext);
                return category;
            }
        }

        public RepositoryClinic<Clinic> Clinic
        {
            get
            {
                clinic = new RepositoryClinic<Clinic>(dbContext);
                return clinic;
            }
        }
        public RepositoryProduct<Product> Product
        {
            get
            {
                product = new RepositoryProduct<Product>(dbContext);
                return product;
            }
        }
        public RepositoryShop<Shop> Shop
        {
            get
            {
                shop = new RepositoryShop<Shop>(dbContext);
                return shop;
            }
        }
        public RepositorySalesPerson<SalesPerson> SalesPerson
        {
            get
            {
                salesperson = new RepositorySalesPerson<SalesPerson>(dbContext);
                return salesperson;
            }
        }
        public RepositoryDoctor<Doctor> Doctor
        {
            get
            {
                doctor = new RepositoryDoctor<Doctor>(dbContext);
                return doctor;
            }
        }


        public RepositoryMother<Mother> Mother
        {
            get
            {

                mother = new RepositoryMother<Mother>(dbContext);
                return mother;
            }
        }
        public RepositoryQuestion<Question> Question
        {
            get
            {

                question = new RepositoryQuestion<Question>(dbContext);
                return question;
            }
        }
        public RepositoryAnswer<Answer> Answer
        {
            get
            {

                answer = new RepositoryAnswer<Answer>(dbContext);
                return answer;
            }
        }
        public RepositoryShopProducts<ShopProducts> ShopProducts
        {
            get
            {

                shopProducts = new RepositoryShopProducts<ShopProducts>(dbContext);
                return shopProducts;
            }
        }

        public RepositoryDoctorAnswer<DoctorAnswer> DoctorAnswer
        {
            get
            {
                doctorAnswer = new RepositoryDoctorAnswer<DoctorAnswer>(dbContext);
                return doctorAnswer;
            }
        }
        public RepositoryProductType<ProductType> ProductTypes
        {
            get
            {

                productTypes = new RepositoryProductType<ProductType>(dbContext);
                return productTypes;
            }
        }
        public int SaveChange()
        {
            return dbContext.SaveChanges();
        }

    }
}