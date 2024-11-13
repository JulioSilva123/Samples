# encoding: utf-8
# encoding: iso-8859-1
# encoding: win-1252

"""
Routes and views for the flask application.
"""


#from urllib import response
import requests
import json


from datetime import datetime
from flask import  render_template, request, redirect, url_for #, Response #, Response,  redirect, url_for, session
from AvaliacaoTIVIT import app



@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""
    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
    )

@app.route('/contact')
def contact():
    """Renders the contact page."""
    return render_template(
        'contact.html',
        title='Contact',
        year=datetime.now().year,
        message='Your contact page.'
    )

@app.route('/about')
def about():
    """Renders the about page."""
    return render_template(
        'about.html',
        title='About',
        year=datetime.now().year,
        message='Your application description page.'
    )



#@app.route('/')
@app.route('/login')
def login():           
    return render_template(
        'login.html',
        title='Login',
        year=datetime.now().year,
        message='Logon'
    )


#@app.route('/')
@app.route('/login_user', methods=["POST"])
def login_user():   
    """
    Renders the login_user page.
    """

    _name = request.form['username']
    _password = request.form['password']  

    rURL = 'https://api-onecloud.multicloud.tivit.com/fake/token'   


    params = {'username':_name,'password':_password}

    _tipo_usuario = 0
    _render_page = "page_adm.html"
   

    try:
        

        response = requests.post(rURL, params=params, headers={'User-Agent': 'Mozilla/5.0'}, verify=False)


        rJWT = response.json()

        sJWT = json.dumps(rJWT)

        oLogin = json.loads(sJWT, object_hook=custom_login_decoder)
        msg_erro = ""
        # response = requests.get(url)
        # response.raise_for_status()  # Levanta um erro para códigos de status 4xx/5xx

        if response.status_code == 200:
            # print("Sucesso! Recurso encontrado.")
            # print(response.json())  # Processa a resposta JSON

            _tipo_usuario = 1

            

            if _name == "user":
                # _render_page = "page_user.html"
                #_tipo_usuario = 2
                return redirect(url_for('page_user', param=oLogin.access_token, query_param='value'))
            else:
                if _name == "admin":
                    return redirect(url_for('page_adm', param=oLogin.access_token, query_param='value'))

        else: 
            if response.status_code == 401: 
                #params = {'msg_erro':'não autorizado'}
                #?title='%s'"%title
                #msg_erro='Não autorizado'
                return redirect(url_for('error_page', param="401 Nao autorizado", query_param='value'))
                #return redirect("/error_page?msg_erro='%s'"%msg_erro)
                #return redirect(url_for('error_page', params=params1), err.response.status_code )
                #return redirect(url_for('error_page401'))
                #response.raise_for_status() 

    except requests.exceptions.HTTPError as err:
        if err.response.status_code == 404:
            #print("Erro 404: Recurso não encontrado.")
            return redirect(url_for('error_page404'))
        else:
            #print(f"Erro HTTP: {err.response.status_code}")
            return redirect(url_for('error_page'))




    except requests.exceptions.RequestException as e:
        #print(f"Erro na solicitação: {e}")
        params = {'msg_erro':'{e}'}
        return redirect(url_for('error_page', params=params), err.response.status_code )





    return render_template(
        _render_page,
        title='Login',
        year=datetime.now().year,
        message='Digite seu usuario e senha',
        model=oLogin
    )


@app.route('/page_adm/<param>')
def page_adm(param):
    """Renders the page_adm page."""

    rURL = 'https://api-onecloud.multicloud.tivit.com/fake/admin'   

    

    #rURL = 'https://api-onecloud.multicloud.tivit.com/fake/user'

    try:


        response = requests.get(rURL, headers={'Authorization': f'Bearer {param}'}, verify=False)
        rJWT = response.json()
        sJWT = json.dumps(rJWT)
        oResult = json.loads(sJWT, object_hook=custom_login_decoder)



    except requests.exceptions.HTTPError as err:
        if err.response.status_code == 404:
            #print("Erro 404: Recurso não encontrado.")
            return redirect(url_for('error_page404'))
        else:
            #print(f"Erro HTTP: {err.response.status_code}")
            return redirect(url_for('error_page'))




    except requests.exceptions.RequestException as e:
        #print(f"Erro na solicitação: {e}")
        params = {'msg_erro':'{e}'}
        return redirect(url_for('error_page', params=params), err.response.status_code )





    resp = render_template(
        'page_adm.html',
        title='Painel do Admin',
        year=datetime.now().year,
        message=oResult.message,
        model=oResult
    )


    #resp.headers.add('Authorization', f'Bearer {param}')
    
    return resp


 
@app.route('/page_user/<param>')
def page_user(param):
    """Renders the page_user page."""


    rURL = 'https://api-onecloud.multicloud.tivit.com/fake/user'

    try:


        response = requests.get(rURL, headers={'Authorization': f'Bearer {param}'}, verify=False)
        rJWT = response.json()
        sJWT = json.dumps(rJWT)
        oResult = json.loads(sJWT) #, object_hook=custom_login_decoder)



    except requests.exceptions.HTTPError as err:
        if err.response.status_code == 404:
            #print("Erro 404: Recurso não encontrado.")
            return redirect(url_for('error_page404'))
        else:
            #print(f"Erro HTTP: {err.response.status_code}")
            return redirect(url_for('error_page'))




    except requests.exceptions.RequestException as e:
        #print(f"Erro na solicitação: {e}")
        params = {'msg_erro':'{e}'}
        return redirect(url_for('error_page', params=params), err.response.status_code )





    resp = render_template(
        'page_user.html',
        title='Page User',
        year=datetime.now().year,
        message=oResult['message'],
        model=oResult
    )


    #resp.headers.add('Authorization', f'Bearer {param}')
    
    return resp



@app.route('/lista')
def lista():
    """Renders the lista page."""
    return render_template(
        'lista.html',
        title='lista',
        year=datetime.now().year,
        message='lista'
    )



@app.route('/error_page404')
def error_page404():
    """Renders the page_adm page."""
    return render_template(
        'error_page404.html',
        title='error_page404',
        year=datetime.now().year,
        message='error_page404'
    )


@app.route('/error_page/<param>')
def error_page(param):
    """Renders the page_adm page."""
    return render_template(
        'error_page.html',
        title='error_page',
        year=datetime.now().year,
        message='msg_erro: ' + param
    )


# @app.route('/error_page401')
# def error_page401():
#     """Renders the page_adm page."""
#     return render_template(
#         'error_page401.html',
#         title='error_page401',
#         year=datetime.now().year,
#         message='error_page401'
#     )

from collections import namedtuple


def custom_login_decoder(dict):
    return namedtuple('login', dict.keys())(*dict.values())