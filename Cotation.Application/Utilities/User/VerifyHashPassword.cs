using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Cotation.Application.Utilities.User {
    public class VerifyHashPassword {
        public bool VerifyPasswordHash(string storedHash, string storedSalt, string userPassword) {
            // Converta o salt armazenado de base64 para bytes
            byte[] salt = Convert.FromBase64String(storedSalt);

            // Gere o hash da senha inserida
            byte[] userHashBytes = KeyDerivation.Pbkdf2(
                password: userPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            );

            // Converta o hash gerado para base64
            string userHash = Convert.ToBase64String(userHashBytes);

            // Compare os hashes
            return userHash == storedHash;
        }
    }
}
