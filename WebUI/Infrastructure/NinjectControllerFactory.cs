using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using uh365898_db.Domain.Entities;
using uh365898_db.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using Moq;
using uh365898_db.WebUI.Infrastructure.Abstract;
using uh365898_db.WebUI.Infrastructure.Concrete;
using uh365898_db.Domain.Concrete;
using System.Configuration;


namespace uh365898_db.WebUI.Infrastructure
{
    // реализация пользовательской фабрики контроллеров, 
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера 
            // используя его тип
            return controllerType == null
              ? null
              : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                  .AppSettings["Email.WriteAsFile"] ?? "true")
            };
            ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
              .WithConstructorArgument("settings", emailSettings);

            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
           
        }
    }
}
//Cоздали объект EmailSettings, который будем использовать с методом Ninject WithConstructorArgument. 
//Он будет внедряться в конструктор EmailOrderProcessor, когда создаются новые экземпляры для обслуживания
//запросов интерфейса IOrderProcessor. В листинге 9-15 мы установили значение только для одного из свойств EmailSettings 
//- WriteAsFile. Мы читаем значение этого свойства с помощью свойства ConfigurationManager.AppSettings, которое дает нам
//доступ к настройкам приложения в файле Web.config (в корневой папке проекта), 