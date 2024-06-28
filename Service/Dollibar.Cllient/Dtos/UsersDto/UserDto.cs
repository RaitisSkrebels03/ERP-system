namespace Dollibar.Cllient.Dtos.UsersDto
{
    public class UserDto
    {
        public string? Module { get; set; }
        public int Id { get; set; }
        public string? Entity { get; set; }
        public string? Civility_code { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Ref_employee { get; set; }
        public string? National_registration_number { get; set; }
        public string? Login { get; set; }
        public string? Gender { get; set; }
        public int? Admin { get; set; }
        public string? Address { get; set; }
        public string? Zip { get; set; }
        public string? Town { get; set; }
        public int? Country_id { get; set; }
        public int? State_id { get; set; }
        public string? Office_phone { get; set; }
        public string? Office_fax { get; set; }
        public string? User_mobile { get; set; }
        public string? Email { get; set; }
        public string? Job { get; set; }
        public string? Signature { get; set; }
        public string? Accountancy_code { get; set; }
        public string? Note_public { get; set; }
        public string? Note_private { get; set; }
        public string? Ldap_sid { get; set; }
        public int? Fk_user { get; set; }
        public int? Fk_user_expense_validator { get; set; }
        public int? Fk_user_holiday_validator { get; set; }
        public string? Employee { get; set; }
        public string? Thm { get; set; }
        public string? Tjm { get; set; }
        public string? Salary { get; set; }
        public string? Salaryextra { get; set; }
        public string? Weeklyhours { get; set; }
        public string? Color { get; set; }
        public string? Dateemployment { get; set; }
        public string? Dateemploymentend { get; set; }
        public string? Datestartvalidity { get; set; }
        public string? Dateendvalidity { get; set; }
        public string? Birth { get; set; }
        public int? Fk_warehouse { get; set; }
        public string? Lang { get; set; }
    }
}
