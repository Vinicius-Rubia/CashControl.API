using CashControl.API.Context;
using CashControl.API.Interfaces;
using CashControl.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CashControl.API.Services
{
    public class BankStatementService : IBankStatement
    {
        private readonly ApplicationDbContext _context;

        public BankStatementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BankStatementModel>> GetAllBankStatements()
        {
            try
            {
                List<BankStatementModel> bankStatement = await _context.BankStatements.ToListAsync();

                if (bankStatement.Count != 0)
                    return bankStatement;
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao buscar seus extratos bancários! Tente novamente mais tarde.");
            }

            return null;
        }

        public async Task<BankStatementModel> GetBankStatementById(Guid id)
        {
            try
            {
                var bankStatement = await _context.BankStatements.FirstOrDefaultAsync(x => x.Id == id);

                if (bankStatement != null)
                    return bankStatement;
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao buscar seu extrato bancário! Tente novamente mais tarde.");
            }

            return null;
        }

        public async Task CreateBankStatement(BankStatementModel bankStatement)
        {
            try
            {
                if (bankStatement != null)
                {
                    _context.Add(bankStatement);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao cadastrar seu extrato bancário! Tente novamente mais tarde.");
            }
        }

        public async Task<BankStatementModel> DeleteBankStatement(Guid id)
        {
            try
            {
                var bankStatement = await _context.BankStatements.FirstOrDefaultAsync(x => x.Id == id);

                if (bankStatement != null)
                {
                    _context.BankStatements.Remove(bankStatement);
                    await _context.SaveChangesAsync();
                    return bankStatement;
                }
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao deletar seu extrato bancário! Tente novamente mais tarde.");
            }

            return null;
        }

        public async Task<BankStatementModel> UpdateBankStatement(BankStatementModel updateBankStatement)
        {
            try
            {
                var bankStatement = await _context.BankStatements.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateBankStatement.Id);

                if (bankStatement != null)
                {
                    updateBankStatement.Updated_At = DateTime.Now.ToLocalTime();
                    _context.BankStatements.Update(updateBankStatement);
                    await _context.SaveChangesAsync();
                    return bankStatement;
                }
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao atualizar seu extrato bancário! Tente novamente mais tarde.");
            }

            return null;
        }
    }
}
