using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SUT.DataAccess;
using SUT.Entities;
using SUT.FinancialCalculator;
using SUT.UI.BonusProjectorService;

namespace SUT.UI.Controllers
{
    public class EmployeesController : Controller
    {
        //private db dbContext = new db();
        private IUnitOfWork<db> uow;
        private IRepository<Employee> employeeRepository;
        private IBonusProjector bonusProjector;
        public IBonusCalculator bonusCalculator { get; set; }

        public EmployeesController(IUnitOfWork<db> UnitOfWork, IBonusProjector BonusProjector)
        {
            uow = UnitOfWork;
            bonusProjector = BonusProjector;
            employeeRepository = new Repository<Employee>(uow.DbContext);
        }

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            return View(employeeRepository.GetAll().ToList());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await employeeRepository.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }

            if (DateTime.Now >= DateTime.Parse("07/01/2017"))
            {
                bonusCalculator = new FY18BonusCalculator();
            }
            else
            {
                bonusCalculator = new FY17BonusCalculator();
            }

            ViewBag.BonusAmount = bonusCalculator.GetBonusPercentage(employee) * employee.Salary / 100;
            ViewBag.NextYearProjectBonus = bonusProjector.GetExpectedBonus(employee.Salary);

            
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Salary,HireDate,PerformanceStarLevel")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Add(employee);
                await uow.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await employeeRepository.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Salary,HireDate,PerformanceStarLevel")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Edit(employee);
                await uow.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await employeeRepository.GetByIdAsync(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await employeeRepository.GetByIdAsync(id);
            employeeRepository.Delete(employee);
            await uow.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
