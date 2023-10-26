using Dor.Challenge.Fernando.App.Features.Author.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using System.Runtime.InteropServices;

namespace Dor.Challenge.Fernando.Test.Common
{
    public class AuthorMock
    {
        public static AuthorBody AuthorBodyMock([Optional] int? ID)
        {
            return new AuthorBody
            {
                ID = ID,
                Name = "Name Test",
                Nationality = "Nationality Test",
            };
        }

        public static IEnumerable<AuthorEntity> AuthorEntitiesMock()
        {
            yield return new AuthorEntity
            {
                ID = 1,
                Name = "Name Test",
                Nationality = "Nationality Test",
            };
            yield return new AuthorEntity
            {
                ID = 2,
                Name = "Name Test",
                Nationality = "Nationality Test",
            };
        }
    }
}
