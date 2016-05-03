# Usage :

Enterprise ent = new Enterprise();
ent.Login = _textBoxLogin.Text;
ent.Password = _textBoxPwd.Text;

List<LDAP.User> _users = _enterprise.Users;

