namespace Expense.Data
{
    public class UserProfile : AbstractEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public UserProfile() : base(nameof(UserProfile)) { }
    }
}