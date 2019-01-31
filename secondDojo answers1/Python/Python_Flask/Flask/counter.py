from flask import Flask, render_template, redirect, session
app = Flask(__name__)  

app.secret_key= "/counterhello"

@app.route('/', methods= ['POST'])
def index():
    if 'num' == ['num']
    else:
        #Everytime refresh
        session['num']= session['num']+ 1
    return render_template("index5.html")

@app.route('/', methods= ['POST'])
def MichaelIsAwesome():
    session['num'] = session['num'] + 1
    return redirect('/')

@app.route('/hello', methods= ['GET'])
def result():
    session['num']=session['num']+1
    return redirect ("/index5.html")


@app.route('/zero', methods = ['GET'])
def reset():
    session['num']=0
    return redirect ("/")

if __name__=="__main__":
    app.run(debug=True)

