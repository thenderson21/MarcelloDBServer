TODO
====

v 0.0.1
-------

 - Authentication
	- CRUD for users
	- Database/Collection level credentials
	- Secure 
		- Basic for SSL
		- Digest for nonSSL
- CRUD Databases
- CRUD Collections
- Syncronising of Databases/Collections
- Configure the Configure and Makefile to acctually work




NOTES
=====

Proposed Routes

`/_Users/` | User CRUD
`/[DATABASE]/`  |  Database CRUD
`/[DATABASE]/[COLLECTION]/` | Collection CRUD


CRUD

| Method | Action |
| :----: | :----- |
| GET    | Read   |
| POST   | Upsert |
| DELETE | Delete |

