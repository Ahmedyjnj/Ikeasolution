using Ikea.BLL.Dto_s.Departments;
using Ikea.BLL.Dto_s.Employees;
using Ikea.BLL.Services.DepartmentServices;
using Ikea.BLL.Services.EmployeeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ikea.PL.Controllers
{
    [Authorize] //he should has a token to enter he will automatic search on 
    // account /login to make authorize 
    public class EmployeeController : Controller
    {

        #region services -di

        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IDepartmentService departmentService;

        public EmployeeController(IEmployeeServices employeeServices, ILogger<EmployeeController> logger, IWebHostEnvironment hostEnvironment, IDepartmentService departmentService)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
            this.departmentService = departmentService;
        }
        #endregion

        #region index //we will implement index now page 
        [Authorize]
        [HttpGet] // employee /index   ?search =Ahmed
        public async Task<IActionResult> Index(string search) 
        {



            var Employees =await employeeServices.GetAllEmployees(search);

            




            return View(Employees);
        }
        //now we will make create pages


     
       
       

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create() //@* when we submit aform with btn it will send to parameter all asp-for for this type of dto because it post*@
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  {
            // ViewData["Department"] =departmentService.GetAllDepartments();
           // تأكد من التهيئة
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatedEmployeeDto employeeDto) //@* when we submit aform with btn it will send to parameter all asp-for for this type of dto because it post*@
        {
            // make a server side validation by annotation and span in html
            //we have aproblem with very big a bad requests based on 
            //a server we need to make it client side  to handle it
            //we will make layer of validation 
            //client side validation by jquery 

            //we will make client validation to create and edit
            //in html view of this two will put a jquery files

            //we have amistake then a jquery is under a urls of validate it didnt work 

            if (!ModelState.IsValid) //false=> bad requests
                return View(employeeDto);


            var message = string.Empty;

            try
            {
                var result =await employeeServices.CreateEmployee(employeeDto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
            
                else
                {
                    message = "department is not created avalid but no create";

                     //he will add error in empty with modelstate.addmodelerror


                    

                    // there now will  return with error but not as annotation it is add model error so this will go to asp-validation summary of type of modelonly



                }



            }
            catch (Exception ex)
            {
                //this log exception from kestral he now need to know the environment to now how to display this error
                logger.LogError(ex, ex.Message);

                //message for developer

                if (hostEnvironment.IsDevelopment())
                {
                    message = ex.Message;

                   
                }
                else
                    message = "an error affect the creation";

            }

            ModelState.AddModelError(string.Empty, message);

            return View(employeeDto);


        }

        #endregion



        #region Details
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Details(int? id) //the name should be same name of asp-route-id 
        {
            // the type of error handeling

            if (id is null)
            {
                return BadRequest();
            }

            var employee =await employeeServices.GetEmployeeById(id.Value);

            if (employee is null) //not found and bad request we will handle it in api
            {
                return NotFound();
            }

            return View(employee);

        }




        #endregion


        #region edit

        [HttpGet] //get : /department/edit/10
        [Authorize(Roles ="Employee")]
        public async Task<IActionResult> Edit(int? id) // nullable because if null sent by play a man
        {
            if (id is null)
            {
                return BadRequest();
            }

            var employee =await employeeServices.GetEmployeeById(id.Value);//this will return department detail 

            if (employee is null)
            {
                return NotFound();
            }


            var MappedEmployee = new UpdatedEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                Salary = employee.Salary,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId,

                PhoneNumber = employee.PhoneNumber,
                ImageName = employee.ImageName, //for old image


                // we should convert from departmentdetail to updatedepartmentdto's


            };
            //ViewData["Department"] = departmentService.GetAllDepartments();

            return View(MappedEmployee); // there are admin proberty user shouldnt't change it 

            //we should convert from departmentdetail to updatedepartmentdto's

        }

            [HttpPost]

            public async Task<IActionResult> Edit(UpdatedEmployeeDto employeeDto)
            {
                if (!ModelState.IsValid)
                    return View(employeeDto);

                var message = string.Empty;


                try
                {
                    var result = await employeeServices.UpdateEmployee(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        message = "employee is not updated ";


                }
                catch (Exception ex)
                {

                    logger.LogError(ex, ex.Message);



                    message = hostEnvironment.IsDevelopment() ? ex.Message : "an error affect the update while we update employee";


                }

                ModelState.AddModelError(string.Empty, message);

                return View(employeeDto);




            }

        #endregion



        //ctrl+m +l 



        #region delete 
        //the delete will be like detail but have a conferm of the oberation 
        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var employee =await employeeServices.GetEmployeeById(id.Value);


            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int Empid)
        {
            var message = string.Empty;
            try
            {
                var isdeleated =await employeeServices.DeleteEmployee(Empid);

                if (isdeleated)
                {
                    return RedirectToAction(nameof(Index));
                }

                message = "department not deleated";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                message = hostEnvironment.IsDevelopment() ? ex.Message : "an error ocured when  delete";
            }


            ModelState.AddModelError(string.Empty, message);


            return RedirectToAction(nameof(Delete), new { id = Empid }); // when return to delete get he should have an id in route



        }


        #endregion




        ///////last dance partial view
        ///partial view is part of a full view
        ///
        //any shared html code in views we will make it as partial view




    }
}
