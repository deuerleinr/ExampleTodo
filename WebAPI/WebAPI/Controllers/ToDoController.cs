using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/todos")]
    public class ToDoController : ApiController
    {
        readonly ToDoService toDoService = new ToDoService();

        [HttpGet, Route]
        public List<ToDo> GetAll()
        {
            return toDoService.GetAll();
        }

        [HttpPost, Route]
        public int Create(ToDoCreate model)
        {
            return toDoService.Create(model);
        }
    }
}