using System;
using System.Data;
using Student_The_Standard.Models.Groups;
using Student_The_Standard.Models.Groups.Exceptions;

namespace Student_The_Standard.Services.Foudnations.Groups
{
    public partial class GroupService
    {
        private void ValidateOnAdd(Group group)
        {
            ValidateGroupNotNull(group);

            Validate(
                (Rule: IsInvalid(group.Id), Parameter: nameof(Group.Id)),
                (Rule: IsInvalid(group.Name), Parameter: nameof(Group.Name)),
                (Rule: IsInvalid(group.CreatedTime), Parameter: nameof(Group.CreatedTime)),
                (Rule: IsInvalid(group.ModifiedTime), Parameter: nameof(Group.ModifiedTime))
                );
        }

        private void ValidateGroupNotNull(Group group)
        {
            if (group is null)
            {
                throw new NullGroupException("Group is null.");
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Value is required"
        };

        private static dynamic IsInvalid<T>(T value) => new
        {
            Condition = IsEnumValid<T>(value),
            Message = "Value is not recognized"
        };

        private static bool IsEnumValid<T>(T value)
        {
            bool isDefined = Enum.IsDefined(typeof(T), value);

            return isDefined is false;
        }

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidGroupException = new InvalidGroupException();

            foreach((dynamic rule, string parameter)  in validations)
            {
                if (rule.Condition)
                {
                    invalidGroupException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidGroupException.ThrowIfContainsErrors();
        }
    }
}
