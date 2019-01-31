from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)  

app.secret_key= "/fruitstorehello"

@app.route('/')         
def index():
    return render_template("index4.html")

@app.route('/checkout', methods=['POST'])         
def checkout():
    name = request.form['name']
    raspberry= request.form['raspberry']
    apple= request.form['apple']
    strawberry= request.form['strawberry']
    student_id= request.form['student_id']
    number= request.form['number']
    email= request.form['email']

    print(request.form)

    session['name'] = name
    session['raspberry']= raspberry
    session['strawberry']= strawberry
    session['apple']= apple
    session['student_id']= student_id
    session['number']= number
    session['email']= email
    
    
    print(request.form)
    return render_template("checkout.html")


@app.route('/fruits')         
def fruits():
    return render_template("fruits.html")

    

if __name__=="__main__":   
    app.run(debug=True)    
