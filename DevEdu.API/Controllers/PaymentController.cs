﻿using AutoMapper;
using DevEdu.API.Common;
using DevEdu.API.Configuration.ExceptionResponses;
using DevEdu.API.Models;
using DevEdu.Business.Services;
using DevEdu.DAL.Enums;
using DevEdu.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DevEdu.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public PaymentController(IMapper mapper, IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }

        //  api/payment/{id}
        [HttpGet("{id}")]
        [AuthorizeRoles(Role.Manager)]
        [ProducesResponseType(typeof(PaymentOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [Description("Get payment by id")]
        public async Task<PaymentOutputModel> GetPaymentAsync(int id)
        {
            var dto = await _paymentService.GetPaymentAsync(id);
            return _mapper.Map<PaymentOutputModel>(dto);
        }

        //  api/payment/user/1
        [AuthorizeRoles(Role.Manager, Role.Student)]
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<PaymentOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [Description("Get all payments by user id")]
        public async Task<List<PaymentOutputModel>> SelectAllPaymentsByUserIdAsync(int userId)
        {
            var list = await _paymentService.GetPaymentsByUserIdAsync(userId);
            return _mapper.Map<List<PaymentOutputModel>>(list);
        }

        //  api/payment
        [HttpPost]
        [AuthorizeRoles(Role.Manager)]
        [ProducesResponseType(typeof(PaymentOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [Description("Add one payment")]
        public async Task<ActionResult<PaymentOutputModel>> AddPaymentAsync([FromBody] PaymentInputModel model)
        {
            var dto = _mapper.Map<PaymentDto>(model);
            var id = await _paymentService.AddPaymentAsync(dto);
            dto.Id = id;
            var output = _mapper.Map<PaymentOutputModel>(dto);
            return Created(new Uri($"api/Payment/{output.Id}", UriKind.Relative), output);
        }

        //  api/payment/5
        [HttpDelete("{id}")]
        [AuthorizeRoles(Role.Manager)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [Description("Delete payment by id")]
        public async Task<ActionResult> DeletePaymentAsync(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }

        //  api/payment/5
        [HttpPut("{id}")]
        [AuthorizeRoles(Role.Manager)]
        [ProducesResponseType(typeof(PaymentOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [Description("Update payment by id")]
        public async Task<PaymentOutputModel> UpdatePaymentAsync(int id, [FromBody] PaymentUpdateInputModel model)
        {
            var dto = _mapper.Map<PaymentDto>(model);
            await _paymentService.UpdatePaymentAsync(id, dto);
            dto = await _paymentService.GetPaymentAsync(id);
            return _mapper.Map<PaymentOutputModel>(dto);
        }

        //  api/payment/bulk
        [HttpPost("bulk")]
        [AuthorizeRoles(Role.Manager)]
        [ProducesResponseType(typeof(List<PaymentOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [Description("Add payments")]
        public async Task<List<PaymentOutputModel>> AddPaymentsAsync([FromBody] List<PaymentInputModel> models)
        {
            var dto = _mapper.Map<List<PaymentDto>>(models);
            var listId = await _paymentService.AddPaymentsAsync(dto);
            dto = await _paymentService.SelectPaymentsBySeveralIdAsync(listId);
            return _mapper.Map<List<PaymentOutputModel>>(dto);
        }
    }
}