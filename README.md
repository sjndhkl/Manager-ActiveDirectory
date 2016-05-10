[![Version Status](https://img.shields.io/nuget/v/Manager-ActiveDirectory.svg)](https://www.nuget.org/packages/Manager_ActiveDirectory/)
[![License](https://img.shields.io/github/license/brandondahler/Data.HashFunction.svg)](https://raw.githubusercontent.com/ThibaultMontaufray/Manager_ActiveDirectory/master/License) 
[![Build Status](https://travis-ci.org/ThibaultMontaufray/Manager_ActiveDirectory.svg?branch=master)](https://travis-ci.org/ThibaultMontaufray/Manager_ActiveDirectory)

# Usage :

<p>Enterprise ent = new Enterprise();</p>
<p>ent.Login = _textBoxLogin.Text;</p>
<p>ent.Password = _textBoxPwd.Text;</p>

List<LDAP.User> _users = _enterprise.Users;

