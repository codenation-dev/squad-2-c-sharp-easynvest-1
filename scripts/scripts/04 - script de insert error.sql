if not exists (select 'x' from ERROR where CODE = 300)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (300, 'MULTIPLE CHOICES', 'The requested resource corresponds to any one of a set of representations, each with its own specific location.', 1, 1, 1)
end
if not exists (select 'x' from ERROR where CODE = 301)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (301, 'MOVED PERMANENTLY', 'The resource has moved permanently. Please refer to the documentation.', 1, 2, 2)
end
if not exists (select 'x' from ERROR where CODE = 302)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (302, 'FOUND', 'The resource has moved temporarily. Please refer to the documentation.', 1, 3, 1)
end
if not exists (select 'x' from ERROR where CODE = 303)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (303, 'SEE OTHER', 'The resource can be found under a different URI.', 1, 4, 2)
end
if not exists (select 'x' from ERROR where CODE = 304)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (304, 'NOT MODIFIED', 'The resource is available and not modified.', 1, 5, 1)
end
if not exists (select 'x' from ERROR where CODE = 305)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (305, 'USE PROXY', 'The requested resource must be accessed through the proxy given by the Location field.', 1, 6, 2)
end

if not exists (select 'x' from ERROR where CODE = 400)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (400, 'BAD REQUEST', 'Invalid syntax for this request was provided.', 2, 1, 1)
end
if not exists (select 'x' from ERROR where CODE = 401)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (401, 'UNAUTHORIZED', 'You are unauthorized to access the requested resource. Please log in.', 2, 2, 2)
end
if not exists (select 'x' from ERROR where CODE = 403)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (403, 'FORBIDDEN', 'Your account is not authorized to access the requested resource.', 2, 3, 1)
end
if not exists (select 'x' from ERROR where CODE = 404)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (404, 'NOT FOUND', 'We could not find the resource you requested. Please refer to the documentation for the list of resources.', 2, 4, 2)
end
if not exists (select 'x' from ERROR where CODE = 405)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (405, 'METHOD NOT ALLOWED', 'This method type is not currently supported.', 2, 5, 1)
end
if not exists (select 'x' from ERROR where CODE = 406)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (406, 'NOT ACCEPTABLE', 'Acceptance header is invalid for this endpoint resource.', 2, 6, 2)
end

if not exists (select 'x' from ERROR where CODE = 500)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (500, 'INTERNAL SERVER ERROR', 'Unexpected internal server error.', 3, 1, 1)
end
if not exists (select 'x' from ERROR where CODE = 501)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (501, 'NOT IMPLEMENTED', 'The requested resource is recognized but not implemented.', 3, 2, 2)
end
if not exists (select 'x' from ERROR where CODE = 502)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (502, 'BAD GATEWAY', 'Invalid response received when acting as a proxy or gateway.', 3, 3, 1)
end
if not exists (select 'x' from ERROR where CODE = 503)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (503, 'SERVICE UNAVAILABLE', 'The server is currently unavailable.', 3, 4, 2)
end
if not exists (select 'x' from ERROR where CODE = 504)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (504, 'GATEWAY TIMEOUT', 'Did not receive a timely response from upstream server while acting as a gateway or proxy.', 3, 5, 1)
end
if not exists (select 'x' from ERROR where CODE = 505)
begin
	insert into ERROR (CODE, TITLE, DESCRIPTION, ENVIRONMENTID, LEVELID, SITUATIONID) values (505, 'HTTP VERSION NOT SUPPORTED', 'The HTTP protocol version used in the request message is not supported.', 3, 6, 2)
end

select * from ERROR
