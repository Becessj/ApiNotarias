using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notaria.Context;
using Notaria.Models;

namespace Notaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> Getusuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }



        [HttpGet("{username}/{password}")]
        public ActionResult<List<Usuarios>> GetIniciarSesion(string username, string password)
        {
            var usuarios = _context.Usuarios.Where(usuario => usuario.USUARIO.Equals(username) && usuario.CLAVE.Equals(password)).ToList();

            if (usuarios == null)
            {
                return NotFound();
            }
            Console.WriteLine("si entró");
            return usuarios;
        }


    }
}
