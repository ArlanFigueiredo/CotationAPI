using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;


namespace Cotation.Application.Utilities.User {
    public class GenerateHashPassword {
        public async Task<hashSalt> GenerateHashPasswordAsync(string password) {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }

            // Derive a subchave de 256 bits (usando HMACSHA256 com 100.000 iterações)
            var hashBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            );

            // Converta o hash resultante para uma string base64
            string passwordHash = Convert.ToBase64String(hashBytes);
            string HashSalt = Convert.ToBase64String(salt);

            return new hashSalt {
                PasswordHasher = passwordHash,
                HashSalt = HashSalt
            };
        }

        public class hashSalt() {
            public string PasswordHasher;
            public string HashSalt;
        }
    }
}
