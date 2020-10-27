using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers
{
    [RoutePrefix("api/OfficeAssignments")]
    public class OfficeAssignmentsController : ApiController
    {
        private IMapper mapper;
        private readonly OfficeAssignmentService officeassignmentService = new OfficeAssignmentService(new OfficeAssignmentRepository(UniversityContext.Create()));

        public OfficeAssignmentsController()
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
            var officeassignments = await officeassignmentService.GetAll();
            var officeassignmentsDTO = officeassignments.Select(x => mapper.Map<OfficeAssignmentDTO>(x));

            return Ok(officeassignmentsDTO);
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
            var officeassignment = await officeassignmentService.GetById(id);

            if (officeassignment == null)
                return NotFound();

            var officeassignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeassignment);

            return Ok(officeassignmentDTO);
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
        public async Task<IHttpActionResult> Post(OfficeAssignmentDTO OfficeAssignmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var officeassignment = mapper.Map<OfficeAssignment>(OfficeAssignmentDTO);
                officeassignment = await officeassignmentService.Insert(officeassignment);
                return Ok(officeassignment);
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
        public async Task<IHttpActionResult> Put(OfficeAssignmentDTO OfficeAssignmentDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (OfficeAssignmentDTO.InstructorID != id)
                return BadRequest();

            var flag = await officeassignmentService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                var officeassignment = mapper.Map<OfficeAssignment>(OfficeAssignmentDTO);
                officeassignment = await officeassignmentService.Update(officeassignment);
                return Ok(officeassignment);
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
            var flag = await officeassignmentService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                if (!await officeassignmentService.DeleteCheckOnEntity(id))
                    await officeassignmentService.Delete(id);
                else
                    throw new Exception("ForeignKeys");

                return Ok();
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }
    }
}
