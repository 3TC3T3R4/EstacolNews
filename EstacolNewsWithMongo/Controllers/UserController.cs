using AutoMapper;
using EstacolNews.Domain.NoSql.Commands;
using EstacolNews.Domain.NoSql.Entities;
using EstacolNews.UseCases.NoSql.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace EstacolNewsWithMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase 
    {

        private readonly IUserUseCase _userUseCase;
        private readonly IMapper _mapper;

        public UserController(IUserUseCase userUseCase, IMapper mapper)
        {
            _userUseCase = userUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<User> Create_User([FromBody] InsertNewUser command)
        {
            return await _userUseCase.AddUser(_mapper.Map<User>(command));
        }

        //[HttpGet]
        //public async Task<List<Customer>> Get_List_Customer()
        //{
        //    return await _customerUseCase.GetListCustomers();
        //}

        [HttpGet("user/{id}")]
        public async Task<User> Get_User_By_Id(string id)
        {
            return await _userUseCase.GetUserByIdAsync(id);
        }





    }
}
