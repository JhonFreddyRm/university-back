using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers
{   
    //[Authorize]
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// obtiene los objetos de cursos 
        /// </summary>
        /// <returns>  listado de los objetos de cursos  </returns>
        ///  <response code="200">OK. Devuleve el listado de objetos solicitados </response>

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));

            return Ok(coursesDTO);
        }

        /// <summary>
        ///  Obtiene un objeto cursos  por su ID
        /// </summary>
        /// <remarks>
        /// Aqui una descripcion mas largas si fuera necesario. Obtiene un objeto por su ID.
        /// </remarks>
        /// <param name="id">Id del objeto</param>
        /// <returns>Objeto cursos </returns>
        /// <response code="200">OK. Devuleve el objetos solicitados </response>
        /// <response code="404">Not Found. No se ah encontrado el objeto solicitado </response>

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);

            if (course == null)
                return NotFound();

            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);
        }

        /// <summary>
        /// Inserta un objeto a cursos 
        /// </summary>
        /// <remarks>
        /// Todos los campos son necesarios llenar
        /// </remarks>
        /// <returns>Objeto Insertado en cursos </returns>
        /// <response code="200">OK. Inserta los objetos solicitados </response>
        /// <response code="400">Bad Request. No se ah Insertado el objeto solicitado </response>
        ///

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }


        /// <summary>
        /// Actualiza un objeto a cursos 
        /// </summary>
        /// <remarks>
        /// Actualizar los campos deseados
        /// </remarks>
        /// <returns>Objeto Actualizado en cursos </returns>
        /// <response code="200">OK. Inserta los objetos solicitados </response>
        /// <response code="400">Bad Request. No se ah Insertado el objeto solicitado </response>
        /// <response code="404">Not Found. No se ah Actualizado el objeto solicitado</response>
        /// 

        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (courseDTO.CourseID != id)
                return BadRequest();

            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }

        /// <summary>
        /// Elimina un objeto a cursos 
        /// </summary>
        /// <remarks>
        /// Elimina el objeto solicitado por ID
        /// </remarks>
        /// <returns>Objeto Eliminado en cursos </returns>
        /// <response code="200">OK. Elimina El objetos solicitados </response>
        /// <response code="404">Not Found. No se ah Eliminado el objeto solicitado</response>

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                else
                    throw new Exception("ForeignKeys");
                    
                return Ok();
            }
            catch (Exception ex) { return InternalServerError(ex); }                    
        }
    }
}
