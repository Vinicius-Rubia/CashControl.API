using CashControl.API.Models;

namespace CashControl.API.Interfaces
{
    public interface IBankStatement
    {
        Task<List<BankStatementModel>> GetAllBankStatements();
        Task CreateBankStatement(BankStatementModel bankStatement);
        Task<BankStatementModel> GetBankStatementById(Guid id);
        Task<BankStatementModel> UpdateBankStatement(BankStatementModel bankStatement);
        Task<BankStatementModel> DeleteBankStatement(Guid id);
    }
}