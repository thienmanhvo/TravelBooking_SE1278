using LounaTravel.Service.BookingService;
using LounaTravel.Service.FeedBack;
using LounaTravel.Service.OfficeService;
using LounaTravel.Service.PassengerService;
using LounaTravel.Service.Region;
using LounaTravel.Service.TourService;
using LounaTravel.Service.UserService;
using System;

using Unity;

namespace LounaTravel
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ITourService, TourService>();
            container.RegisterType<IOfficeService, OfficeService>();
            container.RegisterType<IRegionService, RegionService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IFeedBackService, FeedBackService>();
            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<IPassengerService, PassengerService>();
        }
    }
}