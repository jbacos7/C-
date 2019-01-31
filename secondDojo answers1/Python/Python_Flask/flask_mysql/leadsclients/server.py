from flask import Flask,render_template, redirect, request
# import the function connectToMySQL from the file mysqlconnection.py
from mysqlconnection import connectToMySQL
app = Flask(__name__)
# invoke the connectToMySQL function and pass it the name of the database we're using
# connectToMySQL returns an instance of MySQLConnection, which we will store in the variable 'mysql'
mysql = connectToMySQL('leadsclients')
@app.route('/')
def index():
    mysql = connectToMySQL("leadsclients")
    all_customers = mysql.query_db("SELECT * FROM customers")
    print("Fetched all customers", all_customers)
    return render_template('leads.html', customers = all_customers)

# @app.route('/create_friend', methods=['POST'])
# def create():
#     mysql = connectToMySQL("friendsdb")
#     query = "INSERT INTO friends (first_name, last_name, occupation, created_at, updated_at) VALUES (%(first_name)s, %(last_name)s, %(occupation)s, NOW(), NOW());"
#     data = {
#             'first_name': request.form['first_name'],
#             'last_name':  request.form['last_name'],
#             'occupation': request.form['occupation']
#            }
#     new_friend_id = mysql.query_db(query, data)
#     return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)
