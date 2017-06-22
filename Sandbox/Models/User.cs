using Sandbox.Extensions;
using Sandbox.Interfaces;
using System;

namespace Sandbox.Models
{
    public class User
    {
        private readonly IEncrypter _encrypter;

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Nickname { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public int GamesPlayed { get; protected set; }
        public int TotalPoints { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastUpdated { get; protected set; }

        public User(Guid id, string email, string nickname, string password, IEncrypter encrypter)
        {
            _encrypter = encrypter;
            Id = id;
            SetEmail(email);
            SetNickname(nickname);
            SetPassword(password);
            
            GamesPlayed = 0;
            TotalPoints = 0;
            CreatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nickname} - {CreatedAt}";
        }

        private void SetEmail(string email)
        {
            if (email.IsValid())
            {
                throw new ArgumentException($"Your argument ({nameof(email)}) is invalid.");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
            LastUpdated = DateTime.UtcNow;
        }

        private void SetNickname(string nickname)
        {
            if (nickname.IsValid())
            {
                throw new ArgumentException($"Your argument ({nameof(nickname)}) is invalid.");
            }
            if (Nickname == nickname)
            {
                return;
            }

            Nickname = nickname;
            LastUpdated = DateTime.UtcNow;
        }

        private void SetPassword(string password)
        {
            if (password.IsValid())
            {
                throw new ArgumentException($"Your argument ({nameof(password)}) is invalid.");
            }
            if (Password == password)
            {
                return;
            }
            
            Salt = _encrypter.GetSalt(password);
            Password = _encrypter.GetHash(password, Salt);
            LastUpdated = DateTime.UtcNow;
        }
    }
}
