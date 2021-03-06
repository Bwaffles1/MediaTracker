using System;
using Unity;
using Unity.RegistrationByConvention;

namespace MediaTracker.MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // Register All Types by Convention by default
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);

            // Overwrite All Types marked as Singleton
            //container.RegisterTypes(
            //    AllClasses.FromLoadedAssemblies()
            //        .Where(t => t.GetCustomAttributes(typeof(SingletonAttribute), true).Any()),
            //    WithMappings.FromMatchingInterface,
            //    WithName.Default,
            //    WithLifetime.ContainerControlled,
            //    null,
            //    true); // Overwrite existing mappings without throwing

            // container.RegisterType<IIdentity>(new InjectionFactory(_ => HttpContext.Current.User.Identity));
        }
    }
}