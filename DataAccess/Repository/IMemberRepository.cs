
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memberId);
        Member GetMemberByEmail(string email);
        void InsertMember(Member member);
        void DeleteMember(int memberId);
        void UpdateMember(Member member);
    }
}
