from flask import Flask, render_template, request, redirect, session, flash
from mysqlconnection import connectToMySQL
from flask_bcrypt import Bcrypt
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key= "/login20498239084"
bcrypt= Bcrypt(app)
MySQL = connectToMySQL('login')

@app.route('/')
def index():
    MySQL = connectToMySQL("login")
    session['all_users'] = MySQL.query_db("SELECT * FROM users")
    return render_template('index3.html', users = session['all_users'] )

@app.route('/submit', methods=['POST'])
def create():
    first_name= request.form['first_name']
    is_errors= False
    if first_name == '':
        error_msg= "First name is required."
        is_errors= True
        flash(error_msg)
    if len(first_name) < 2:
        error_msg= "First name must be more than 2 characters"
        is_errors= True
        flash(error_msg)
    if str.isalpha(first_name) is False:
        error_msg= "First name must be letters."
        is_errors= True
        flash(error_msg)
    last_name= request.form['last_name']
    if last_name == '':
        error_msg= "Last name is required."
        is_errors= True
        flash(error_msg)
    if len(last_name) < 2:
        error_msg= "Last name must be more than 2 characters"
        is_errors= True
        flash(error_msg)
    if str.isalpha(last_name) is False: 
        error_msg= "Last name must be letters."
        is_errors= True
        flash(error_msg)
    email= request.form['email']
    if email == '':
        error_msg= "Email address is required."
        is_errors= True
        flash(error_msg)
    elif not EMAIL_REGEX.match(request.form['email']):
        error_msg= "Email is invalid!"
        is_errors= True
        flash(error_msg)
    if request.form['password1'] != request.form['password2']:
        error_msg= "Passwords do not match."
        is_errors= True
        flash(error_msg)
    if (len(request.form['password1']) < 8):
        error_msg= "The password is too short."
        is_errors= True
        flash(error_msg)
    if is_errors:
        return redirect ('/')

    if '_flashes' in session.keys():
        return redirect('/')
    MySQL = connectToMySQL("login")
    sqlQuery = "SELECT * FROM users WHERE email= '" + email + "';"
    results = MySQL.query_db(sqlQuery)
    if len(results) > 0:
        error_msg= "This email is already in the database."
        is_errors= True
        flash(error_msg)
    # if request.form['password1'] != request.form['password2']:
    #     error_msg= "Passwords do not match."
    #     is_errors= True
    #     flash(error_msg)
    # if (len(request.form['password1']) < 8):
    #     error_msg= "The password is too short."
    #     is_errors= True
    #     flash(error_msg)
    if is_errors== False:
        hashed_pw = bcrypt.generate_password_hash(request.form['password1'])
        MySQL = connectToMySQL("login")
        sqlQuery= "INSERT INTO users (first_name, last_name, email, hashed_pw) VALUES (%(first_name)s, %(last_name)s, %(email)s, %(hashed_pw)s);"
        data = {
            'first_name': request.form['first_name'],
            'last_name': request.form['last_name'],
            'email': request.form['email'],
            'hashed_pw': hashed_pw
           }
        new_user = MySQL.query_db(sqlQuery, data)
        print(new_user)
        return redirect ('/success')
    else:
        return redirect ('/')
@app.route ('/validlogin', methods= ['POST'])
def logininfo():
    # else: 
    email= request.form['email']
    password=request.form['password1']
    MySQL = connectToMySQL("login")
    #check to see if there is an email in the database
    sqlQuery = "SELECT * FROM users WHERE email = %(email)s;"
    data= {
        'email': request.form["email"],
    }
    results = MySQL.query_db(sqlQuery, data)
    print (results, len(results))
    if len(results) == 0:
        error_msg= "You could not be logged in."
        is_errors= True
        flash(error_msg)
        return redirect ('/')
    if bcrypt.check_password_hash(results[0]['hashed_pw'], request.form['password1']):
        # is_errors= False
        session['userid'] = results[0]
        return redirect ('/success')

        # return render_template ('/')
        #valid account because the user password was a match, return to success page, 
        # place in session and redirect to success page
    
    else: 
        is_errors= True
        error_msg= "You could not be logged in."
        flash(error_msg)
        return redirect ('/')
        #invalid account because the password failed - error msg - could not be logged in
        # go to ('/')

    # session['userid'] = result[0]['id']

    # is_errors= True
    # flash(error_msg)

    print("*"*50)
    print("end of submit")
    return redirect('/success')

@app.route('/success', methods= ['GET'])
def result():
    print("*"*50)
    users= session['all_users'] 
    return render_template('success2.html', users=users)


if __name__ == "__main__":
    app.run(debug=True)



