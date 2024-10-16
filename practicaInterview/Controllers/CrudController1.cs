using Microsoft.AspNetCore.Mvc;
using practicaInterview.Data;
using practicaInterview.Models;

namespace practicaInterview.Controllers
{
    public class CrudController1 : Controller
    {

        Operations _operations = new Operations();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            var oLista = _operations.Listar();
            return View(oLista);
        }

        public IActionResult ListarBooks()
        {
            var oLista = _operations.ListarBooks();
            Console.WriteLine(oLista);
            return View(oLista);
        }

        [HttpGet]
        public IActionResult ListarAutors()
        {
            var oLista = _operations.Listar();
            return Ok(oLista);
        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(ClientModel clientModel)
        {
            if (clientModel.userPassword != clientModel.confir)
            {
                ViewBag.ErrorMessage = "las contraseñas no coinciden";
                return View();
            }
                

            if (!ModelState.IsValid)
                return View();

            var respuesta = _operations.Register(clientModel);

            if (respuesta)
                return RedirectToAction("Login");
            else
                return View();
        }
        public IActionResult registerBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult registerBook(bookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.errorMessage = "todos los campos son obligatorios";
                return View();
            }
             

            var respuesta = _operations.RegisterBook(bookModel);

            if (respuesta)
                return RedirectToAction("ListarBooks");
            else
                return View();
        }

        public IActionResult Edit(int IdUser)
        {
            var oClient = _operations.getClient(IdUser);
            return View(oClient);
        }

        [HttpPost]
        public IActionResult Edit(ClientModel clientModel)
        {

            if (clientModel.newPassword == null || clientModel.confir == null)
            {
                ViewBag.ErrorMessage = "por favor rellene los dos campos";
                return View();
            }
           
            if (clientModel.newPassword != clientModel.confir)
            {
                ViewBag.ErrorMessage = "las contraseñas no coinciden";
                return View();
            }


            var respuesta = _operations.Edit(clientModel);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Delete(int IdUser)
        {
            var respuesta = _operations.getClient(IdUser);
            return View(respuesta);
        }

        [HttpPost]
        public IActionResult Delete(ClientModel clientModel)
        {
            var respuesta = _operations.Delete(clientModel.id_user);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var respuesta = _operations.Login(loginModel);

            if (!ModelState.IsValid)
                return View();

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                ViewBag.errorMessage = "correo o contraseña incorrectos";
                return View();
            }
        }

    }
}