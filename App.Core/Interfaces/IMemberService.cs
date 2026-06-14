using System.Collections.Generic;
using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IMemberService
    {
        List<Member> GetAllMembers();
        Member GetMemberById(int memberId);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int memberId);
        List<Member> SearchMembers(string keyword);
    }
}