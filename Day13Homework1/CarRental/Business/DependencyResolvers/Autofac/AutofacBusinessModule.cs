using Autofac;
using Autofac.Extras.DynamicProxy;

using Business.Abstract;
using Business.Concrete;

using Castle.DynamicProxy;

using Core.Utilities.Interceptors;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Dependencies

            #region Dals

            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfColourDal>().As<IColourDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>().SingleInstance();

            #endregion

            #region Managers

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<ColourManager>().As<IColourService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<CarImagesManager>().As<ICarImagesService>().SingleInstance();

            #endregion

            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}