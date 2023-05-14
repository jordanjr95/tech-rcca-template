using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetTemplates.Context;
using GetTemplates.Models;
using GetTemplates.Services;

namespace GetTemplates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {   
        private readonly TemplateContext _context;
        private readonly TempaltesService _templatesService;

        public TemplatesController(TempaltesService tempaltesService) =>
            _templatesService = tempaltesService;

        // GET: api/Templates
        [HttpGet]
        public async Task<List<Template>> Get() =>
            await _templatesService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> Get(string id)
        {
            var template = await _templatesService.GetAsync(id);

            if (template is null)
            {
                return NotFound();
            }

            return template;
        }

        [HttpPost]
        public async Task<ActionResult<Template>> CreateTemplate(Template newTemplate)
        {
            var template = await _templatesService.CreateAsync(newTemplate);

            return template;
        }

        [HttpDelete("deleteTemplate/{id}")]
        public async Task<IActionResult> DeleteTemplate(string id)
        {
            var template = await _templatesService.GetAsync(id);

            if (template is null)
            {
                return NotFound();
            }

            await _templatesService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost("updateTemplate/{id}")]
        public async Task<ActionResult<Template>> UpdateTemplate(string id, Template updatedTemplate)
        {
            var template = await _templatesService.GetAsync(id);

            if (template is null)
            {
                return NotFound();
            }

            updatedTemplate.templateID = template.templateID;

            await _templatesService.UpdateAsync(id, updatedTemplate);

            return updatedTemplate;
        }

        //// GET: api/Templates/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Template>> GetTemplate(int id)
        //{
        //  if (_context.Template == null)
        //  {
        //      return NotFound();
        //  }
        //    var template = await _context.Template.FindAsync(id);

        //    if (template == null)
        //    {
        //        return NotFound();
        //    }

        //    return template;
        //}

        //// PUT: api/Templates/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTemplate(int id, Template template)
        //{
        //    if (id != template.templateID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(template).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TemplateExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Templates
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Template>> PostTemplate(Template template)
        //{
        //  if (_context.Template == null)
        //  {
        //      return Problem("Entity set 'TemplateContext.Template'  is null.");
        //  }
        //    _context.Template.Add(template);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTemplate", new { id = template.templateID }, template);
        //}

        //// DELETE: api/Templates/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTemplate(int id)
        //{
        //    if (_context.Template == null)
        //    {
        //        return NotFound();
        //    }
        //    var template = await _context.Template.FindAsync(id);
        //    if (template == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Template.Remove(template);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TemplateExists(int id)
        //{
        //    return (_context.Template?.Any(e => e.templateID == id)).GetValueOrDefault();
        //}
    }
}
