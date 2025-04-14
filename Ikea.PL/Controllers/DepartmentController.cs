using AutoMapper;
using Ikea.BLL.Dto_s.Departments;
using Ikea.BLL.Services.DepartmentServices;
using Ikea.PL.ViewModel;
using IKEa.DAL.Models.Departments;
using IKEa.DAL.Persinstance.Repositories.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Ikea.PL.Controllers
{


    // inheritance : Departmentcontroler is a controlller
    // composition : Departmentcontroller has a IDepartmentService
    /// <summary>
    /// ////////////////////////////////department index action & view 
    /// 
    /// in action name will make right click to add action
    /// 
    /// 
    /// </summary>

    [Authorize]
    public class DepartmentController : Controller
    {//we will make actions here
        //services => Departments

        private IDepartmentService departmentService;
        private readonly IMapper imapper;
        private readonly ILogger logger;
        private readonly IWebHostEnvironment Environment;

        public DepartmentController(IDepartmentService _departmentService,IMapper imapper,ILogger<DepartmentController> _logger,IWebHostEnvironment hostEnvironment)
        {
            departmentService = _departmentService; //this take a error in kestral 
            this.imapper = imapper;
            logger = _logger;
            Environment = hostEnvironment;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Departments =await departmentService.GetAllDepartments();

            ////ViewData["message"] = "hello from viewdata";

            //view data variable like var he is strogly typed requiring casting that is make safe
            //rather than viewbag that take any value and then make error

            //string name = ViewData["message"] as string ;//because it strogly typed and need casting


           ////// ViewBag.message = "hello from bag";

            // the view data value will replace because same name 
            //he will make two hello from view bag 

            //string name = ViewBag.message; //this bad that can make error //viewbag is dynamic

           // ViewBag.message =1;//it is more dynamic 

           // string yy =ViewBag.message;//it can take more than value because it dynamic 



            return View(Departments);// the model will render in view when we pass to it like that

            //the view will be as name of action

           
            // he will store the view data until you retrive it
        }
        #endregion


        #region Create
        [HttpGet]
        public IActionResult Create() //@* when we submit aform with btn it will send to parameter all asp-for for this type of dto because it post*@
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM departmentVM) //@* when we submit aform with btn it will send to parameter all asp-for for this type of dto because it post*@
        {
            // make a server side validation by annotation and span in html
            if (!ModelState.IsValid)
                return View(departmentVM);


            var message = string.Empty;








            try
            {
                //var departmentdto= new CreatedDepartmentDto()
                //{
                    
                //    name=departmentVM.name,
                //    code=departmentVM.code,
                //    creationdate=departmentVM.creationdate,
                //    description=departmentVM.description,
                    
                //};

                //auto mapper
                var departmentdto = imapper.Map<DepartmentVM,CreatedDepartmentDto>(departmentVM); // this will map the departmentvm to departmentdto


                var result =await departmentService.CreateDepartment(departmentdto);

                if (result > 0)
                {

                    //tempdata it work as dictionary but onetime
                    TempData["message"] = $"yee ng Department {departmentdto.name} is created ";
                    //temp data is for redirection like from create to index 

                    //it work with next request





                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "department is not created avalid but no create";

                    ModelState.AddModelError(string.Empty, message); //he will add error in empty with modelstate.addmodelerror


                    return View(departmentVM);

                    // there now will  return with error but not as annotation it is add model error so this will go to asp-validation summary of type of modelonly



                }



            }
            catch (Exception ex)
            {
                //this log exception from kestral he now need to know the environment to now how to display this error
                logger.LogError(ex, ex.Message);

                //message for developer

                if (Environment.IsDevelopment())
                {
                    message = ex.Message;

                    ModelState.AddModelError(string.Empty, message);

                    return View(departmentVM);
                }
                else
                {
                    message = "an error affect the creation";


                    ModelState.AddModelError(string.Empty, message);

                    return View(departmentVM);
                }
            }




        }

        #endregion


        #region Details

        public async Task<IActionResult> Details(int? id) //the name should be same name of asp-route-id 
        {
            // the type of error handeling

            if(id is null)
            {
                return BadRequest();
            }

            var department =await departmentService.GetDepartmentById(id.Value);

            if (department is null) //not found and bad request we will handle it in api
            {
                return NotFound();
            }

            return View(department);

        }




        #endregion


        #region update  //id will passed by root

        [HttpGet] //get : /department/edit/10
        public async Task<IActionResult> Edit(int? id) // nullable because if null sent by play a man
        {
            if(id is null)
            {
                return BadRequest();
            }

            var department =await departmentService.GetDepartmentById(id.Value);//this will return department detail 

            if(department is null)
            {
                return NotFound();
            }



            var mappeddepartment = imapper.Map<DepartmentDetailsDto, DepartmentVM>(department); // this will map the departmentdto to departmentvm
            //var mappeddepartment = new DepartmentVM()
            //{
            //    id=department.id,
            //    name=department.name,
            //    code=department.code,
            //    description=department.description,
            //    creationdate=department.creationdate
            //};


            return View(mappeddepartment); // there are admin proberty user shouldnt't change it 

            //we should convert from departmentdetail to updatedepartmentdto's




        }

        //we now will make it as post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentVM departmentVM)
        {
            if(!ModelState.IsValid)
                return View(departmentVM);

            var message = string.Empty;


            try
            {
                //var departmentdto = new UpdatedDepartmentDto()
                //{
                //    name = departmentVM.name,
                //    code = departmentVM.code,
                //    description = departmentVM.description,
                //    creationdate=departmentVM.creationdate,
                //    id=departmentVM.id
                //};



                var departmentdto = imapper.Map<DepartmentVM,UpdatedDepartmentDto>(departmentVM);
                







                var result = await departmentService.UpdateDepartment(departmentdto);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    message = "department is not updated ";


            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);



               message=Environment.IsDevelopment() ? ex.Message : "an error affect the update";


            }

            ModelState.AddModelError(string.Empty, message);

            return View(departmentVM);




        }

        #endregion


        //we have a hard delete and soft delete


        #region delete 
        //the delete will be like detail but have a conferm of the oberation 
        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }

            var department =await departmentService.GetDepartmentById(id.Value);


            if(department is null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int deptid)
        {
            var message = string.Empty;
            try
            {
                var isdeleated =await departmentService.DeleteDepartment(deptid);

                if (isdeleated)
                {
                    return RedirectToAction(nameof(Index));
                }

                message = "department not deleated";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                message = Environment.IsDevelopment() ? ex.Message : "an error ocured when  delete";
            }


            ModelState.AddModelError(string.Empty,message);


            return RedirectToAction(nameof(Delete), new {id=deptid}); // when return to delete get he should have an id in route



        }


        #endregion







    }
}
