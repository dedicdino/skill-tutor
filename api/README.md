SkillTutor
.NET Version: .NET 9.0
-Database: SQL Server with Entity Framework Core

User Credentials
Desktop User (Administrator)
- Username: desktop
- Password: test

Mobile User (Regular User)
- Username: mobile
- Password: test

Environment Configuration

.env File Setup
If the `.env` file doesn't exist in the `SkillTutor.Api` directory, create one with the following content:

Database Connection String

DefaultConnection=Server=localhost;Database=SkillTutorDb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true

JWT Configuration

JwtConfig__Key=your-super-secret-jwt-key-here-make-it-at-least-32-characters-long
JwtConfig__Issuer=https://localhost:7000
JwtConfig__Audience=https://localhost:7000

Optional: Token Validity (in minutes)
TokenValidityMins=30
