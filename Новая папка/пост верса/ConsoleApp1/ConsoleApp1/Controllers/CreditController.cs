using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;
using Autofac;
namespace ConsoleApp1.Controllers
{
    public class CreditController
    {
        private readonly ICredit _credit;

        public CreditController()
        {   
          /*  var builder = new ContainerBuilder();
            builder.RegisterType<CreditServices>()
                .As<ICredit>();
            builder.RegisterType<ICredit>();
            var app = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(app));*/
        }

        public void Create(Guid Id)
        {
            _credit.Create(Id);
        }
        public void Repayment(Guid Id)
        {
            _credit.Repayment(Id);

        }
    }
}
