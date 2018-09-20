EndPoint
	http://localhost:60388/api/persons

Headers
	Accept-Encoding: gzip		-> el cliente pide compresion vis gzip
	Accept-Encoding: deflate	-> el cliente pide compresion vis defalte
	Accept-Encoding: none		-> el cliente pide no compresion

Se puede hacer la compression con 2 algoritmos
	- GZip
	- Deflate

Nuget Packages
	- Microsoft.AspNet.WebApi.MessageHandlers.Compression

Respuesta del Server
	Content-Encoding: gzip		-> el server va a responder en el header el tipo de compresion que va en la respuesta
	Content-Length: 114			-> aqui se puede ver la disminucion de tamaño de la respuesta