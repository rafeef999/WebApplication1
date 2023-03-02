using Microsoft.AspNetCore.Mvc;
using WebApplication1.data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly appdbcontex _db;

        public CategoryController1(appdbcontex db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var listofbooks = _db.Catagories.ToList();
            catagorymodal vm = new catagorymodal();
            vm.catagories = listofbooks;
            // IEnumerable<catagory> obj = (IEnumerable<catagory>)_db.Catagories;
            // return View(obj);
            return View(vm);
        }
      
      //  public IActionResult Submitc() { return View(); }

        [HttpPost]
        public IActionResult Submitc(catagorymodal bj)
        {
            
                _db.Catagories.Add(bj.catagory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Catagories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Catagories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Catagories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Catagories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }


    }
}
