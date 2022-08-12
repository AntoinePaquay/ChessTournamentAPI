using ChessTournament.BLL.DTO.SignUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface ISignUpService
    {
        void SignUp(SignUpDTO dto);
        void Withdraw(WithdrawDTO dto, Guid MemberId)
    }
}
