using CourseWork.BusinessLogic.Converters;
using CourseWork.BusinessLogic.Services;
using CourseWork.BusinessLogic.Services.AdditionalFieldServices;
using CourseWork.BusinessLogic.Services.UserAcitivityServices;
using CourseWork.BusinessLogic.StaticServices;
using CourseWork.BusinessLogic.Validation;
using CourseWork.Core;
using CourseWork.Core.AdditionalFields;
using CourseWork.Core.UsersActivity;
using CourseWork.DataAccess.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.BusinessLogic.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Converters
            services.AddScoped<IConverter<IFormFile, string>, ImageToStringConverter>();

            // Validation
            services.AddScoped<CountValidation>();

            // Static Services
            services.AddScoped<ItemFieldsService>();
            services.AddScoped<SearchItemService>();
            services.AddScoped<UserActivityService>();

            // Collection
            services.AddScoped<IService<Collection>, CollectionService>();
            services.AddScoped<IService<CollectionTheme>, CollectionThemeService>();
            services.AddScoped<IService<CollectionItem>, CollectionItemService>();
            services.AddScoped<IService<CollectionItemTag>, CollectionItemTagService>();
            services.AddScoped<IService<CollectionRequiredFields>, CollectionRequiredFieldsService>();
            services.AddScoped<IService<ImageSize>, ImageSizeService>();
            services.AddScoped<IService<Tag>, TagService>();

            // User activity
            services.AddScoped<IService<UserComment>, UserCommentService>();
            services.AddScoped<IService<UserLike>, UserLikeService>();

            // Additional fields
            services.AddScoped<IService<BooleanField>, BooleanFieldService>();
            services.AddScoped<IService<DateField>, DateFieldService>();
            services.AddScoped<IService<IntField>, IntFieldService>();
            services.AddScoped<IService<StringField>, StringFieldService>();
            services.AddScoped<IService<TextField>, TextFieldService>();

            return services;
        }
    }
}
