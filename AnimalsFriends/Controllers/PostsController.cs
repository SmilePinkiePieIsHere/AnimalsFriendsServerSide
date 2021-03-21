﻿using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AnimalsFriendsContext _context;
        public PostsController(AnimalsFriendsContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Post> posts = _context.Posts;

            posts = posts
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(posts.ToArray());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
