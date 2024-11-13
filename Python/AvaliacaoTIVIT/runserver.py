"""
This script runs the AvaliacaoTIVIT application using a development server.
"""

# Explicação:
# Autenticação: A rota /token gera um token JWT para o usuário se ele fornecer as credenciais corretas.
# Rotas Protegidas: Existem duas rotas protegidas:
# /user: Acessível apenas para usuários com o papel user.
# /admin: Acessível apenas para usuários com o papel admin.
# Segurança JWT: O token é gerado na rota /token e utilizado nas demais rotas com o header Authorization: Bearer <token>. 

# # Usuários fictícios

# fake_users_db = {
#     "user": {"username": "user", "role": "user", "password": "L0XuwPOdS5U"},
#     "admin": {"username": "admin", "role": "admin", "password": "JKSipm0YH"},
# } 

# Serviço FAKE:
# https://api-onecloud.multicloud.tivit.com/fake/health
# https://api-onecloud.multicloud.tivit.com/fake/admin
# https://api-onecloud.multicloud.tivit.com/fake/user
# https://api-onecloud.multicloud.tivit.com/fake/token


# Lembrando que o prazo para concluir é até amanhã 13/11 às 13:00 horas
# Assim que finalizar, por favor me avise.
# Boa Sorte!




import os
from os import environ
from AvaliacaoTIVIT import app



#valor = os.environ['NOME_DA_VARIAVEL']



#from app import create_app
#app = application = create_app()


if __name__ == '__main__':

    HOST = environ.get('SERVER_HOST', 'localhost')
    try:
        PORT = int(environ.get('SERVER_PORT', '5555'))

        #PORT2 = int(os.getenv('PORTA', '5558'))


    except ValueError:
        PORT = 5555

    app.run(HOST, PORT)



     

# if __name__ == "__main__":
#     app.run(debug=True)
