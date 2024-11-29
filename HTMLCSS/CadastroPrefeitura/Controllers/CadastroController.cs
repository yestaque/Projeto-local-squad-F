using AspNetCoreGeneratedDocument;
using CadastroPrefeitura.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace CadastroPrefeitura.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IMongoCollection<Prefeitura> _prefeituraCollection;

        // O construtor que recebe o banco de dados e inicializa a coleção
        public CadastroController(IMongoDatabase database)
        {
            _prefeituraCollection = database.GetCollection<Prefeitura>("cadastrar.prefeitura");
        }

        // Lista todas as prefeituras
        public IActionResult Index()
        {
            try
            {
                var prefeituras = _prefeituraCollection.Find(Builders<Prefeitura>.Filter.Empty).ToList();
                return View(prefeituras);  // Retorna a view com a lista de prefeituras
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro ao carregar os dados: " + ex.Message;
                return View("Error");
            }
        }

        // Exibe o formulário de cadastro e preenche com informações de TempData
        [HttpGet]
        public IActionResult CadastroPrefeitura()
        {
            // Recupera as informações temporárias de TempData, se existirem
            var modelJson = TempData["PersonalInfo"] as string;
            var personalInfoModel = string.IsNullOrEmpty(modelJson) ? new Prefeitura() : JsonConvert.DeserializeObject<Prefeitura>(modelJson);


            // Cria uma instância de Prefeitura (não estática)
               var prefeitura = new Prefeitura
            {
           
            };

            // Armazena o objeto combinado (por exemplo, prefeitura) de volta no TempData
            TempData["CombinedInfo"] = JsonConvert.SerializeObject(prefeitura);

            // Retorna a view de cadastro com o modelo de prefeitura
            return View("Registrar", prefeitura); 
        }

        // Exibe o formulário de cadastro (apenas GET)
        public IActionResult Registrar()
        {
            return View();
        }

        // Registra uma nova prefeitura
        [HttpPost]
        public IActionResult Registrar(Prefeitura prefeitura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _prefeituraCollection.InsertOne(prefeitura);  // Insere a prefeitura no MongoDB
                    return RedirectToAction("CadastroSucesso");
                }
                return View(prefeitura);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro ao registrar a prefeitura: " + ex.Message;
                return View("Error");
            }
        }

        // Exibe a página de sucesso
        public IActionResult CadastroSucesso()
        {
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }
    }
}
