from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)  
print(__name__)

app.secret_key= "/ninjaaaaaaagold"

# from random import randint
# testnum = randint(1,101)
# print(testnum)

@app.route('/')
def index():
    # if 'num' not in session:
    #     session['num'] = 0
    # if 'result' not in session:
    #     session['result'] = ''
    # if 'color' not in session:
    #     session['color'] = ''    
    return render_template("index6.html",num = session['num'], result = session['result'], color = session['color'])


@app.route('/', methods=['POST'])
def create_user():
    session['guess'] = request.form['guess']
    rand = random.randrange(0,100)
    if int(session['guess']) >  int(rand):
        session['num'] = 55
        session['result'] =  'Your guess is too high. Try again!'
        session['color'] = 'red'
    elif int(session['guess']) <  int(rand):
        session['num'] = 55
        session['result'] =  'Your guess is too low. Try again!'
        session['color'] = 'red'
    elif int(session['guess']) ==  int(rand):
        session['num'] = 55
        session['result'] =  'Correct! Ding ding ding!'
        session['color'] = 'green'
    return redirect('/')

if __name__=="__main__":   
    app.run(debug=True)

# @app.route('/guess', methods= ['POST'])
# def check():
#     if session['num'] == testnum:
#         return redirect ("/correct")
#     elif session ['num'] > testnum:
#         print ("Your guess is too high!")
#     elif session ['num'] < testnum:
#         print("Your guess is too low!")

#     num = request.form['num']
#     print(num)
#     session['num']= num
#     return redirect ("guess.html")

# # @app.route('/correct', methods= ['POST'])
# # def correct():
# #     if 'num' == testnum:
# #         print("Your guess is correct!")
# #     return redirect ("/correct")


# @app.route('/guess', methods=['POST'])
# def check():
#     if session['num'] == None:
#         set()
#     else:
#         pass
#     print (session['num'])
#     return render_template('guess.html')




# @app.route('/guess', methods = ['GET'])
# def reset():
#     session['num']=0
#     return redirect ("/guess")

# if __name__=="__main__":
#     app.run(debug=True)


