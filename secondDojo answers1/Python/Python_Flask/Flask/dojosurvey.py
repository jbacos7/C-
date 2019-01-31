from flask import Flask, render_template, request, redirect, session, flash
app = Flask(__name__)

app.secret_key= "/hello"

@app.route('/')
def index():
    return render_template("index3.html")

@app.route('/create', methods= ['POST'])
def create():
    name = request.form['name']
    location= request.form['Dojo_Location']
    language= request.form['Favorite_Language']
    message= request.form['message']
    is_errors= False
    if name == '':
        error_msg= "Name is required."
        is_errors= True
        flash(error_msg)
    if message == '':
        error_msg= "Please include comment."
        is_errors: True
        flash(error_msg)
    if len(message) > 120:
        error_msg= "Comment must be less than 120 characters"
        is_errors: True
        flash(error_msg)
    if is_errors:
        return redirect ('/')

    # print(request.form)
    # print(name)
    # print(location)
    # print(language)

    else: #data is valid
        session['name'] = name
        session['Dojo_Location']= location
        session['Favorite_Language']= language
        session['message']= message
        return redirect('/result')

@app.route('/result', methods= ['GET'])
def result():
    return render_template('result.html')

if __name__=="__main__":
    app.run(debug=True)


