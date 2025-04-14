using Ikea.BLL.Common.Services.Attachments;
using Ikea.BLL.Services.DepartmentServices;
using Ikea.BLL.Services.EmployeeServices;
using Ikea.PL.Controllers;
using Ikea.PL.Mapping;
using IKEa.DAL.Models.Identity;
using IKEa.DAL.Persinstance.Data;
using IKEa.DAL.Persinstance.Repositories.Departments;
using IKEa.DAL.Persinstance.Repositories.Employees;
using IKEa.DAL.Persinstance.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ikea.PL
{
    public class Program
    {
        //anEntry point //as first system begins with search on -viewstart
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region configure services
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //this work by clr to make object from controller to run action

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {

                //options.UseSqlServer("Server=.;Database=Ikea_G02;Trusted_Connection=true;TrustCertificate=true");

                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("defualtConnection"));


            }



            //to make crud operations we need to take opject from context to make connection 
            //we need to inject a object from context in every element need it by clr
                );





            #endregion

            //make object ber request
            //this mean if he need object from this type if he need object 
            // it will make it automatic


            //builder.Services.AddScoped<ApplicationDbContext>();

            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>(
            //    (service) =>
            //    {
            //        var optionbuilder = new DbContextOptionsBuilder<ApplicationDbContext>;

            //        optionbuilder.UseSqlServer("Server=.;Database=Ikea_G02;Trusted_Connection=true;TrustCertificate=true");

            //        var options = optionbuilder.Options;

            //        return options;



            //    } //old way object per life time








            //); //make object per request

            //this will allow a di in usermanager signinmanager and role manager
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>((Option) =>
            {
                
                Option.User.RequireUniqueEmail = true;
                Option.Password.RequireDigit = true;
                Option.Password.RequiredLength = 8;
                Option.Password.RequiredUniqueChars = 1;

                Option.Password.RequireUppercase = true;
                Option.Password.RequireLowercase = true;
                Option.Password.RequireNonAlphanumeric = true;
              
                Option.Lockout.AllowedForNewUsers = true;
                Option.Lockout.MaxFailedAccessAttempts = 5;
                Option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            // we can make configuration here by using options 

            builder.Services.AddAuthentication().AddCookie(Option =>
            {
                Option.LoginPath = "/Account/LogIn";
                
                Option.AccessDeniedPath = "/Home/Error";
                Option.ExpireTimeSpan = TimeSpan.FromDays(2);
                Option.ForwardSignOut = "/Account/LogIn";  //this code for service of tokken 
                //in api we will use awt that better than this 

                //Option.Cookie.Name = "IkeaCookie"; //this is the name of cookie
            });
           
          




            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



            builder.Services.AddScoped<IEmployeeRepository, EmplyeeRepository>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();


            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            builder.Services.AddScoped<IAttachmentServices, AttachmentServices>();




            builder.Services.AddAutoMapper(M=>M.AddProfile(typeof(MappingProfile)));

            //builder.Services.AddScoped<>
            //this make easy to change to oracle 
            //if one call Idepartment he will send department


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseAuthorization(); // we can delete this it about صلاحيات 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
//today we will make a Ikea project
// 3Tier-3 layer Architecture
//we will use this layer in mvc
//1-DAL Data access layer as library has model Dbcontext migrations =>Database
//2-BLL business logic layer as library has repositoy unit of work =>business
//3-PL presentation layer has mvc or wep api or desktop or mobile

// the second layer is onion layer architecture
//from sphare 1-domain model layer 2-repository layer 3-services layer
//4-preesentation layer

//1-models 2- Dbcontext 3-service 4-
//we will use onion in api 

//make a blank solution (Ikeasolution) /then add new project class library asp .net core wep app (model view controller)
// use .net8 name of project Ikea.PL


// in lanch settings http and https are profiles of kestral

//we have home controller in index and privacy and error
// it return type of IactionResult that interface has all returns of views
//

// in this a homecontroller
//
// private readonly ILogger<HomeController> _logger;

//public HomeController(ILogger<HomeController> logger)
//{
//    _logger = logger;
//}

//this work as dependancy injection automatically
// the sysetem will see a constructorr  in controller then sent a object as
// static one time in life of object 


// in model we have only a Error view model 

// we make pl presentation layer now time for  BLL Business logic layer
//as name IKEa.BLL


//make IKEA.DAL -1-make folder Models 2-Persistance

//in persistance make 1-Data 2-Repositories

// in data make 1-Configurations 2- Data Seeds 3-Migrations

//-DAL
// ├── Models
// ├── Persistance
// │   ├── Data
// │   │   ├── Configurations
// │   │   ├── Data Seeds
// │   │   ├── Migrations
// │   ├── Repositories




//in BLL make folder Services

// in a PL add in depandencis add reference to BLL
// in BLL add in depandencis add reference to  DAL

///////////////////////////////////////////////////////////////////
/// Department module with configurations
/// 
/// in DAL-models- make folder Departments
/// 
///  in folder Departments -class Department as public 
/// 
/// -----------------------------------------------------------
/// in models-ModelBase make as class
/// 
/// //we will write a data annotation in views
/// 
/// after finish modelbase and department 
/// 
/// we will make in Data- class as name ApplicationDbContext.cs
/// 
/// //add core.sqlserver to DAL
/// 
/// 
/// 
/// 
/// 
/// //////////////////////////////////////////////////////////////////////
/// third video implement repository pattern
/// //to crud operation
/// 
/// we write repository as encapsulation we will hide code and service 
/// //as actual access data
/// 
/// this has dependancy injection low dublicate of code
/// make seperation abusiness logic from Dal
/// make error handling
/// 
/// 
/// repository pattern encapsulate database queries
/// 
/// ---in DAl -Persistace -Repositories-make in it folder Departments
/// --make interface --IDepartmentRepository.cs
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// start department controller
/// make contoller in layer pl

//



/////////////////////////////////////////////////client side validation 
///
//we have problem in frontend when we pass a model error

























////////////////////////////////////////////////////////////////in 3 of 5 will make a employee module with configuration and handle it in dbconteex





//\\ we now will learn video 6 from a 6 mvc ////////////////////////////////ienumerable vs iqureble


//we havre aproblem in retrive  collection we will retrive it 






///////////////////we now have a 3 settion of 8 in mvc

//authentication and authorization
//we will use identity core
// step 0 identification registration have an account 
// step 1 authentication who are you and from where local Active directory External server{Google facebook} ,Federated server like souq in amazon

//authorizatiobn  what you can do roles for each user

// microsoft identity core
//1- userManager -> to manage user  ---5functions
/* registeration
 create user 
 update user
    delete user
    find user
confirm Account 
read user data
 */
//3- signInManager -> to manage sign in 7 functions
/* 
sign in
sign out
is signed
reset password
generate password
two factor authentication
OTP Authentication
EXTERNAL AUTHENTICATION () -- FACEBOOK GOOGLE
 
  
  
 */
//2- roleManager -> to manage roles (identify roles)
/*
 
create role 
update role
delete role

 */


/*
 1- install package in DAl  Microsoft.AspNetCore.Identity.EntityFrameworkCore
 
2- we will work in context but a service and repo will be automatic because it in identity
3- will make context inherit from identityDbcontext rather than an context
4-the identity will make 7 tables and its migration 


5- we will make dbset of identity user --
the table has id as generic of <Tkey>
id as default he is string but we can change it --        public DbSet<IdentityUser<int>> Users { get; set; }
but we will leave it as default

//////////////////////////////////////////////////////

we use normalizeduser name for compare and case sensetive a capital version of user name

and normalizedemail

passwordhash is a encryption version of password is hashed by schema

phonednumberconfirmed for sms message


twofactorenabled

lockoutend for banned in account time end of baned


AccountFailedcount gets sets number of failed login attempts


1- in models of DAL make folder Identitity then make ApplicationUser.cs that as identity user


 app.UseAuthentication(); 
 app.UseAuthorization(); 

in pipelines 













 */






















