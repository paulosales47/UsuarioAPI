#language: pt-BR

Funcionalidade: Consumidor da API
	Teste das funcionalidades da API de Usuario

Cenario: Pesquisar cliente através do seu id
	Dado que a url do endpoint é http://localhost:27174/api/Usuario/Get/1
	E o metodo é 'GET'