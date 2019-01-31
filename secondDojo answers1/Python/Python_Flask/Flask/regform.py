from flask import Flask, render_template, request, redirect, session, flash
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)  

app.secret_key= "/regform20934820984"

@app.route('/')
def index():
    return render_template("index8.html")

@app.route('/create', methods= ['POST'])
def create():
    first_name = request.form['first_name']
    last_name = request.form['last_name']
    email= request.form['email']
    password1= request.form['password1']
    password2= request.form['password2']
    is_errors= False
    if first_name == '':
        error_msg= "First name is required."
        is_errors= True
        flash(error_msg)
    if str.isalpha(first_name) is False:
        error_msg= "First name must be alphabetic characters."
        is_errors= True
        flash(error_msg)
    if last_name == '':
        error_msg= "Last name is required."
        is_errors= True
        flash(error_msg)
    if str.isalpha(last_name) is False: 
        error_msg= "Last name must be alphabetic characters."
        is_errors= True
        flash(error_msg)
    if email == '':
        error_msg= "Email address is required."
        is_errors= True
        flash(error_msg)
    elif not EMAIL_REGEX.match(request.form['email']):
        error_msg= "Email is invalid."
        is_errors= True
        flash(error_msg)
    if password1 == '':
        error_msg= "Password is required."
        is_errors= True
        flash(error_msg)
    if password2 == '':
        error_msg= "Password confirmation is required."
        is_errors= True
        flash(error_msg)
    if password1  != password2:
        error_msg= "Passwords must match."
        is_errors= True
        flash(error_msg)
    if len(password1) < 8:
        error_msg= "Password must be more than 8 characters."
        is_errors= True
        flash(error_msg)
    if len(password2) < 8:
        error_msg= "Password confirmation must be more than 8 characters."
        is_errors= True
        flash(error_msg)

    if is_errors:
        return redirect ('/')

    # print(request.form)
    # print(name)
    # print(location)
    # print(language)

    else: #data is valid
        session['first_name'] = first_name
        session['last_name']= last_name
        session['email']= email
        session['password1']= password1
        session['password2']= password2
        return redirect('/result')

@app.route('/result', methods= ['GET'])
def result():
    return render_template('result2.html')

if __name__=="__main__":
    app.run(debug=True)