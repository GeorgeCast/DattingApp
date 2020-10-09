using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APII.Data;
using APII.Entities;
using APII.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IDataRepository<AppUser> dataRepository)
        {
            DataRepository = dataRepository;
        }

        public IDataRepository<AppUser> DataRepository { get; }

        [HttpGet]
        public async Task<ActionResult> getUsers()
        {
            try
            {
                ListResponse<AppUser> response = new ListResponse<AppUser>();

                response.Items = await DataRepository.FindAll();
                response.TotalItems = response.Items == null ? 0 : response.Items.Count();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getUserById(int id)
        {
            try
            {

                AppUser response = await DataRepository.FindById(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> addUser([FromBody] AppUser user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                AppUser response = await DataRepository.Create(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateUser(int id, [FromBody] AppUser user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (DataRepository.FindById(id) == null)
                {
                    return BadRequest(ConstantValues.MSG_NO_VALID_DATA);
                }

                AppUser response = await DataRepository.Update(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUser(int id)
        {
            try
            {
                AppUser entity = await DataRepository.FindById(id);
                if ( entity == null)
                {
                    return BadRequest(ConstantValues.MSG_NO_VALID_DATA);
                }

                var response = await DataRepository.Delete(entity);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}