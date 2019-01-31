from flask import Flask, render_template, request, redirect, session, flash
from mysqlconnection import connectToMySQL
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key= "/email2309423048"
mysql = connectToMySQL('emailvalidation')

@app.route('/')
def index():
    mysql = connectToMySQL("emailvalidation")
    session['all_email'] = mysql.query_db("SELECT * FROM email")
    return render_template('index2.html', emails = session['all_email'] )
    email= request.form['email']

@app.route('/submit', methods=['POST'])
def create():
    email= request.form['email']
    if email == '':
        error_msg= "Email address is required!"
        is_errors= True
        flash(error_msg)

    elif not EMAIL_REGEX.match(request.form['email']):
        error_msg= "Email is invalid!"
        is_errors= True
        flash(error_msg)
   
    if is_errors:
        return redirect ('/')

    else: #data is valid
        session['email']= email

    if '_flashes' in session.keys():
        return redirect('/')
    mysql = connectToMySQL("emailvalidation")
    query = "INSERT INTO email (email, created_at) VALUES (%(email)s, NOW());"
    data = {
            'email': request.form['email'],
           }
    new_email_id = mysql.query_db(query, data)
    is_errors= False

    print("*"*50)
    print("end of submit")
    return redirect('/success')

@app.route('/success', methods= ['GET'])
def result():
    print("*"*50)
    emails= session['all_email'] 
    return render_template('success.html', emails=emails)


if __name__ == "__main__":
    app.run(debug=True)



