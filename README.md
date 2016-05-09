[![Version Status](https://img.shields.io/nuget/v/Manager_ActiveDirectory.svg)](https://www.nuget.org/packages/Manager_ActiveDirectory/)

# Usage :

<p>Enterprise ent = new Enterprise();</p>
<p>ent.Login = _textBoxLogin.Text;</p>
<p>ent.Password = _textBoxPwd.Text;</p>

List<LDAP.User> _users = _enterprise.Users;

