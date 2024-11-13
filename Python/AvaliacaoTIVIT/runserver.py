"""
This script runs the AvaliacaoTIVIT application using a development server.
"""

# Explica��o:
# Autentica��o: A rota /token gera um token JWT para o usu�rio se ele fornecer as credenciais corretas.
# Rotas Protegidas: Existem duas rotas protegidas:
# /user: Acess�vel apenas para usu�rios com o papel user.
# /admin: Acess�vel apenas para usu�rios com o papel admin.
# Seguran�a JWT: O token � gerado na rota /token e utilizado nas demais rotas com o header Authorization: Bearer <token>. 

# # Usu�rios fict�cios

# fake_users_db = {
#     "user": {"username": "user", "role": "user", "password": "L0XuwPOdS5U"},
#     "admin": {"username": "admin", "role": "admin", "password": "JKSipm0YH"},
# } 

# Servi�o FAKE:
# https://api-onecloud.multicloud.tivit.com/fake/health
# https://api-onecloud.multicloud.tivit.com/fake/admin
# https://api-onecloud.multicloud.tivit.com/fake/user
# https://api-onecloud.multicloud.tivit.com/fake/token


# Lembrando que o prazo para concluir � at� amanh� 13/11 �s 13:00 horas
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
