using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Solutas;


namespace R5T.Solida.Solutas
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="VisualStudioSolutionFileSiteSerializer"/> implementation of <see cref="IVisualStudioSolutionFileSiteSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddVisualStudioSolutionFileSiteSerializer(this IServiceCollection services,
            ServiceAction<IVisualStudioSolutionFileSerializer> addSolutionFileSerializer)
        {
            services
                .AddSingleton<IVisualStudioSolutionFileSiteSerializer, VisualStudioSolutionFileSiteSerializer>()
                .RunServiceAction(addSolutionFileSerializer)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="VisualStudioSolutionFileSiteSerializer"/> implementation of <see cref="IVisualStudioSolutionFileSiteSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IVisualStudioSolutionFileSiteSerializer> AddVisualStudioSolutionFileSiteSerializerAction(this IServiceCollection services,
            ServiceAction<IVisualStudioSolutionFileSerializer> addSolutionFileSerializer)
        {
            var serviceAction = new ServiceAction<IVisualStudioSolutionFileSiteSerializer>(() => services.AddVisualStudioSolutionFileSiteSerializer(
                addSolutionFileSerializer));
            return serviceAction;
        }
    }
}
