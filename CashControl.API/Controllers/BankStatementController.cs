using CashControl.API.Exceptions;
using CashControl.API.Interfaces;
using CashControl.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashControl.API.Controllers
{
    [Route("api/bankStatements/")]
    [ApiController]
    public class BankStatementController : ControllerBase
    {
        private readonly IBankStatement _bankStatement;

        public BankStatementController(IBankStatement bankStatement)
        {
            _bankStatement = bankStatement;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankStatementModel>>> GetBankStatements()
        {
            try
            {
                List<BankStatementModel> response = await _bankStatement.GetAllBankStatements();

                if (response == null)
                    throw new NotFoundBankStatementException("Não encontramos nenhum extrato bancário!");

                return Ok(response);
            }
            catch (NotFoundBankStatementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankStatementModel>> GetBankStatementById([FromRoute] Guid id)
        {
            try
            {
                BankStatementModel response = await _bankStatement.GetBankStatementById(id);

                if (response == null)
                    throw new NotFoundBankStatementException("Não encontramos nenhum extrato bancário!");

                return Ok(response);
            }
            catch (NotFoundBankStatementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateBankStatement([FromBody] BankStatementModel bankStatement)
        {
            try
            {
                await _bankStatement.CreateBankStatement(bankStatement);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateBankStatement([FromBody] BankStatementModel bankStatement)
        {
            try
            {
                BankStatementModel response = await _bankStatement.UpdateBankStatement(bankStatement);

                if (response == null)
                    throw new NotFoundBankStatementException("Não encontramos nenhum extrato bancário!");

                return Ok();
            }
            catch (NotFoundBankStatementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBankStatement([FromRoute] Guid id)
        {
            try
            {
                BankStatementModel response = await _bankStatement.DeleteBankStatement(id);

                if (response == null)
                    throw new NotFoundBankStatementException("Não encontramos nenhum extrato bancário!");

                return Ok();
            }
            catch (NotFoundBankStatementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}