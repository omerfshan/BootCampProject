using Core.Entities;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userRepository.GetList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Add([FromBody] User user)
    {
        _userRepository.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] User user)
    {
        if (id != user.Id)
            return BadRequest();

        _userRepository.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        if (user == null)
            return NotFound();

        _userRepository.Delete(user);
        return NoContent();
    }
} 