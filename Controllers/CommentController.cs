using Microsoft.AspNetCore.Mvc;
using BiblioServer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioServer.Models;
using System;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] Comment model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _commentService.CreateCommentAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateComment([FromBody] Comment model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _commentService.UpdateCommentAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteComment([FromBody] Comment model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _commentService.DeleteCommentAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentService.GetCommentsAsync();
        return Ok(comments);
    }
    [HttpGet]
    public async Task<ActionResult<List<Comment>>> GetCommentsByBookId(int bookId)
    {
        var comments = await _commentService.GetCommentsByBookId(bookId);

        if (comments == null)
        {
            return NotFound();
        }

        return Ok(comments);
    }
}
