# Screenshot capture checklist

These screenshots must be captured from the actual Windows/SQL Server run. Do not replace them with mockups.

| Filename | Capture exactly this |
|---|---|
| `01_table_design.png` | SSMS or SQL Server Object Explorer showing every `dbo.Users` column and data type |
| `02_registration.png` | Registration form with valid test data entered; mask the password |
| `03_successful_login.png` | HomeForm visibly showing `Welcome, {FullName}` |
| `04_failed_login.png` | Failed-login message and/or reduced attempts counter |
| `05_home_grid.png` | DataGridView showing UserID, Username, Email, CreatedAt and no password/hash |
| `06_logout.png` | Login form after logout with both textboxes empty and username focused |
| `07_injection_before.png` | The deliberately vulnerable demo accepting `' OR '1'='1` |
| `08_injection_after.png` | Final parameterized/hash implementation rejecting the same input |

Recommended test account:

- Full Name: `MD. Nazmus Sakib`
- Username: `sakib_test`
- Email: `sakib.test@example.com`
- Password: use any private 6+ character value; do not show it unmasked in a screenshot

After placing the images here, insert them into the separately prepared course report and export that document as `Report.pdf`.
