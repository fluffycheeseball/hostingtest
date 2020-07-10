using System;

namespace Interfaces.Models
{
    public interface IUser
    {
        int? Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string AdditionalData { get; set; }
    }

    public class UserProfile : IUser
    {
        public int? Id { get; set; }

        private string _userName = string.Empty;

        public string UserName
        {
            get => _userName;
            set => _userName = value ?? string.Empty;
        }

        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set => _email = value ?? string.Empty;
        }

        private string _additionalData = string.Empty;
        public string AdditionalData
        {
            get => _additionalData;
            set => _additionalData = value ?? string.Empty;
        }
    }
}
